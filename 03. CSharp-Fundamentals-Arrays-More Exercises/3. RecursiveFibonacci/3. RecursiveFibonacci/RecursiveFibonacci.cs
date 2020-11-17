using System;

namespace _3._RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(getFibonacci(n));
        }
        private static long getFibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return getFibonacci(n - 1) + getFibonacci(n - 2);
        }
    }
}
