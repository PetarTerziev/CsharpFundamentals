using System;
using System.Linq;

namespace MgicSum
{
    class MgicSum
    {
        static void Main(string[] args)
        {
            int [] numbersArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int magicNumber = int.Parse(Console.ReadLine());

            bool[] isMagicNum = new bool[numbersArr.Length];

            for (int i = 0; i < isMagicNum.Length; i++)
            {
                isMagicNum[i] = false;
            }

            for (int i = 0; i < numbersArr.Length; i++)
            {
                for (int j = i + 1; j < numbersArr.Length; j++)
                {
                    if (numbersArr[i] + numbersArr[j] == magicNumber && isMagicNum[i] == false 
                        && isMagicNum[j] == false)
                    {
                        Console.WriteLine($"{numbersArr[i]} {numbersArr[j]}");
                        isMagicNum[i] = isMagicNum[j] = true;
                        break;
                    }
                }
            }
        }
    }
}
