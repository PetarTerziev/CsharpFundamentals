using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class AppendArrays
    {
        static void Main(string[] args)
        {
            List<string> numList = Console.ReadLine().Split("|").ToList();

            for (int i = numList.Count - 1; i >= 0; i--)
            {
                string [] subList = numList[i]
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in subList)
                {
                    Console.Write($"{item} ");
                }
            }
        }
    }
}
