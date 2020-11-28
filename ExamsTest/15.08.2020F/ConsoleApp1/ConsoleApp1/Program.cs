using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] delimiters = new char[] { '#', '|' };

            string[] inputSplited = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] inputSplitedBySharp = input.Split('#', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] inputSplitedByVerticalBar = input.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();


            Console.WriteLine(string.Join(" ", inputSplited));
            Console.WriteLine(string.Join(" ", inputSplitedBySharp));
            Console.WriteLine(string.Join(" ", inputSplitedByVerticalBar));

        }
    }
}
