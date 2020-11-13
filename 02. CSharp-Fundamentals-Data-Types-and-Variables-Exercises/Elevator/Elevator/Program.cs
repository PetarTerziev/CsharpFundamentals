using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int pers = int.Parse(Console.ReadLine());
            int cap = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling((double)pers / cap);



            Console.WriteLine(courses);
        }
    }
}
