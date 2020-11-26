using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class CompanyUsers
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companyList = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string[] courseInfo = Console.ReadLine().Split(" -> ").ToArray();

                string companyName = courseInfo[0];

                if (companyName == "End")
                {
                    break;
                }

                string employeeId = courseInfo[1];

                if (!companyList.ContainsKey(companyName))
                {
                    companyList.Add(companyName, new List<string>());
                }
                else if (companyList[companyName].Contains(employeeId))
                {
                    continue;
                }

                companyList[companyName].Add(employeeId);
            }

            foreach (var pair in companyList)
            {
                Console.WriteLine($"{pair.Key}");

                foreach (var value in pair.Value)
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}
