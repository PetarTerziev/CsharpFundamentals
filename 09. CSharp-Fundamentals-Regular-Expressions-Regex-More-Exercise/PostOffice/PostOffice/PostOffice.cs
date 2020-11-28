using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class PostOffice
    {
        static void Main(string[] args)
        {
            string[] inputText = Console.ReadLine().Split("|").ToArray();

            Regex rgxFirstPart = new Regex(@"([#$%&*])([A-Z]+)(\1)");
            string firstPartLetters = rgxFirstPart.Match(inputText[0]).Groups[2].Value.ToString();

            foreach (var letter in firstPartLetters)
            {
                int charCode = letter + 0;

                string tempRgxSecondPart = @"(X:([0-9][0-9]))";
                Regex rgxSecondPart = new Regex(tempRgxSecondPart.Replace("X", charCode.ToString()));
                byte length = byte.Parse(rgxSecondPart.Match(inputText[1]).Groups[2].Value.ToString());

                string[] words = inputText[2].Split().ToArray();

                foreach (var word in words)
                {
                    if (word.Length == length + 1 && word[0] == letter)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}
