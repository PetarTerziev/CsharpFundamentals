using System;

namespace NtoNMatrix
{
    class NtoNMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                PrintLines(n);
            }
        }

        static void PrintLines(int n) 
        {
            for (int row = 0; row < n; row++)
            {
                Console.Write($"{n} ");
            }

            Console.WriteLine();
        }
    }
}
