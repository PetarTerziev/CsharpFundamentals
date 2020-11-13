using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string kegWinner = string.Empty;
            double biigestKegV = 0;

            for (int i = 1; i <= n; i++)
            {
                string kegName = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double currentV = Math.PI * radius * radius * height;

                if (currentV > biigestKegV)
                {
                    kegWinner = kegName;
                    biigestKegV = currentV;
                }
            }

            Console.WriteLine(kegWinner);
        }
    }
}
