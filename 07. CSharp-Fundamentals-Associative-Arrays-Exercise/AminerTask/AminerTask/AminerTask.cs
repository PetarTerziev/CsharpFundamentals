using System;
using System.Collections.Generic;

namespace AminerTask
{
    class AminerTask
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> minerLog = new Dictionary<string, long>();
            ushort counterTimes = 0;
            string miningMaterial = string.Empty;

            while (true)
            {
                string miningInfo = Console.ReadLine();

                if (miningInfo == "stop")
                {
                    break;
                }

                counterTimes++;


                if (counterTimes % 2 == 1)
                {
                    miningMaterial = miningInfo;
                }
                else
                {
                    int quantity = int.Parse(miningInfo);

                    if (!minerLog.ContainsKey(miningMaterial))
                    {
                        minerLog.Add(miningMaterial, 0);
                    }

                    minerLog[miningMaterial] += quantity;
                    miningMaterial = string.Empty;
                }
            }

            foreach (var pair in minerLog)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
