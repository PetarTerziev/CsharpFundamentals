using System;

namespace Zig_ZagArrays
{
    class ZigZagArrays
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arrOne = new string[n];
            string[] arrTwo = new string[n];


            for (int i = 0; i < n; i++)
            {
                string[] temp = Console.ReadLine().Split();

                if (i % 2 == 0)
                {
                    arrOne[i] = temp[0];
                    arrTwo[i] = temp[1];
                }
                else
                {
                    arrOne[i] = temp[1];
                    arrTwo[i] = temp[0];
                }
            }

            Console.WriteLine(String.Join(" ", arrOne));
            Console.WriteLine(String.Join(" ", arrTwo));

        }
    }
}
