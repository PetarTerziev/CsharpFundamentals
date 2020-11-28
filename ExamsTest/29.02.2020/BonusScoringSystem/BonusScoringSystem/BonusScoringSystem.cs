using System;
using System.Collections.Generic;
using System.Linq;

namespace BonusScoringSystem
{
    class BonusScoringSystem
    {
        static void Main(string[] args)
        {
            double studentsCount = double.Parse(Console.ReadLine());
            double lecturesCount = double.Parse(Console.ReadLine());
            int startBonus = int.Parse(Console.ReadLine());

            List<int> attendances = new List<int>();

            for (int i = 0; i < studentsCount; i++)
            {
                attendances.Add(int.Parse(Console.ReadLine()));
            }

            double totalBonus = 0;

            if (attendances.Count > 0 && lecturesCount > 0)
            {
                totalBonus = attendances.Max() / lecturesCount * (startBonus + 5);
            }
            else
            {
                attendances.Add(0);
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(totalBonus)}.");
            Console.WriteLine($"The student has attended {attendances.Max()} lectures.");

        }
    }
}
