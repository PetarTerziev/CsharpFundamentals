using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace MirrorWords
{
    class MirrorWords
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex rgx = new Regex(@"([@]|[#]){1}([A-Za-z]{3,})(\1)(\1)([A-Za-z]{3,})(\1)");


            if (!rgx.IsMatch(input))
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                MatchCollection words = rgx.Matches(input);

                int validPairsCount = words.Count;
                Console.WriteLine($"{validPairsCount} word pairs found!");
                List<string> mirrorWords = new List<string>();

                foreach (Match match in words)
                {
                    string firstWord = match.Groups[2].Value;
                    string secondWord = ReverseString(match.Groups[5].Value);

                    if (firstWord == secondWord)
                    {
                        mirrorWords.Add($"{firstWord} <=> {match.Groups[5].Value}");
                    }

                }

                if (mirrorWords.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");
                    Console.Write(String.Join(", ", mirrorWords));                    
                }
            }
        }

        public static string ReverseString(string input) 
        {
            string result = input.Select(x => x.ToString())
                                                       .Reverse()
                                                       .Aggregate((a, b) => a + b);

            return result;
        }
    }
}
