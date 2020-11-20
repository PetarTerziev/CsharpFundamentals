using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDoNotGo
{
    class PokemonDoNotGo
    {
        static void Main(string[] args)
        {
            List<long> numsList = Console.ReadLine().Split().Select(long.Parse).ToList();
            long sum = 0;

            while (numsList.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                long removedNum = 0;

                if (index < 0)
                {
                    index = 0;
                    removedNum = numsList[index];
                    numsList[index] = numsList[numsList.Count - 1];
                }
                else if (index >= numsList.Count)
                {
                    index = numsList.Count - 1;
                    removedNum = numsList[index];
                    numsList[index] = numsList[0];
                }
                else
                {
                    removedNum = numsList[index];
                    numsList.RemoveAt(index);
                }

                for (int i = 0; i < numsList.Count; i++)
                {
                    if (numsList[i] <= removedNum)
                    {
                        numsList[i] += removedNum;
                    }
                    else if(numsList[i] > removedNum)
                    {
                        numsList[i] -= removedNum;
                    }
                }

                sum += removedNum;
            }

            Console.WriteLine(sum);
        }
    }
}
