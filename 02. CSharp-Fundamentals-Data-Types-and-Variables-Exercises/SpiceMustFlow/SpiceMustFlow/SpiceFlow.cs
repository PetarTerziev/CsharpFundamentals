using System;

namespace SpiceMustFlow
{
    class SpiceFlow
    {
        static void Main(string[] args)
        {
            int daylyYield = int.Parse(Console.ReadLine());
            ulong extractedAmount = 0;
            int counterDays = 0;

            while (daylyYield >= 100)
            {
                counterDays++;
                extractedAmount += (ulong)daylyYield;
                daylyYield -= 10;
                extractedAmount += (ulong)DailyAllowences(extractedAmount >= 26);
            }

            extractedAmount += (ulong)DailyAllowences(extractedAmount >= 26);

            Console.WriteLine($"{counterDays}\n{extractedAmount}");

            
        }
        static int DailyAllowences(bool isValid)
        {
            if (isValid)
            {
                return -26;
            }

            return 0;
        }
    }
}
