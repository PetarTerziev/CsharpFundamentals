using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class MovingTarget
    {
        static void Main(string[] args)
        {
            List<short> targets = Console.ReadLine().Split().Select(short.Parse).ToList();

            while (true)
            {
                string[] shotInfo = Console.ReadLine().Split().ToArray();

                if (shotInfo[0] == "End")
                {
                    break;
                }

                Shoottargets(targets, shotInfo);
            }

            Console.WriteLine(string.Join("\", targets));
        }
        public static List<short> Shoottargets(List<short> targets, string [] shotInfo)
        {
            string command = shotInfo[0];
            short index = short.Parse(shotInfo[1]);
            short valueToProccess = short.Parse(shotInfo[2]);

            switch (command)
            {
                case "Add":

                    if (index < 0 || index >= targets.Count)
                    {
                        PrintCorrectMessage(command);
                    }
                    else
                    {
                        targets.Insert(index, valueToProccess);
                    }
                    break;

                case "Shoot":

                    if (index >= 0 || index < targets.Count)
                    {
                        short power = valueToProccess;
                        targets[index] -= power;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                    break;

                case "Strike":
                    short range = valueToProccess;

                    if ((index >= 0 && index < targets.Count) &&
                        (index - range >= 0 && index + range < targets.Count))
                    {

                        for (int i = index - range; i <= index + range; i++)
                        {
                            targets.RemoveAt(i);
                            i -= 1;
                            range -= 1;
                        }
                    }
                    else
                    {
                        PrintCorrectMessage(command);
                    }
                    break;
            }

            return targets;
        }
        public static void PrintCorrectMessage(string keyWord)
        {
            string message = string.Empty;

            switch (keyWord)
            {
                case "Add":
                    message = "Invalid placement!";
                    break;
                case "Strike":
                    message = "Strike missed!";
                    break;
            }

            Console.WriteLine(message);
        }

    }
}
