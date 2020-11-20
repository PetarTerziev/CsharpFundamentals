using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class ListOperations
    {
        static void Main(string[] args)
        {
            List<string> numbers = ReadNewLine();

            while (true)
            {
                string[] input = Console.ReadLine().Split().ToArray();


                if (input[0] == "End")
                {
                    break;
                }

                if (IsIndexOutOfRange(numbers, input))
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    ManipulateListsByGivenCommands(numbers, input);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        static List<string> ManipulateListsByGivenCommands(List<string> numbers, string[] tokens)
        {
            List<string> result = numbers;

            switch (tokens[0])
            {
                case "Add":
                    result.Add(tokens[1]);
                    break;
                case "Remove":
                    result.RemoveAt(int.Parse(tokens[1]));
                    break;
                case "Insert":
                    result.Insert(int.Parse(tokens[2]), tokens[1]);
                    break;
                case "Shift":
                    result = ShiftListByGivenCount(numbers, tokens[1], int.Parse(tokens[2]));
                    break;
            }

            return result;
        }
        static List<string> ShiftListByGivenCount(List<string> numbers, string direction, int count)
        {
            List<string> result = numbers;

            if (direction == "left")
            {
                for (int i = 0; i < count; i++)
                {
                    result.Add(result[0]);
                    result.RemoveAt(0);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    result.Insert(0, result[result.Count - 1]);
                    result.RemoveAt(result.Count - 1);
                }
            }
            
            return result;
        }

        static bool IsIndexOutOfRange(List<string> numbers, string[] tokens) 
        {
            if (tokens[0] == "Insert" && (int.Parse(tokens[2]) < 0 || int.Parse(tokens[2]) > numbers.Count - 1))
            {
                return true;
            }
            else if (tokens[0] == "Remove" && (int.Parse(tokens[1]) < 0 || int.Parse(tokens[1]) > numbers.Count - 1))
            {
                return true;
            }
            return false;
        }
        static List<string> ReadNewLine()
        {
            List<string> numsList = Console.ReadLine().Split().ToList();

            return numsList;
        }
    }
}
