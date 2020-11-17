using System;
using System.Linq;

namespace KaminoFactory
{
    class KaminoFactory
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int bestLength = 1;
            int bestStartIndex = 0;
            int BestDnaSum = 0;
            int linesCounter = 0;
            int bestDnaIndex = 0;
            int[] bestDna = new int[n];

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    break;
                }

                int[] currentDna = input.Split('!', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();
                linesCounter++;

                int length = 1;
                int bestCurrentDnLenght = 1;
                int startIndex = 0;
                int currentDnaSum = 0;

                for (int i = 0; i < currentDna.Length - 1; i++)
                {
                    if (currentDna[i] == currentDna[i + 1])
                    {
                        length++;
                    }
                    else
                    {
                        length = 1;
                    }

                    if (length > bestCurrentDnLenght)
                    {
                        bestCurrentDnLenght = length;
                        startIndex = i;
                    }

                    currentDnaSum += currentDna[i];
                }

                currentDnaSum += currentDna[n - 1];

                if (bestCurrentDnLenght > bestLength)
                {
                    bestLength = bestCurrentDnLenght;
                    bestStartIndex = startIndex;
                    BestDnaSum = currentDnaSum;
                    bestDnaIndex = linesCounter;
                    bestDna = currentDna.ToArray();
                }
                else if (bestCurrentDnLenght == bestLength)
                {
                    if (startIndex < bestStartIndex)
                    {
                        bestLength = bestCurrentDnLenght;
                        bestStartIndex = startIndex;
                        BestDnaSum = currentDnaSum;
                        bestDnaIndex = linesCounter;
                        bestDna = currentDna.ToArray();
                    }
                    else if (startIndex == bestStartIndex)
                    {
                        if (currentDnaSum > BestDnaSum)
                        {
                            bestLength = bestCurrentDnLenght;
                            bestStartIndex = startIndex;
                            BestDnaSum = currentDnaSum;
                            bestDnaIndex = linesCounter;
                            bestDna = currentDna.ToArray();
                        }
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {bestDnaIndex} with sum: {BestDnaSum}.");
            Console.WriteLine(String.Join(" ", bestDna));
        }
    }
}
