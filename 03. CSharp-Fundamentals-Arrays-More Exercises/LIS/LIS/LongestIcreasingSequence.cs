using System;
using System.Collections.Generic;
using System.Linq;

namespace LIS
{
    class LongestIcreasingSequence
    {
        static void Main(string[] args)
        {
            int[] sequenceArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] len = new int[sequenceArr.Length];
            int[] prev = new int[sequenceArr.Length];
            int maxLen = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequenceArr.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;
                for (int j = 0; j <= i - 1 ; j++)
                {
                    if (sequenceArr[j] < sequenceArr[i] && len[j] + 1 > len[i])
                    {
                        len[i] = 1 + len[j];
                        prev[i] = j;
                    }
                }

                if (len[i] > maxLen)
                {
                    maxLen = len[i];
                    lastIndex = i;
                }
            }

            var longestSeq = new List<int>();

            while (lastIndex != -1)
            {
                longestSeq.Add(sequenceArr[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestSeq.Reverse();

            Console.WriteLine(String.Join(" ", longestSeq));
        }
    }
}
