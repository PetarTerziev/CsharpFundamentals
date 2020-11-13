using System;

namespace WaterOverflow
{
    class WaterOverflow
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 0;

            for (int i = 1; i <= n; i++)
            {
                int waterL = int.Parse(Console.ReadLine());

                if (capacity + waterL <= 255)
                {
                    capacity += waterL;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(capacity);
        }
    }
}
