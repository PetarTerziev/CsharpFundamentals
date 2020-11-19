using System;

namespace MiddleCharecters
{
    class MiddleCharecters
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            GetMiddleChars(str);
        }

        static void GetMiddleChars(string str) 
        {
            string result = string.Empty;
            int len = str.Length;

            if (len % 2 == 0)
            {
               result = $"{str[len / 2 - 1]}{str[len / 2]}";
            }
            else
            {
                result = $"{str[len / 2]}";
            }

            Console.WriteLine(result);
        }
    }
}
