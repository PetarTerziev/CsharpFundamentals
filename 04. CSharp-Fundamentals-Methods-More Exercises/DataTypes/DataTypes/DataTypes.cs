using System;

namespace DataTypes
{
    class DataTypes
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string input = Console.ReadLine();

            if (type == "int")
            {
                Console.WriteLine(ReturnData(int.Parse(input)));
            }
            else if (type == "real")
            {
                Console.WriteLine($"{ReturnData(double.Parse(input)):f2}");
            }
            else
            {
                Console.WriteLine(ReturnData(input));
            }
        }

        static int ReturnData(int a) 
        {
            return a * 2;
        }
        static double ReturnData(double a)
        {
            return a * 1.5;
        }

        static string ReturnData(string a)
        {
            return $"${a}$";
        }
    }
}
