using System;

namespace DisneylAndJourney
{
    class DisneylAndJourney
    {
        static void Main(string[] args)
        {
            ushort journeyPrice = ushort.Parse(Console.ReadLine());
            byte months = byte.Parse(Console.ReadLine());
            byte counterMonthsPast = 0;
            decimal savings = 0;

            while (counterMonthsPast < months)
            {
                counterMonthsPast++;

                if (counterMonthsPast % 2 == 1 && counterMonthsPast != 1)
                {
                    savings *= 0.84m;
                }

                if (counterMonthsPast % 4 == 0)
                {
                    savings *= 1.25m;
                }

                savings += journeyPrice * 0.25m;
            }

            decimal money = savings - journeyPrice;

            if (savings >= journeyPrice)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {money:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {Math.Abs(money):f2}lv. more.");
            }
        }
    }
}
