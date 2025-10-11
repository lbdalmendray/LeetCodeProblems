namespace NetFramework472ToNet9;

internal class Program
{
    static async Task Main(string[] args)
    {
        ProjectGenerator projectGenerator = new ProjectGenerator("FileList.txt");
        await projectGenerator.GenerateNewProjectsAsync();
    }
}
