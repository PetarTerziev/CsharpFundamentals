using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class PlantDiscovery
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plantJournal = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string itemName = input.Split("<->").ToArray()[0];
                int rarity = int.Parse(input.Split("<->").ToArray()[1]);
                plantJournal.Add(new Plant(itemName, rarity));
            }

            while (true)
            {
                string[] exhibitionInfo = Console.ReadLine().Split(": ").ToArray();

                string command = exhibitionInfo[0];

                if (command == "Exhibition")
                {
                    break;
                }

                string[] tokens = exhibitionInfo[1].Split(" - ");
                string plantName = tokens[0];

                if (!plantJournal.Any(x => x.Name == plantName))
                {
                    Console.WriteLine("error");
                    continue;
                }

                if (command == "Rate")
                {
                    foreach (var plant in plantJournal.Where(x => x.Name == plantName))
                    {
                        plant.Ratings.Add(int.Parse(tokens[1]));
                    }
                }
                else if (command == "Update")
                {
                    foreach (var plant in plantJournal.Where(x => x.Name == plantName))
                    {
                        plant.Rarity = int.Parse(tokens[1]);
                    }
                }
                else if (command == "Reset")
                {
                    foreach (var plant in plantJournal.Where(x => x.Name == plantName))
                    {
                        plant.Ratings.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            Console.WriteLine($"Plants for the exhibition:");

            foreach (var plant in plantJournal.OrderByDescending(x => x.Rarity).ThenByDescending(x => x.PlantAverage()))
            {
                Console.WriteLine(plant);
            }
        }

        class Plant
        {
            public Plant(string name, int rarity)
            {
                this.Name = name;
                this.Rarity = rarity;
                this.Ratings = new List<int>();
            }

            public string Name { get; set; }
            public int Rarity { get; set; }
            public List<int> Ratings { get; set; }
            public override string ToString()
            {
                return $"- {this.Name}; Rarity: {this.Rarity}; Rating: {this.PlantAverage():f2}";
            }
            public double PlantAverage()
            {
                if (this.Ratings.Count == 0)
                {
                    return 0.00;
                }

                return this.Ratings.Average();
            }
        }
    }
}
