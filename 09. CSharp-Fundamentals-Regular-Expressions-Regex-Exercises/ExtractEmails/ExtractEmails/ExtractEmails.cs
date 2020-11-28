using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            Regex rgx = new Regex(@"((?<=\s)[A-Za-z0-9]+([.-]\w*)*@[A-Za-z]+([.-][A-Za-z]*)*(\.[a-z]{2,}))");

            MatchCollection validEmails = rgx.Matches(inputText);

            foreach (Match macth in validEmails)
            {
                Console.WriteLine(macth.Value);
            }
        }
    }
}
