using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class EmojiDetector
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex rgxNumbers = new Regex(@"\d");
            MatchCollection numbers = rgxNumbers.Matches(text);
            long coolThresholdSum = numbers.Select(x => int.Parse(x.Value)).Aggregate((a, x) => a * x);
            Regex rgxEmojis = new Regex(@"([:]{2}|[*]{2})([A-Z]{1}[a-z]{2,})\1");
            MatchCollection emojis = rgxEmojis.Matches(text);
            List<string> coolEmos = new List<string>();

            foreach (Match match in emojis)
            {
                long coolnessSum = SumLetters(match.Groups[2].Value);

                if (coolnessSum > coolThresholdSum)
                {
                    coolEmos.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");

            int emojisCount = emojis.Count;

            Console.WriteLine($"{emojisCount} emojis found in the text. The cool ones are:");

            foreach (var emoji in coolEmos)
            {
                Console.WriteLine(emoji);
            }
        }   

        static public long SumLetters(string text) 
        {
            long sum = 0;

            foreach (var letter in text)
            {
                sum += letter + 0;
            }

            return sum;
        }
    }
}
