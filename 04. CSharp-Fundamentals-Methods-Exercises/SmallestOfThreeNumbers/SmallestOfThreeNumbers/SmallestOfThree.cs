using System;

namespace SmallestOfThreeNumbers
{
    class SmallestOfThree
    {
        static void Main(string[] args)
        {
            int[] numbersArr = new int[3];

            for (int i = 0; i < 3; i++)
            {
                numbersArr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(ReturnSmallestValue(numbersArr));
        }

        static int ReturnSmallestValue(int[]numbers) 
        {
            int smallestValue = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {

                if (numbers[i] < smallestValue)
                {
                    smallestValue = numbers[i];
                }
            }

            return smallestValue;
        }
    }
}
