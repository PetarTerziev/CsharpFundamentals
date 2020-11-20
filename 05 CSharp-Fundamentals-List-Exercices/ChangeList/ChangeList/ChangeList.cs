using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                }

                List<string> tokens = input.Split().ToList();

                ModifyList(numbers, tokens);

            }
        }
        static List<int> ModifyList(List<int> oldList, List<string> tokens)
        {
            List<int> result = oldList;
            string command = tokens[0];
            int index = command == "Insert" ? int.Parse(tokens[2]) : 0;
            int number = int.Parse(tokens[1]);

            switch (command)
            {
                case "Insert":
                    result.Insert(index, number);
                    break;
                case "Delete":
                    RemoveAllElementsByGivenNummber(result, number);
                    break;
            }

            return result;
        }

        static List<int> RemoveAllElementsByGivenNummber(List<int> oldList, int num)
        {
            List<int> result = oldList;

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] == num)
                {
                    result.RemoveAt(i);
                    i = - 1;
                }
            }

            return result;
        }
    }
}
