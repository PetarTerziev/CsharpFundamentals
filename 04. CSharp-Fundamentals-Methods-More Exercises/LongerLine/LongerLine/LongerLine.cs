using System;

namespace LongerLine
{
    class LongerLine
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            GetLongestLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        static void GetLongestLine(double x1, double y1, double x2, double y2,
                                    double x3, double y3, double x4, double y4)
        {
            if (GetDistanceBetweenTwoPoint(x1, y1, x2, y2) >= GetDistanceBetweenTwoPoint(x3, y3, x4, y4))
            {
                GetClosestPoint(x1, y1, x2, y2);
            }
            else
            {
                GetClosestPoint(x3, y3, x4, y4);
            }
        }
        static void GetClosestPoint(double x1, double y1, double x2, double y2)
        {
            string message = string.Empty;
              
            if (GetDistanceBetweenTwoPoint(x1, y1, 0, 0) <= GetDistanceBetweenTwoPoint(x2, y2, 0, 0))
            {
                message = $"({x1}, {y1})({x2}, {y2})";
            }
            else
            {
                message = $"({x2}, {y2})({x1}, {y1})";
            }

            Console.WriteLine(message);
        }
        static double GetDistanceBetweenTwoPoint(double x1, double y1, double x2, double y2)
        {

            double diffX = x2 - x1;
            double diffY = y2 - y1;

            return Math.Sqrt(Math.Pow(diffX,2) + Math.Pow(diffY, 2));
        }
    }
}
