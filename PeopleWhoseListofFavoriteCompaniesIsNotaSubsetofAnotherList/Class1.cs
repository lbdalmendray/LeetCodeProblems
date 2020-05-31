using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleWhoseListofFavoriteCompaniesIsNotaSubsetofAnotherList
{
    public class Solution
    {
        public IList<int> PeopleIndexes(IList<IList<string>> favoriteCompanies)
        {
            LinkedList<int> result = new LinkedList<int>();
            int maxTotal = favoriteCompanies.Count * 500;
            Dictionary<string, int> companyNumbers = new Dictionary<string, int>(favoriteCompanies.Count * 500);

            int currentCompanyNumber = 0;

            var array = favoriteCompanies.Select(e => GetCompaniesSelection(e,companyNumbers, maxTotal,ref currentCompanyNumber)).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                bool good = true;
                for (int j = 0; j < array.Length; j++)
                {
                    if (i == j)
                        continue;
                    if ( Contains(array[i].Item2, array[j].Item1 ) )
                    {
                        good = false;
                        break;
                    }
                }

                if (good)
                    result.AddLast(i);
            }

            return result.ToList();
        }

        private bool Contains(LinkedList<int> indexes, bool[] companiesRepresentation)
        {
            foreach (var index  in indexes)
            {
                if (!companiesRepresentation[index])
                    return false;
            }

            return true;
        }

        private Tuple<bool [],LinkedList<int>>  GetCompaniesSelection(IList<string> companies, Dictionary<string,int> companyNumbers,int maxTotal, ref int currentCompanyNumber)
        {
            bool[] result = new bool[maxTotal];
            LinkedList<int> listResult = new LinkedList<int>();
            foreach (var company in companies)
            {
                if ( companyNumbers.TryGetValue(company, out int index))
                {
                    result[index] = true;
                    listResult.AddLast(index);
                }
                else
                {
                    result[currentCompanyNumber] = true;
                    companyNumbers.Add(company, currentCompanyNumber);
                    listResult.AddLast(currentCompanyNumber);
                    currentCompanyNumber++;
                }
            }

            return new Tuple<bool[], LinkedList<int>>(result, listResult);
        }
    }
}
