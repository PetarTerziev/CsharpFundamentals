using System;

namespace ConsoleApp1
{
    class Program
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

        static int ReturnSmallestValue(int[] numbers)
        {
            int temp = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            return numbers[0];
        }
    }
}
