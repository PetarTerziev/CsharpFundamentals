using System;

namespace SoftUniReception
{
    class SoftUniReception
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());

            int totalStudebtsPerH = firstEmployee + secondEmployee + thirdEmployee;
            int hours = 0;

            while (studentsCount > 0)
            {
                hours++;

                if (hours % 4 == 0)
                {
                    continue;
                }

                studentsCount -= totalStudebtsPerH;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
