using System;

namespace AsciiSumator
{
    class AsciiSumator
    {
        static void Main(string[] args)
        {
            char firstCh = char.Parse(Console.ReadLine());
            char secondCh = char.Parse(Console.ReadLine());
            string str = Console.ReadLine();

            int sum = 0;

            foreach (var ch in str)
            {
                if (ch > firstCh && ch < secondCh)
                {
                    sum += ch;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
