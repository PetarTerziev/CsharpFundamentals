using System;
using System.Linq;

namespace Fibonacci
{
    class RecursiveFibonacci
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbersOnRow = new int[n];

            for (int row = 1; row <= n; row++)
            {
                int[] temp = new int[row + 1];

                temp[0] = 0;
                temp[1] = 1;

                for (int col = 1; col < temp.Length - 1; col++)
                {
                    int firstPairPos = col - 1;
                    temp[col + 1] = numbersOnRow[firstPairPos] + numbersOnRow[col];
                }
                numbersOnRow = temp.ToArray();
            }

            Console.WriteLine(numbersOnRow[n]);
        }
    }
}
