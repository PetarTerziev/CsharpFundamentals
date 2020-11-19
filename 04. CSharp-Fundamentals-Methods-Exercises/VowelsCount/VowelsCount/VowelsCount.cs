using System;

namespace VowelsCount
{
    class VowelsCount
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(CountVowes(str));
        }

        static int CountVowes(string str) 
        {
            int countOfStr = 0;

            for (int i = 0; i < str.Length; i++)
            {
                string letter = str[i].ToString().ToLower();

                if (letter == "a" || letter == "e" || letter == "i" || letter == "o" || letter == "u")
                {
                    countOfStr++;
                }
            }

            return countOfStr;
        }
    }
}
