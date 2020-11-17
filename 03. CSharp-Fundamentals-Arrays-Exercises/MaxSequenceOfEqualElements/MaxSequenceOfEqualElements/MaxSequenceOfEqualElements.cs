using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int [] numbersArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int startPosOfEquality = 0;
            int endPosOfEquality = 0;

            for (int i = 0; i < numbersArr.Length; i++)
            {
                int startPosTemp = i;
                int endPosTemp = 0;

                for (int j = i + 1; j < numbersArr.Length; j++)
                {
                    if (numbersArr[i] != numbersArr[j])
                    {
                        break;
                    }
                    else
                    {
                        endPosTemp = j;
                    }
                }

                if (endPosTemp - startPosTemp > 0 && (endPosTemp - startPosTemp) > (endPosOfEquality - startPosOfEquality))
                {
                    startPosOfEquality = startPosTemp;
                    endPosOfEquality = endPosTemp;
                }
            }

            for (int i = startPosOfEquality; i <= endPosOfEquality; i++)
            {
                Console.Write($"{numbersArr[i]} ");
            }
        }
    }
}
