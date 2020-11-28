using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            string input = Console.ReadLine();

            List<string> allMatches = new List<string>();

            double money = 0;

            while (input != "Purchase")
            {
                if (Regex.IsMatch(input, regex))
                {
                    Match match = Regex.Match(input, regex);

                    var type = match.Groups["name"].ToString();
                    money += double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);
                    allMatches.Add(type);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Bought furniture: ");

            if (allMatches.Count > 0)
            {
                foreach (var item in allMatches)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine($"Total money spend: {money:f2}");
        }
    }
}