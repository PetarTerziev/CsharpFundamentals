using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class SoftUniExamResults
    {
        static void Main(string[] args)
        {
            Dictionary<string, byte> submissions = new Dictionary<string, byte>();
            Dictionary<string, ushort> submissionsCount = new Dictionary<string, ushort>();


            while (true)
            {
                string[] submissionInfo = Console.ReadLine().Split("-").ToArray();

                if (submissionInfo[0] == "exam finished")
                {
                    break;
                }

                string studentName = submissionInfo[0];
                string language = submissionInfo[1];
                byte result = 0;

                if (language != "banned")
                {
                    result = byte.Parse(submissionInfo[2]);

                    if (!submissionsCount.ContainsKey(language))
                    {
                        submissionsCount.Add(language, 0);
                    }

                    submissionsCount[language]++;

                    if (!submissions.ContainsKey(studentName))
                    {
                        submissions.Add(studentName, result);
                    }
                    else if (result > submissions[studentName])
                    {
                        submissions[studentName] = result;
                    }
                }
                else
                {
                    submissions.Remove(studentName);
                }
            }

            Console.WriteLine("Results:");

            foreach (var pair in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key} | {pair.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var pair in submissionsCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
