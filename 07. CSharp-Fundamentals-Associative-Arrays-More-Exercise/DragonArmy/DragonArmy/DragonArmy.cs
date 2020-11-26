using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class DragonArmy
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<int>>> dragonsArmy = new Dictionary<string, Dictionary<string, List<int>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] dragonInfo = Console.ReadLine().Split().ToArray();

                string dragonType = dragonInfo[0];
                string dragonName = dragonInfo[1];

                int damage = dragonInfo[2] != "null" ? int.Parse(dragonInfo[2]) : 45;
                int health = dragonInfo[3] != "null" ? int.Parse(dragonInfo[3]) : 250;
                int armor = dragonInfo[4] != "null" ? int.Parse(dragonInfo[4]) : 10;



                if (!dragonsArmy.ContainsKey(dragonType))
                {
                    dragonsArmy.Add(dragonType, new Dictionary<string, List<int>>());
                    
                }

                if (!dragonsArmy[dragonType].ContainsKey(dragonName))
                {
                    dragonsArmy[dragonType].Add(dragonName, new List<int> { damage, health, armor });
                }
                else
                {
                    dragonsArmy[dragonType][dragonName] = new List<int> { damage, health, armor };
                }
            }

            foreach (var army in dragonsArmy)
            {
                double averageDamage = army.Value.Select(x => x.Value[0]).Average();
                double averageHealth = army.Value.Select(x => x.Value[1]).Average();
                double averageArmor = army.Value.Select(x => x.Value[2]).Average();


                Console.WriteLine($"{army.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (var dragon in army.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, " +
                                                        $"health: {dragon.Value[1]}, " +
                                                        $"armor: {dragon.Value[2]}");
                }
            }

        }
    }
}
