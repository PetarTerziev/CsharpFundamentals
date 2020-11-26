using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> farmingLog = new Dictionary<string, int>();

            farmingLog.Add("shards", 0);
            farmingLog.Add("fragments", 0);
            farmingLog.Add("motes", 0);

            int quantity = 0;
            string materialName = string.Empty;
            bool isWinnerExist = false;
            string wiinerName = string.Empty;

            while (true)
            {
                string[] materialsInfo = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();

                for (int i = 0; i < materialsInfo.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        quantity = int.Parse(materialsInfo[i]);
                        continue;
                    }

                    materialName = materialsInfo[i];

                    if (!farmingLog.ContainsKey(materialName))
                    {
                        farmingLog.Add(materialName, 0);
                    }

                    farmingLog[materialName] += quantity;

                    bool isNeededMaterial = materialName == "shards" || materialName == "fragments"
                                                                     || materialName == "motes";

                    if (isNeededMaterial && farmingLog[materialName] >= 250)
                    {
                        isWinnerExist = true;
                        wiinerName = materialName;
                        farmingLog[materialName] -= 250;
                        break;
                    }
                }

                if (isWinnerExist)
                {
                    break;
                }
            }

            if (wiinerName == "shards")
            {
                wiinerName = "Shadowmourne";
                
            }
            else if (wiinerName == "fragments")
            {
                wiinerName = "Valanyr";
            }
            else
            {
                wiinerName = "Dragonwrath";
            }

            Console.WriteLine($"{wiinerName} obtained!");

            foreach (var pair in farmingLog.Where(x => x.Key == "shards" || x.Key == "fragments"|| x.Key == "motes")
                                           .OrderByDescending(x => x.Value)
                                           .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }


            foreach (var pair in farmingLog.Where(x => x.Key != "shards" && x.Key != "fragments" && x.Key != "motes")
                                           .OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
