using System;
using System.Collections.Generic;
using System.Linq;

namespace AngryPet
{
    class AngryPet
    {
        static void Main(string[] args)
        {
            List<int> priceRatings = Console.ReadLine().Split().Select(int.Parse).ToList();
            int startIndex = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();
            string typeOfPriceRatings = Console.ReadLine();
            int elementOfEntry = priceRatings[startIndex];
            long leftElementSum = 0;
            long rightElementSum = 0;


            List<int> leftSequence = priceRatings.ToList();
            leftSequence.RemoveRange(startIndex, priceRatings.Count - startIndex);

            List<int> rightSequence = priceRatings.ToList();
            rightSequence.RemoveRange(0, startIndex + 1);
            rightSequence.Take(startIndex);

            if (typeOfPriceRatings == "positive")
            {
                rightSequence = rightSequence.Where(x => x > 0).ToList();
                leftSequence = leftSequence.Where(x => x > 0).ToList();
            }
            else if(typeOfPriceRatings == "negative")
            {
                rightSequence = rightSequence.Where(x => x < 0).ToList();
                leftSequence = leftSequence.Where(x => x < 0).ToList();
            }

            if (typeOfItems == "cheap")
            {
                rightSequence = rightSequence.Where(x => x < elementOfEntry).ToList();
                leftSequence = leftSequence.Where(x => x < elementOfEntry).ToList();
            }
            else
            {
                rightSequence = rightSequence.Where(x => x >= elementOfEntry).ToList();
                leftSequence = leftSequence.Where(x => x >= elementOfEntry).ToList();
            }

            leftElementSum = leftSequence.Sum();
            rightElementSum = rightSequence.Sum();

            if (leftElementSum >= rightElementSum)
            {
                Console.WriteLine($"Left - {leftElementSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightElementSum}");
            }
        }
    }
}
