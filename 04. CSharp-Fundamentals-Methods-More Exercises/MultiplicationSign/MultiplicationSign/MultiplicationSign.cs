using System;

namespace MultiplicationSign
{
    class MultiplicationSign
    {
        static void Main(string[] args)
        {
            string fisrtNum = Console.ReadLine();
            string secondNum = Console.ReadLine();
            string thirdNum = Console.ReadLine();

            GetProductSign(fisrtNum, secondNum, thirdNum);
        }
        static int MinusCount(string num1, string num2, string num3) 
        {
            string[] numArr = new string[3] { num1, num2, num3 };
            int counterMinuses = 0;

            for (int i = 0; i < numArr.Length; i++)
            {
                if (numArr[i] == "0")
                {
                    return -1;
                }
                else if (numArr[i][0] == '-')
                {
                    counterMinuses++;

                }
            }

            return counterMinuses;
        }
        static void GetProductSign(string num1, string num2, string num3) 
        {
            string message = string.Empty;

            if (MinusCount(num1, num2, num3) == -1)
            {
                message = "zero";
            }
            else if (MinusCount(num1, num2, num3) == 0 || MinusCount(num1, num2, num3) == 2)
            {
                message = "positive";
            }
            else if (MinusCount(num1, num2, num3) == 1 || MinusCount(num1, num2, num3) == 3)
            {
                message = "negative";
            }

            Console.WriteLine(message);
        }
    }
}
