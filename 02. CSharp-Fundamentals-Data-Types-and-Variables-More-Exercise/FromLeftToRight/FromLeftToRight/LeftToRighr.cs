using System;

namespace FromLeftToRight
{
    class LeftToRighr
    {
        static void Main(string[] args)
        {
            int numOfKines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numOfKines; i++)
            {
                string[] numbers = Console.ReadLine().Split(' ');
                long leftNumber = long.Parse(numbers[0]);
                long rightNumber = long.Parse(numbers[1]);

                if (leftNumber > rightNumber)
                {
                    Console.WriteLine(SumPosition(Math.Abs(leftNumber).ToString()));
                }
                else
                {
                    Console.WriteLine(SumPosition(Math.Abs(rightNumber).ToString()));
                }
            }
        }

        static int SumPosition(string numbersAsText) 
        {
            int sum = 0;

            foreach (char pos in numbersAsText)
            {
                sum += int.Parse(pos.ToString());
            }

            return sum;
        }
    }
}
