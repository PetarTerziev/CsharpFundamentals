using System;

namespace TopNumber
{
    class TopNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            GetTopNumbers(n);
        }

        static bool IsOneOddDigit(int num)
        {
            string input = num.ToString();

            for (int i = 0; i < input.Length; i++)
            {
                int n = int.Parse(input[i].ToString());

                if (n % 2 != 0)
                {
                    return true;
                }
            }
            return false;
        }
        static bool IsDivisbleByEight(int num)
        {
            string input = num.ToString();
            int sum = 0;    

            for (int i = 0; i < input.Length; i++)
            {
                int temp = num;
                sum += temp % 10;
                num /= 10;
            }
            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }

        static void GetTopNumbers(int num) 
        {
            for (int i = 16; i <= num; i++)
            {
                if (IsDivisbleByEight(i) && IsOneOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
