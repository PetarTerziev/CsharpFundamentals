using System;
namespace CenterPoint
{
    class CenterPoint
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            GetClosestPair(x1, y1, x2, y2);
        }

        static void GetClosestPair(double x1, double y1, double x2, double y2) 
        {
            string message = string.Empty;
            double firstPairC = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            double secondPairC = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));

            if (firstPairC <= secondPairC)
            {
                message = $"({x1}, {y1})";
            }
            else
            {
                message = $"({x2}, {y2})";
            }

            Console.WriteLine(message);
        }
    }
}
