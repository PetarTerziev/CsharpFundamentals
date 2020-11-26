using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestLog = new Dictionary<string, string>();

            Dictionary<string, Dictionary<string, int>> contestSub = new Dictionary<string, Dictionary <string, int>>();

            while (true)
            {
                string[] contestInfo = Console.ReadLine().Split(":").ToArray();
                string contestName = contestInfo[0];

                if (contestName == "end of contests")
                {
                    break;
                }

                string password = contestInfo[1];

                if (!contestLog.ContainsKey(contestName))
                {
                    contestLog.Add(contestName, password);
                }
            }

            while (true)
            {
                string[] submissionInfo = Console.ReadLine().Split("=>").ToArray();
                string submissionName = submissionInfo[0];

                if (submissionName == "end of submissions")
                {
                    break;
                }

                string passwordToLogIn = submissionInfo[1];

                if (contestLog.ContainsKey(submissionName) && contestLog[submissionName] == passwordToLogIn)
                {
                    string contestantName = submissionInfo[2];
                    int submissionScore = int.Parse(submissionInfo[3]);

                    Dictionary<string, int> submission = new Dictionary<string, int>();

                    if (!contestSub.ContainsKey(contestantName))
                    {
                        contestSub.Add(contestantName,submission);
                    }

                    if (!contestSub[contestantName].ContainsKey(submissionName))
                    {
                        contestSub[contestantName].Add(submissionName, submissionScore);
                    }
                    else if (submissionScore > contestSub[contestantName][submissionName])
                    {
                        contestSub[contestantName][submissionName] = submissionScore;
                    }
                }
            }

            int maxScore = int.MinValue;
            string winner = string.Empty;

            foreach (var pair in contestSub)
            {
                if (pair.Value.Values.Sum() > maxScore)
                {
                    maxScore = pair.Value.Values.Sum();
                    winner = pair.Key;
                }
            }

            Console.WriteLine($"Best candidate is {winner} with total {maxScore} points.");
            Console.WriteLine("Ranking:");

            foreach (var pair in contestSub.OrderBy(x => x.Key))
            { 
                Console.WriteLine($"{pair.Key}");

                foreach (var submission in pair.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {submission.Key} -> {submission.Value}");
                }
            }
        }
    }
}
