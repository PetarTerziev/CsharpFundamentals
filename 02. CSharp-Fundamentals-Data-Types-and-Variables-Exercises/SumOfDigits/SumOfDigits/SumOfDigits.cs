using System;

namespace SumOfDigits
{
    class SumOfDigits
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sumOfDig = 0;

            for (int pos = 0; pos < number.Length; pos++)
            {
                sumOfDig += int.Parse(number[pos].ToString());
            }

            Console.WriteLine(sumOfDig);
        }
    }
}
