using System;
using System.Linq;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            double sum = 0;

            foreach (var str in input)
            {
                char startLetter = str[0];
                char lastLetter = str[str.Length - 1];
                double number = double.Parse(str.Substring(1, str.Length - 2));
                double result = 0;


                if (char.IsUpper(startLetter))
                {
                    number /= startLetter - 64;
                }
                else if (char.IsLower(startLetter))
                {
                    number *= startLetter - 96;
                }

                if (char.IsUpper(lastLetter))
                {
                    number -= lastLetter - 64;
                }
                else if (char.IsLower(lastLetter))
                {
                    number += lastLetter - 96;
                }

                sum += number;
            }

            sum = Math.Round(sum, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine($"{sum:f2}");
        }
    }
}
