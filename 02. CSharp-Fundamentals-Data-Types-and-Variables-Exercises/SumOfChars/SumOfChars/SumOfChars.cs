using System;

namespace SumOfChars
{
    class SumOfChars
    {
        static void Main(string[] args)
        {
            int numOfLoops = int.Parse(Console.ReadLine());
            int sum = 0; 

            for (int i = 1; i <= numOfLoops; i++)
            {
                sum += char.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
