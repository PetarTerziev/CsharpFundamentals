using System;
using System.Collections.Generic;
using System.Linq;


namespace MOBAChallenger
{
    class MOBAChallenger
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> duelsClub = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Season end")
                {
                    break;
                }

                string[] playersInfo = null;
                bool isDuelingDay = false;

                if (input.Contains("->"))
                {
                    playersInfo = input.Split(" -> ").ToArray();
                }
                else
                {
                    playersInfo = input.Split(" vs ").ToArray();
                    isDuelingDay = true;
                }

                string playerName = playersInfo[0];

                if (!isDuelingDay)
                {
                    if (!duelsClub.ContainsKey(playerName))
                    {
                        duelsClub.Add(playerName, new Dictionary<string, int>());
                    }

                    string position = playersInfo[1];
                    ushort skillPower = ushort.Parse(playersInfo[2]);

                    if (!duelsClub[playerName].ContainsKey(position))
                    {
                        duelsClub[playerName].Add(position, skillPower);
                    }
                    else if (skillPower > duelsClub[playerName][position])
                    {
                        duelsClub[playerName][position] = skillPower;
                    }
                }
                else
                {
                    string playerOne = playerName;
                    string playerTwo = playersInfo[1];

                    if (duelsClub.ContainsKey(playerOne) && duelsClub.ContainsKey(playerTwo))
                    {
                        bool isTimeToDuel = duelsClub[playerOne].Keys.ToList()
                                                                .Select(x => duelsClub[playerTwo].ContainsKey(x))
                                                                .Contains(true);
                        if (isTimeToDuel)
                        {
                            int playerOnePoints = duelsClub[playerOne].Values.Sum();
                            int playerTwoPoints = duelsClub[playerTwo].Values.Sum();

                            if (playerOnePoints > playerTwoPoints)
                            {
                                duelsClub.Remove(playerTwo);
                            }
                            else if (playerTwoPoints > playerOnePoints)
                            {
                                duelsClub.Remove(playerOne);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            foreach (var pair in duelsClub.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Values.Sum()} skill");

                foreach (var pos in pair.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {pos.Key} <::> {pos.Value}");
                }
            }
        }
    }
}
