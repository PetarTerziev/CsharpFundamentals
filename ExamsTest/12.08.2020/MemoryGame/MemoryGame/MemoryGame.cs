using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    class MemoryGame
    {
        static void Main(string[] args)
        {
            List<string> memoryList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int moves = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    if (memoryList.Count != 0)
                    {
                        Console.WriteLine($"Sorry you lose :( \n{string.Join(" ", memoryList)}");
                    }

                    break;
                }

                moves++;

                int[] indexes = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (indexes[0] == indexes[1] || indexes[0] < 0 || indexes[0] >= memoryList.Count
                    || indexes[1] < 0 || indexes[1] >= memoryList.Count)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                    string[] addElementsToMemory = new string[2] { $"-{moves}a", $"-{moves}a" };
                    int middleOfSequence = (memoryList.Count / 2);
                    memoryList.InsertRange(middleOfSequence, addElementsToMemory);
                }
                else if (memoryList[indexes[0]] == memoryList[indexes[1]])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {memoryList[indexes[0]]}!");

                    if (indexes[0] > indexes[1])
                    {
                        memoryList.RemoveAt(indexes[0]);
                        memoryList.RemoveAt(indexes[1]);
                    }
                    else
                    {
                        memoryList.RemoveAt(indexes[1]);
                        memoryList.RemoveAt(indexes[0]);
                    }
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                if (memoryList.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    break;
                }
            }
        }
    }
}
