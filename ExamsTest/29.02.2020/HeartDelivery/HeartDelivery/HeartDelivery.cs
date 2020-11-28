using System;
using System.Linq;
using System.Threading;

namespace HeartDelivery
{
    class HeartDelivery
    {
        static void Main(string[] args)
        {
            int[] housesHearts = Console.ReadLine().Split("@").Select(int.Parse).ToArray();
            byte currentIndex = 0;

            while (true)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string command = input[0];

                if (command == "Love!")
                {
                    break;  
                }

                byte jumpLength = byte.Parse(input[1]);

                if (jumpLength + currentIndex < housesHearts.Length )
                {
                    currentIndex += jumpLength;
                }
                else
                {
                    currentIndex = 0;
                }

                if (housesHearts[currentIndex] == 0)
                {
                    Console.WriteLine($"Place {currentIndex} already had Valentine's day.");
                }
                else
                {
                    housesHearts[currentIndex] -= 2;

                    if (housesHearts[currentIndex] <= 0)
                    {
                        Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                        housesHearts[currentIndex] = 0;
                    }
                }
            }


            Console.WriteLine($"Cupid's last position was {currentIndex}.");

            bool isMissionSuccessful = housesHearts.ToList().Sum() == 0;

            if (isMissionSuccessful)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                int numberOfHouses = housesHearts.ToList().Where(x => x != 0).Count();
                Console.WriteLine($"Cupid has failed {numberOfHouses} places.");
            }
        }
    }
}
