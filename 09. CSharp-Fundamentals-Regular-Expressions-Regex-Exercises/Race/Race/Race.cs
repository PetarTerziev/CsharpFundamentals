using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Race
{
    class Race
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racersResults = new Dictionary<string, int>();
            string[] racersNames = Console.ReadLine().Split(", ").ToArray();

            foreach (var name in racersNames)
            {
                racersResults.Add(name, 0);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                Regex rgxLetters = new Regex(@"[A-Za-z]");
                Regex rgxNums = new Regex(@"\d");


                MatchCollection nums = rgxNums.Matches(input);
                MatchCollection letters = rgxLetters.Matches(input);

                int sum = nums.Cast<Match>().Sum(x => int.Parse(x.Value));
                StringBuilder name = new StringBuilder();

                foreach (var letter in letters)
                {
                    name.Append(letter);
                }

                if (racersResults.ContainsKey(name.ToString()))
                {
                    racersResults[name.ToString()] += sum; 
                }
            }

            int counter = 0;

            foreach (var racer in racersResults.OrderByDescending(x => x.Value).Take(3))
            {
                counter++;
                string[] postFix = new string[4] {"", "st", "nd", "rd"};

                Console.WriteLine($"{counter}{postFix[counter]} place: {racer.Key}");
            }
        }
    }
}
