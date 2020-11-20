using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class MixedUpLists
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool isfirstListSmaller = firstList.Count < secondList.Count ? true : false;
            int minCount = isfirstListSmaller ? firstList.Count : secondList.Count;
            List<int> mixedList = new List<int>();
            List<int> constrainsNums = new List<int>();

            for (int i = 0; i < minCount + 2; i++)
            {
                if (i < minCount)
                {
                    mixedList.Add(firstList[i]);
                    mixedList.Add(secondList[secondList.Count - 1 - i]);
                }
                else
                {
                    if (!isfirstListSmaller)
                    {
                        constrainsNums.Add(firstList[i]);
                    }
                    else
                    {
                        constrainsNums.Add(secondList[secondList.Count - 1 - i]);
                    }
                }
                
            }

            List<int> filteredList = new List<int>();

            foreach (var num in mixedList)
            {
                constrainsNums.Sort();

                if (num > constrainsNums[0] && num < constrainsNums[1])
                {
                    filteredList.Add(num);
                }
            }

            filteredList.Sort();

            Console.WriteLine(string.Join(" ", filteredList));

        }
    }
}
