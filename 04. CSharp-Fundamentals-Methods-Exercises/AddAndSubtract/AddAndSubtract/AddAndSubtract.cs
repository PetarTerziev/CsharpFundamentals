using System;

namespace AddAndSubtract
{
    class AddAndSubtract
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());

            Console.WriteLine(Subtract(Sum(x, y), z));
        }
        static int Sum(int x, int y) 
        {
            return x + y;
        }
        static int Subtract(int x, int y)
        {
            return x - y;
        }
    }
}
