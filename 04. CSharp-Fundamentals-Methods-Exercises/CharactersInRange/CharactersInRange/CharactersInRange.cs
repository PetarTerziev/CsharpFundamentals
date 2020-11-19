using System;

namespace CharactersInRange
{
    class CharactersInRange
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            GetCharectersInRange(firstChar, secondChar);
        }

        static void GetCharectersInRange(char firstChar, char secondChar)
        {
            char start = SwapPositionsChars(firstChar, secondChar)[0];
            char end = SwapPositionsChars(firstChar, secondChar)[1];

            for (int i = start + 1; i < end; i++)
            {
                Console.Write($"{Convert.ToChar(i)} ");
            }
        }

        static char[] SwapPositionsChars(char firstChar, char secondChar) 
        {
            char[] chArr = new char[2];

            if (secondChar < firstChar)
            {
                chArr[0] = secondChar;
                chArr[1] = firstChar;
            }
            else
            {
                chArr[0] = firstChar;
                chArr[1] = secondChar;
            }

            return chArr;
        }
    }
}
