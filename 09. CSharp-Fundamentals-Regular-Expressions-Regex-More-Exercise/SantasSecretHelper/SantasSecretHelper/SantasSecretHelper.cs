using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SantasSecretHelper
{
    class SantasSecretHelper
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "end")
            {
                string message = DecryptMessage(input, n);
                Regex rgx = new Regex(@"@([A-Za-z]+)(?:[^@\-!:>]*)!([GN])!");

                if (rgx.IsMatch(message))
                {
                    Match kidInfo = rgx.Match(message);
                    string kidName = kidInfo.Groups[1].Value;
                    bool isNaughty = kidInfo.Groups[2].Value == "N";

                    if (!isNaughty)
                    {
                        Console.WriteLine(kidName);
                    }
                }

                input = Console.ReadLine();

            }
        }
        static public string DecryptMessage(string message, byte secretNumber) 
        {
            StringBuilder result = new StringBuilder();

            foreach (var letter in message)
            {
                result.Append(Convert.ToChar(letter - secretNumber));
            }

            return result.ToString();
        }
    }
}
