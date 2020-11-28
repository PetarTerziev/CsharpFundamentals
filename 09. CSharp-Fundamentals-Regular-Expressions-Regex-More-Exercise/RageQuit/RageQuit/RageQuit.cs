using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex rgx = new Regex(@"(\D+)(\d+)");
            MatchCollection ragePairs = rgx.Matches(text);
            StringBuilder result = new StringBuilder();
            List<char> uniqueChars = new List<char>();


            foreach (Match pair in ragePairs)
            {
                string strToRepeat = pair.Groups[1].Value.ToUpper();
                byte n = byte.Parse(pair.Groups[2].Value);

                if (n > 0)
                {
                    foreach (var ch in strToRepeat)
                    {
                        if (!uniqueChars.Contains(ch))
                        {
                            uniqueChars.Add(ch);
                        }
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    result.Append(strToRepeat);
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueChars.Count}");
            Console.WriteLine(result);
        }
    }
}
