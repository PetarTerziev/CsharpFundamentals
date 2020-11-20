using System;
using System.Collections.Generic;
using System.Linq;

namespace TaKeskipRope
{
    class TakeSkipRope
    {
        static void Main(string[] args)
        {
            string testString = Console.ReadLine();

            List<int> numbers = new List<int>();
            string nonNumbers = string.Empty;

            for (int i = 0; i < testString.Length; i++)
            {
                int cuurentNum = 0;
                bool success = int.TryParse(testString[i].ToString(), out cuurentNum);
                
                if (success)
                {
                    numbers.Add(cuurentNum);
                }
                else
                {
                    nonNumbers += testString[i];
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
           
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            string message = string.Empty;
            int offset = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                int takeElement = takeList[i];
                int skipElement = skipList[i];

                if (offset + takeElement >= nonNumbers.Length)
                {
                    takeElement = nonNumbers.Length - offset;
                }
                message += nonNumbers.Substring(offset, takeElement);
                offset += takeElement + skipElement;
            }

            Console.WriteLine(message);
        }
    }
}
