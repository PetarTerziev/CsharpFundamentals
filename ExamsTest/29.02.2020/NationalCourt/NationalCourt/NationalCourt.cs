using System;

namespace NationalCourt
{
    class NationalCourt
    {
        static void Main(string[] args)
        {
            int employeeOne = int.Parse(Console.ReadLine());
            int employeeTwo = int.Parse(Console.ReadLine());
            int employeeThree = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            int totalWorkingPerH = employeeOne + employeeTwo + employeeThree;
            int hoursCounter = 0;

            while (peopleCount > 0)
            {
                hoursCounter++;

                if (hoursCounter % 4 == 0)
                {
                    continue;
                }

                peopleCount -= totalWorkingPerH;
            }

            Console.WriteLine($"Time needed: {hoursCounter}h.");

        }
    }
}
