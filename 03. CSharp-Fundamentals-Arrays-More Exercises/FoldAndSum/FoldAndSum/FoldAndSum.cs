using System;
using System.Linq;

namespace FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] numbersArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numFoldArrBeg = new int[numbersArr.Length / 4];
            int[] numFoldArrEnd = new int[numbersArr.Length / 4];
            int[] sumArrBeg = new int[numbersArr.Length / 4];
            int[] sumArrEnd = new int[numbersArr.Length / 4];

            int foldIndex = numbersArr.Length / 4;

            for (int i = 0; i <= numbersArr.Length / 4 ; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < foldIndex; j++)
                    {
                        numFoldArrBeg[j] = numbersArr[j + i];
                        numFoldArrEnd[j] = numbersArr[j + numbersArr.Length - foldIndex];
                    }

                    Array.Reverse(numFoldArrBeg);
                    Array.Reverse(numFoldArrEnd);

                }
                else if (i == 1)
                {
                    for (int j = 0; j < foldIndex; j++)
                    {
                        sumArrBeg[j] = numFoldArrBeg[j] + numbersArr[j + foldIndex];
                        sumArrEnd[j] = numFoldArrEnd[j] + numbersArr[j + numbersArr.Length/2];

                    }

                    Console.Write($"{String.Join(" ", sumArrBeg)} {String.Join(" ", sumArrEnd)}");
                }
            }

        }
    }
}
