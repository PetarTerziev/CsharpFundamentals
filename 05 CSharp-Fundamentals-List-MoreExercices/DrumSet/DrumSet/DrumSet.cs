using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    class DrumSet
    {
        static void Main(string[] args)
        {
            double availableMoney = double.Parse(Console.ReadLine());
            List<short> drumsSet = Console.ReadLine().Split().Select(short.Parse).ToList();
            List<short> DrumsQualityDefault = drumsSet.ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Hit it again, Gabsy!")
                {
                    break;
                }

                short power = short.Parse(input);
                bool isBroken = false;

                for (int i = 0; i < drumsSet.Count; i++)
                {
                    drumsSet[i] -= power;

                    if (drumsSet[i] <= 0)
                    {
                        isBroken = true;
                    }
                }

                if (isBroken)
                {
                    for (int i = 0; i < drumsSet.Count; i++)
                    {
                        if (drumsSet[i] <= 0)
                        {
                            int priceOfBrokenDrum = DrumsQualityDefault[i] * 3;

                            if (availableMoney >= priceOfBrokenDrum)
                            {
                                drumsSet[i] = DrumsQualityDefault[i];
                                availableMoney -= priceOfBrokenDrum;
                            }
                            else
                            {
                                drumsSet.RemoveAt(i);
                                DrumsQualityDefault.RemoveAt(i);
                                i += -1;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", drumsSet));
            Console.WriteLine($"Gabsy has {availableMoney:f2}lv.");
        }
    }
}
