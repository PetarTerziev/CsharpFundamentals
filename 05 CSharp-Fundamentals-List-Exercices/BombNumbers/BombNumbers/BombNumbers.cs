using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> numList= Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bombList = Console.ReadLine().Split().Select(int.Parse).ToList();

            BombDetonator(numList, bombList);

            Console.WriteLine(numList.Sum());
        }

        static List<int> BombDetonator(List<int> listToDetonate, List<int> detonator) 
        {
            List<int> result = listToDetonate;

            while (listToDetonate.Contains(detonator[0]))
            {
                int indexBombedNumber = result.IndexOf(detonator[0]);
                int lengthOfBombRight = indexBombedNumber + detonator[1]
                                      >= result.Count
                                      ? result.Count - 1 - indexBombedNumber : detonator[1];

                int lengthOfBombLeft = indexBombedNumber - detonator[1]
                                        < 0 ? indexBombedNumber : detonator[1];

                result.RemoveRange(indexBombedNumber + 1, lengthOfBombRight);
                result.RemoveRange(indexBombedNumber - lengthOfBombLeft, lengthOfBombLeft + 1);
            }

            return result;
        }
    }
}
