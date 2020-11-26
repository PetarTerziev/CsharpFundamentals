using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Snowwhite
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfList = new Dictionary<string, int>();

            while (true)
            {
                string[] dwarfInfo = Console.ReadLine().Split(" <:> ").ToArray();

                if (dwarfInfo[0] == "Once upon a time")
                {
                    break;
                }

                UpdateDwarflist(dwarfList, dwarfInfo);
            }


            foreach (var pair in dwarfList
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfList.Where(y => y.Key.Split(":")[1] == x.Key.Split(":")[1]).Count()))
            {
                
                Console.WriteLine($"({pair.Key.Split(":")[1]}) {pair.Key.Split(":")[0]} <-> {pair.Value}");
            }
            
        }

        static Dictionary<string, int> UpdateDwarflist
                     (Dictionary<string, int> dwarfList, string[] dwarfInfo)
        {
            string dwarfId = $"{dwarfInfo[0]}:{dwarfInfo[1]}";
            int dwarfPhysics = int.Parse(dwarfInfo[2]);

            if (!dwarfList.ContainsKey(dwarfId))
            {
                dwarfList.Add(dwarfId, dwarfPhysics);
            }
            else
            {
                dwarfList[dwarfId] = Math.Max(dwarfList[dwarfId], dwarfPhysics);
            }

            return dwarfList;
        }
    }
}
