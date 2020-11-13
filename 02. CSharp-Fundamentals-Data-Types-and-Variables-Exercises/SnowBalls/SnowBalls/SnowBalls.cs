using System;
using System.Numerics;
namespace SnowBalls
{
    class SnowBalls
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int bestSnow = 0;
            int bestTime = 0;
            int bestQuality = 0;
            BigInteger bestBall = 0;

            for (int i = 1; i <= n ; i++)
            {
                int snow = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());
                BigInteger currentBall = BigInteger.Pow(snow / time, quality);

                if (currentBall > bestBall)
                {
                    bestSnow = snow;
                    bestTime = time;
                    bestQuality = quality;
                    bestBall = currentBall;
                }
            }

            Console.WriteLine($"{bestSnow} : {bestTime} = {bestBall} ({bestQuality})");

            
        }
    }
}
