using System;
using System.Linq;

namespace ArrayModifier
{
    class ArrayModifier
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();

                if (tokens[0] == "end")
                {
                    break;
                }

                switch (tokens[0])
                {
                    case "swap":
                        SwapTwoElements(numbers, int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                    case "multiply":
                        MultiplyTwoElements(numbers, int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                    case "decrease":
                        DecreaseArraysElements(numbers);
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static long [] DecreaseArraysElements(long [] numbers) 
        {
            long[] result = numbers;

            for (int i = 0; i < result.Length; i++)
            {
                result[i] -= 1;
            }

            return result;
        }
        public static long[] MultiplyTwoElements(long[] numbers, int fisrtIndex, int secondIndex)
        {
            long[] result = numbers;
            long product = numbers[fisrtIndex] * numbers[secondIndex];
            result[fisrtIndex] = product;

            return result;
        }
        public static long[] SwapTwoElements(long[] numbers, int fisrtIndex, int secondIndex)
        {
            long[] result = numbers;

            long temp = numbers[fisrtIndex];
            result[fisrtIndex] = numbers[secondIndex];
            result[secondIndex] = temp;

            return result;
        }
    }
}
