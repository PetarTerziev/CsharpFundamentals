using System;
using System.Collections.Generic;
using System.Linq;

namespace Loot
{
    class Loot
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split("|").ToList();
            decimal averageGain = 0;

            while (true)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                if (input[0] == "Yohoho!")
                {
                    break;
                }

                string command = input[0];

                switch (command)
                {
                    case "Loot":

                        for (int i = 1; i < input.Length; i++)
                        {
                            string loot = input[i];

                            if (!chest.Contains(loot))
                            {
                                chest.Insert(0, loot);
                            }
                        }
                        break;
                    case "Drop":
                        int index = int.Parse(input[1]);

                        if (index >= 0 && index < chest.Count)
                        {
                            string temp = chest[index];
                            chest.RemoveAt(index);
                            chest.Add(temp);
                        }
                        break;
                    case "Steal":

                        int count = Math.Min(int.Parse(input[1]), chest.Count);
                        List<string> stolenItems = chest.ToList();

                        stolenItems.RemoveRange(0, chest.Count - count);
                        chest.RemoveRange(chest.Count - count, count);

                        Console.WriteLine(string.Join(", ", stolenItems));
                        break;
                }
            }

            if (chest.Count == 0)
            {
                Console.WriteLine($"Failed treasure hunt.");
            }
            else
            {
                averageGain = chest.Sum(x => x.Length) / (decimal)chest.Count;

                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
        }
    }
}
