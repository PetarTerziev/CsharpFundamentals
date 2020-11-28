using System;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder multiplier = RemoveLeadingZero(new StringBuilder(Console.ReadLine()));
            byte multiplicand = byte.Parse(Console.ReadLine());
            string result = string.Empty;

            if (multiplicand == 0)
            {
                result = "0";  
            }
            else
            {
                result = SumBigIntegers(multiplier, multiplicand).ToString();
            }

            Console.WriteLine(result);
        }

        static public StringBuilder RemoveLeadingZero(StringBuilder multiplier) 
        {
            for (int i = 0; i < multiplier.Length; i++)
            {
                if (multiplier[i] != '0')
                {
                    break;
                }
                else
                {
                    multiplier.Remove(0, 1);
                    i -= 1;
                }
            }

            if (multiplier.Length == 0)
            {
                multiplier.Append(0);
            }
            return multiplier;
        }

        static public StringBuilder SumBigIntegers(StringBuilder multiplier, byte multiplicand)
        {
            int remainder = 0;
            StringBuilder result = new StringBuilder();

            while (multiplier.Length > 0)
            {
                int product = (int.Parse(multiplier[multiplier.Length - 1].ToString()) * multiplicand) + remainder;
                result.Insert(0, product % 10);
                multiplier.Remove(multiplier.Length - 1, 1);
                remainder = product / 10;
            }

            if (remainder > 0)
            {
                result.Insert(0, remainder);

            }

            return result;
        }
    }
}
