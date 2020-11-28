using System;

namespace Pirates
{
    class Pirates
    {
        static void Main(string[] args)
        {
            int daysOfPlunder = int.Parse(Console.ReadLine());
            int dailyPlunder = byte.Parse(Console.ReadLine());
            decimal expectedPlunder = decimal.Parse(Console.ReadLine());
            decimal totalPlunder = 0;

            for (int i = 1; i <= daysOfPlunder; i++)
            {
                totalPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    totalPlunder += dailyPlunder * 0.5m;
                }

                if (i % 5 == 0)
                {
                    totalPlunder *= 0.7m;
                }
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                decimal percentage = (totalPlunder / expectedPlunder) * 100;

                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}
