using System;

namespace PokeMon
{
    class PokeMon
    {
        static void Main(string[] args)
        {
            int powerN = int.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
            int exhFactorY = int.Parse(Console.ReadLine());
            int counterPocked = 0;
            double startPower = powerN * 0.5;

            while (powerN >= distanceM)
            {
                powerN -= distanceM;
                counterPocked++;

                if (powerN == startPower && exhFactorY !=0)
                {
                    powerN /= exhFactorY;
                }
            }

            Console.WriteLine($"{powerN}\n{counterPocked}");

        }
    }
}
