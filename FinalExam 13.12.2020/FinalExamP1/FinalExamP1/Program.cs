using System;
using System.Linq;

namespace FinalExamP1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] infoCommand = Console.ReadLine().Split().ToArray();
                string command = infoCommand[0];

                if (command == "End")
                {
                    break;
                }

                switch (command)
                {
                    case "Translate":
                        string replacement = infoCommand[1];
                        input = input.Replace(replacement, infoCommand[2]);
                        Console.WriteLine(input);
                        break;
                    case "Includes":
                        Console.WriteLine(input.Contains(infoCommand[1]));
                        break;
                    case "Start":
                        int length = infoCommand[1].Length;
                        string substring = input.Substring(0, length);
                        Console.WriteLine(substring == infoCommand[1]);
                        break;
                    case "Lowercase":
                        input = input.ToLower();
                        Console.WriteLine(input);
                        break;
                    case "FindIndex":
                        string temp = string.Join("", input.ToCharArray().Reverse());
                        int index = temp.IndexOf(infoCommand[1]);
                        Console.WriteLine(input.Length - 1 - index);
                        break;
                    case "Remove":
                        int startIndex = int.Parse(infoCommand[1]);
                        int count = int.Parse(infoCommand[2]);
                        input = input.Remove(startIndex, count);
                        Console.WriteLine(input);
                        break;
                }
            }
        }
    }
}
