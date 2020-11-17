using System;
using System.Linq;

namespace EqualSums
{
    class EqualSums
    {
        static void Main(string[] args)
        {
            int[] numbersArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isEqualElements = false;
            string posOfEqualElemenst = string.Empty;

            for (int i = 0; i < numbersArr.Length; i++)
            {
                int sumLeft = 0;
                int sumRight = 0;

                for (int j = 0; j < i; j++)
                {
                    sumLeft += numbersArr[j];
                }

                for (int k = i + 1; k < numbersArr.Length; k++)
                {
                    sumRight += numbersArr[k];
                }

                if (sumLeft == sumRight)
                {
                    isEqualElements = true;
                    posOfEqualElemenst = i.ToString();
                    break;
                }
            }

            if (isEqualElements)
            {
                Console.WriteLine(posOfEqualElemenst);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
