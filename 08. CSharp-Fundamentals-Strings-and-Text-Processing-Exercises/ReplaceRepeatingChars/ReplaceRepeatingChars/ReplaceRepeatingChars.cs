using System;
using System.Collections.Generic;

namespace ReplaceRepeatingChars
{
    class ReplaceRepeatingChars
    {
        static void Main(string[] args)
        {
            string chars = Console.ReadLine();
            List<string> patterns = PatternBuilder(chars);

            foreach (var patern in patterns)
            {
                chars = chars.Replace(patern, patern[0].ToString());
            }

            Console.WriteLine(chars);
        }

        public static List<string> PatternBuilder(string chars) 
        {
            List<string> result = new List<string>();

            for (int i = 0; i < chars.Length; i++)
            {
                string pattern = chars[i].ToString();

                for (int j = i + 1; j < chars.Length; j++)
                {
                    if (chars[i] == chars[j])
                    {
                        pattern += chars[j];
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (pattern.Length > 1 && !result.Contains(pattern))
                {
                    result.Add(pattern);
                }
            }

            return result;

        }
    }
}
