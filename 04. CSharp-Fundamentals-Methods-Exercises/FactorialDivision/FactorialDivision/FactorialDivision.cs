using System;

namespace FactorialDivision
{
    class FactorialDivision
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            double result = (double)Factorial(x) / (double)Factorial(y);

            Console.WriteLine($"{result:f2}");
        }

        static ulong Factorial(int n) 
        {
            ulong result = 1;

            for (int i = 1; i <= n; i++)
            {
                ulong tepm = result * (ulong)i;
                result = tepm;
            }

            return result;
        }
    }
}
