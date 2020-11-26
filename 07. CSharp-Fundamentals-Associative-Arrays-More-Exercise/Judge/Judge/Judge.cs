using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Judge
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, ushort>> contestSub = new Dictionary<string, Dictionary<string, ushort>>();
            Dictionary<string, ushort> contestanTotalScore = new Dictionary<string, ushort>();

            while (true)
            {
                string[] submissionInfo = Console.ReadLine().Split(" -> ").ToArray();
                string contestantName = submissionInfo[0];

                if (contestantName == "no more time")
                {
                    break;
                }

                string submissionName = submissionInfo[1];
                ushort score = ushort.Parse(submissionInfo[2]);

                if (!contestSub.ContainsKey(submissionName))
                {
                    contestSub.Add(submissionName, new Dictionary<string, ushort>());
                }

                if (!contestSub[submissionName].ContainsKey(contestantName))
                {
                    contestSub[submissionName].Add(contestantName,score);

                    if (!contestanTotalScore.ContainsKey(contestantName))
                    {
                        contestanTotalScore.Add(contestantName, score);
                    }
                    else
                    {
                        contestanTotalScore[contestantName] += score;
                    }

                }
                else if (score > contestSub[submissionName][contestantName])
                {
                    contestSub[submissionName][contestantName] = score;
                    contestanTotalScore[contestantName] = score;
                }
            }
            ushort counter = 0; 

            foreach (var pair in contestSub)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Count} participants");

                counter = 0;

                foreach (var submission in pair.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    counter++;
                    Console.WriteLine($"{counter}. {submission.Key} <::> {submission.Value}");
                }
            }

            counter = 0;

            Console.WriteLine("Individual standings:");

            foreach (var pair in contestanTotalScore.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                counter++;
                Console.WriteLine($"{counter}. {pair.Key} -> {pair.Value}");
            }
        }
    }
}
