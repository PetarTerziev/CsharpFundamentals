using System;
using System.Linq;

namespace PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            sbyte n = sbyte.Parse(Console.ReadLine());
            int[] numbersOnRow = new int[n];

            for (int row = 0; row < n; row++)
            {
                int[] temp = new int[row + 1];

                temp[0] = 1;

                for (int col = 1; col <= temp.Length - 2; col++)
                {
                    int firstPairPos = col - 1;
                    temp[col] = numbersOnRow[firstPairPos] + numbersOnRow[col];
                }

                temp[temp.Length - 1] = 1;

                Console.WriteLine(String.Join(" ", temp));

                numbersOnRow = temp.ToArray();
            }
        }
    }
}
