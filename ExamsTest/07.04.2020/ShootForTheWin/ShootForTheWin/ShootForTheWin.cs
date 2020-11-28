using System;
using System.Linq;

namespace ShootForTheWin
{
    class ShootForTheWin
    {
        static void Main(string[] args)
        {
            long[] targets = Console.ReadLine().Split().Select(long.Parse).ToArray();
            int counterShots = 0;

            while (true)
            {
                string shootInfo = Console.ReadLine();

                if (shootInfo == "End")
                {
                    break;
                }

                ushort index = ushort.Parse(shootInfo);

                if (index < 0 || index >= targets.Length)
                {
                    continue;
                }
                else if (targets[index] != -1)
                {
                    counterShots++;
                    Shoottargets(targets, index);
                }
            }

            Console.WriteLine($"Shot targets: {counterShots} -> {string.Join(" ", targets)}");
        }

        public static long[] Shoottargets(long[] targets, ushort index) 
        {
            long[] result = targets;

            long shootedValue = result[index];

            result[index] = -1;

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != -1)
                {
                    if (result[i] > shootedValue)
                    {
                        result[i] -= shootedValue;
                    }
                    else
                    {
                        result[i] += shootedValue;
                    }
                }
            }

            return result;
        } 
    }
}
