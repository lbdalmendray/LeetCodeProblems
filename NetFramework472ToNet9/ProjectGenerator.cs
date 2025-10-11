using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFramework472ToNet9;

public class ProjectGenerator
{
	private string fileListContainer;

	public ProjectGenerator(string fileListContainer)
	{
		try
		{
			Directory.SetCurrentDirectory("..\\..\\..\\..\\");
            var dir = Directory.GetCurrentDirectory();
            this.fileListContainer = Path.Combine(dir, fileListContainer);
            if (!File.Exists(this.fileListContainer))
			{
				throw new FileNotFoundException("File not found", fileListContainer);
			}			
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}

	public async Task GenerateNewProjectsAsync()
	{
		using StreamReader reader = new StreamReader(fileListContainer);
		var solutionDirectory = Directory.GetCurrentDirectory();
		var temporalRemoveDirectory = Path.Combine(solutionDirectory, "TemporalRemove");
		while (!reader.EndOfStream)
		{

			var folderPrjectName1 = await reader.ReadLineAsync();
			var folderProjectPath1 = Path.Combine(solutionDirectory, folderPrjectName1);

			var folderPrjectName2 = $"{Path.GetFileNameWithoutExtension(folderPrjectName1)}Test";
			var folderProjectPath2 = Path.Combine(solutionDirectory, folderPrjectName2);


			List<(string, string, bool)> listOfProjects = new List<(string, string, bool)>();
			listOfProjects.Add((folderPrjectName1, folderProjectPath1, false));
			listOfProjects.Add((folderPrjectName2, folderProjectPath2, true));
			foreach (var (folderPrjectName, folderProjectPath, isTestProject) in listOfProjects)
			{
                if (Directory.Exists(temporalRemoveDirectory))
                {
                    Directory.Delete(temporalRemoveDirectory, true);
                }

                Directory.CreateDirectory(temporalRemoveDirectory);

                if (Directory.Exists(folderProjectPath))
				{
					/// MOVING ALL THE .CS FILES TO A TEMPORAL FOLDER
					foreach (var file in Directory.EnumerateFiles(folderProjectPath, "*.cs", SearchOption.TopDirectoryOnly))
					{
						File.Move(file, Path.Combine(temporalRemoveDirectory, Path.GetFileName(file)));
					}

					Directory.Delete(folderProjectPath, true);
					Directory.CreateDirectory(folderProjectPath);

					/// MOVING BACK THE .CS FILES TO THE NEW FOLDER
					foreach (var file in Directory.EnumerateFiles(temporalRemoveDirectory, "*.*", SearchOption.TopDirectoryOnly))
					{
						File.Move(file, Path.Combine(folderProjectPath, Path.GetFileName(file)));
					}

					/// CREATING THE NEW .CSPROJ FILE
					/// 

					var projectFilePath = Path.Combine(folderProjectPath, $"{folderPrjectName}.csproj");
					using StreamWriter writer = new StreamWriter(projectFilePath);
					if (!isTestProject)
					{
						await writer.WriteAsync($@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>");
					}
					else
					{
						var relativeProjectPath = $@"..\{folderPrjectName1}\{folderPrjectName1}.csproj";
                        await writer.WriteAsync($@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <LangVersion>latest</LangVersion>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.NET.Test.Sdk"" Version=""17.12.0"" />
    <PackageReference Include=""MSTest"" Version=""3.6.4"" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include=""{relativeProjectPath}"" />
  </ItemGroup>

  <ItemGroup>
    <Using Include=""Microsoft.VisualStudio.TestTools.UnitTesting"" />
  </ItemGroup>

</Project>");
                    }
						writer.Close();
				}
			}
		}
	}
}
