using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinalExamP2
{
    class ProblemTwo
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Regex rgx = new Regex(@"!([A-Z][a-z]{2,})!:\[([A-Za-z]{8,})\]");

                if (!rgx.IsMatch(input))
                {
                    Console.WriteLine("The message is invalid");
                }
                else
                {
                    Match result = rgx.Match(input);
                    int[] asciiNumbers = result.Groups[2].Value.ToCharArray().Select(x => x + 0).ToArray();
                    string command = result.Groups[1].Value;
                    Console.WriteLine($"{command}: {string.Join(" ", asciiNumbers)}");
                }
            }
        }
    }
}
