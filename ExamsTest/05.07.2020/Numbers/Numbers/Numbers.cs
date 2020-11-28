using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            double average = (double)numbers.Sum() / numbers.Count;

            var newFilterList = numbers.Where(x => x > average).OrderByDescending(x => x).ToList();

            if (newFilterList.Count >= 1 && newFilterList.Count < 5)
            {
                Console.WriteLine(string.Join(" ", newFilterList));
            }
            else if (newFilterList.Count >= 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{newFilterList[i]} ");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
