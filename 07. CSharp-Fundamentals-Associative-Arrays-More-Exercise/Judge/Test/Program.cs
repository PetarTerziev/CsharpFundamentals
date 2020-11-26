using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestUsersPoints = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> individualStatistic = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "no more time")
            {
                string[] splitInput = input.Split(" -> ");
                string name = splitInput[0];
                string contest = splitInput[1];
                int points = int.Parse(splitInput[2]);

                if (contestUsersPoints.ContainsKey(contest))
                {
                    if (contestUsersPoints[contest].ContainsKey(name))
                    {
                        if (contestUsersPoints[contest][name] < points)
                        {
                            individualStatistic[name] -= contestUsersPoints[contest][name];
                            contestUsersPoints[contest][name] = points;
                            individualStatistic[name] += points;
                        }
                    }
                    else
                    {
                        contestUsersPoints[contest].Add(name, points);
                        if (individualStatistic.ContainsKey(name))
                        {
                            individualStatistic[name] += points;
                        }
                        else
                        {
                            individualStatistic.Add(name, points);
                        }

                    }

                }
                else
                {
                    contestUsersPoints.Add(contest, new Dictionary<string, int>());
                    contestUsersPoints[contest].Add(name, points);
                    if (individualStatistic.ContainsKey(name))
                    {
                        individualStatistic[name] += points;
                    }
                    else
                    {
                        individualStatistic.Add(name, points);
                    }

                }
                input = Console.ReadLine();
            }
            int count = 0;

            foreach (var item in contestUsersPoints)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count} participants");
                foreach (var std in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    count++;
                    Console.WriteLine($"{count}. {std.Key} <::> {std.Value}");
                }
                count = 0;
            }

            count = 0;
            Console.WriteLine("Individual standings:");

            foreach (var item in individualStatistic.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                count++;
                Console.WriteLine($"{count}. {item.Key} -> {item.Value}");
            }

        }
    }
}
