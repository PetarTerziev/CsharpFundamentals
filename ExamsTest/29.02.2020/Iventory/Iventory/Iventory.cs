using System;
using System.Collections.Generic;
using System.Linq;

namespace Iventory
{
    class Iventory
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string[] craftInfo = Console.ReadLine().Split(" - ").ToArray();

                if (craftInfo[0] == "Craft!")
                {
                    break;
                }

                string command = craftInfo[0];
                string item = craftInfo[1];

                if (command == "Collect" && !journal.Contains(item))
                {
                    journal.Add(item);
                }
                else if (command == "Drop" && journal.Contains(item))
                {
                    journal.Remove(item);
                }
                else if (command == "Renew" && journal.Contains(item))
                {
                    journal.Remove(item);
                    journal.Add(item);
                }
                else if (command == "Combine Items" && journal.Contains(item.Split(":")[0]))
                {
                    int index = journal.IndexOf(item.Split(":")[0]) + 1;
                    journal.Insert(index, item.Split(":")[1]);
                }
            }

            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
