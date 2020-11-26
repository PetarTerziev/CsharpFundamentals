using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            Dictionary<char, int> chCounter = new Dictionary<char, int>();

            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (!chCounter.ContainsKey(word[i]))
                    {
                        chCounter.Add(word[i], 1);
                    }
                    else
                    {
                        chCounter[word[i]]++;
                    }
                }
            }

            foreach (var pair in chCounter)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
