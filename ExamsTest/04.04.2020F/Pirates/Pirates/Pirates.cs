using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    class Pirates
    {
        static void Main(string[] args)
        {
            Dictionary<string, Settlements> settlementsInfo = new Dictionary<string, Settlements>();

            while (true)
            {
                string[] townInfo = Console.ReadLine().Split("||").ToArray();
                string townName = townInfo[0];

                if (townName == "Sail")
                {
                    break;
                }

                int population = int.Parse(townInfo[1]);
                int gold = int.Parse(townInfo[2]);


                if (!settlementsInfo.ContainsKey(townName))
                {
                    settlementsInfo.Add(townName, new Settlements(townName, population, gold));
                }
                else
                {
                    int goldUpdate = settlementsInfo[townName].Gold + gold;
                    int populationUpdate = settlementsInfo[townName].Population + population;
                    settlementsInfo[townName] = new Settlements(townName, populationUpdate, goldUpdate);
                }
            }

            while (true)
            {
                string[] townInfo = Console.ReadLine().Split("=>").ToArray();
                string command = townInfo[0];

                if (command == "End")
                {
                    break;
                }

                string townName = townInfo[1];

                switch (command)
                {
                    case "Plunder":
                        int populationDecrease = int.Parse(townInfo[2]);
                        int goldStolen = int.Parse(townInfo[3]);
                        bool isTownDestroyed = settlementsInfo[townName].Population - populationDecrease == 0;
                        bool isTownRobbed = settlementsInfo[townName].Gold - goldStolen == 0;

                        int goldUpdate = settlementsInfo[townName].Gold - goldStolen;
                        int populationUpdate = settlementsInfo[townName].Population - populationDecrease;
                        settlementsInfo[townName] = new Settlements(townName, populationUpdate, goldUpdate);

                        Console.WriteLine($"{townName} plundered! {goldStolen} gold stolen, {populationDecrease} citizens killed.");

                        if (isTownDestroyed || isTownRobbed)
                        {
                            settlementsInfo.Remove(townName);
                            Console.WriteLine($"{townName} has been wiped off the map!");
                        }

                        break;
                    case "Prosper":
                        int goldAdded = int.Parse(townInfo[2]);

                        if (settlementsInfo.ContainsKey(townName))
                        {
                            if (goldAdded < 0)
                            {
                                Console.WriteLine("Gold added cannot be a negative number!");
                            }
                            else
                            {
                                settlementsInfo[townName] = new Settlements(townName,
                                                                        settlementsInfo[townName].Population,
                                                                        settlementsInfo[townName].Gold + goldAdded);
                                int currentGold = settlementsInfo[townName].Gold;
                                Console.WriteLine($"{goldAdded} gold added to the city treasury. {townName} now has {currentGold} gold.");
                            }
                            
                        }

                        break;
                }
            }

            if (settlementsInfo.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {settlementsInfo.Count} wealthy settlements to go to:");

                foreach (var settlement in settlementsInfo.OrderByDescending(x => x.Value.Gold).ThenBy(x => x.Value.Name))
                {
                    Console.WriteLine(settlement.Value);
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }


        class Settlements
        {
            public Settlements(string name, int population, int gold)
            {
                this.Name = name;
                this.Population = population;
                this.Gold = gold;
            }
            public string Name { get; set; }
            public int Population { get; set; }
            public int Gold { get; set; }

            public override string ToString()
            {
                return $"{this.Name} -> Population: {this.Population} citizens, Gold: {this.Gold} kg";
            }
        }
    }
}
