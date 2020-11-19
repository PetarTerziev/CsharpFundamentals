using System;

namespace PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                Console.WriteLine(IsPalindrome(input).ToString().ToLower());
            }
        }

        static bool IsPalindrome(string input) 
        {
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] == input[input.Length - 1 - i])
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
