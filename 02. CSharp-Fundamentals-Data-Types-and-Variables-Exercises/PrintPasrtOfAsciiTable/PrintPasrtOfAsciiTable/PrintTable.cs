using System;

namespace PrintPasrtOfAsciiTable
{
    class PrintTable
    {
        static void Main(string[] args)
        {
            int startPos = int.Parse(Console.ReadLine());
            int endPos = int.Parse(Console.ReadLine());

            for (int i = startPos; i <= endPos; i++)
            {
                Console.Write($"{Convert.ToChar(i)} ");
            }
        }
    }
}
