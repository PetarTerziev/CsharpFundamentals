using System;

namespace Train
{
    class Train
    {
        static void Main(string[] args)
        {
            int numOfWagons = int.Parse(Console.ReadLine());
            int[] train = new int[numOfWagons];
            int sum = 0;

            for (int i = 0; i < numOfWagons; i++)
            {
                train[i] = int.Parse(Console.ReadLine());
                sum += train[i];
            }

            Console.WriteLine(String.Join(" ", train));
            Console.WriteLine(sum);
        }
    }
}
