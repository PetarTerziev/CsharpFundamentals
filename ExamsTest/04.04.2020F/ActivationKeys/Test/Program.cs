using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] cmdArgs = command.Split(">>>");

                if (cmdArgs[0] == "Contains")
                {
                    string substring = cmdArgs[1];

                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (cmdArgs[0] == "Flip")
                {
                    if (cmdArgs[1] == "Upper")
                    {
                        int startIndex = int.Parse(cmdArgs[2]);
                        int endIndex = int.Parse(cmdArgs[3]);

                        for (int i = startIndex; i < endIndex; i++)
                        {
                            StringBuilder result = new StringBuilder(key);
                            result[i] = Char.ToUpper(result[i]);
                            key = result.ToString();
                        }

                        Console.WriteLine(key);
                    }
                    else if (cmdArgs[1] == "Lower")
                    {
                        int startIndex = int.Parse(cmdArgs[2]);
                        int endIndex = int.Parse(cmdArgs[3]);

                        for (int i = startIndex; i < endIndex; i++)
                        {
                            StringBuilder result = new StringBuilder(key);
                            result[i] = Char.ToLower(result[i]);
                            key = result.ToString();
                        }

                        Console.WriteLine(key);
                    }
                }
                else if (cmdArgs[0] == "Slice")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        key = key.Remove(startIndex, 1);
                    }

                    Console.WriteLine(key);
                }

                command = Console.ReadLine();
            }

            Console.Write($"Your activation key is: {key}");
        }
    }
}