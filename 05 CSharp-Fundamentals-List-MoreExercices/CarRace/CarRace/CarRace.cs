using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class CarRace
    {
        static void Main(string[] args)
        {
            List<double> numsList = Console.ReadLine().Split().Select(double.Parse).ToList();
            double timeLeftCar = 0;
            double timeRightCar = 0;

            for (int i = 0; i < numsList.Count / 2; i++)
            {
                timeLeftCar += numsList[i];
                timeRightCar += numsList[numsList.Count - 1 - i];

                if (numsList[i] == 0)
                {
                    timeLeftCar *= 0.8;
                }

                if (numsList[numsList.Count - 1 - i] == 0)
                {
                    timeRightCar *= 0.8;
                }
            }

            string message = string.Empty;

            if (timeLeftCar < timeRightCar)
            {
                message = $"The winner is left with total time: {timeLeftCar}";
            }
            else
            {
                message = $"The winner is right with total time: {timeRightCar}";
            }

            Console.WriteLine(message);
        }
    }
}
