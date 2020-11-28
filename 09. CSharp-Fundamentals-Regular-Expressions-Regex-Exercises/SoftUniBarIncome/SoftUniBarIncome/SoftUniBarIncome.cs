using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class SoftUniBarIncome
    {
        static void Main(string[] args)
        {
            Regex rgx = new Regex(@"\%(?<customerName>[A-Z][a-z]+)\%(?:.*?)\<(?<product>\w+)\>(?:.*?)\|(?<count>\d+)\|(?:.*?)(?<price>\d+\.?\d*)(?:\$)");

            decimal totalIncome = 0;

            string input = Console.ReadLine();

            Match test = rgx.Match(input);

            while (input != "end of shift")
            {
                if (rgx.IsMatch(input))
                {
                    Match orderInfoMatch = rgx.Match(input);

                    decimal income = int.Parse(orderInfoMatch.Groups["count"].Value)
                                                * decimal.Parse(orderInfoMatch.Groups["price"].Value);

                    Console.WriteLine($"{orderInfoMatch.Groups["customerName"].Value}: " +
                                    $"{orderInfoMatch.Groups["product"].Value} - " +
                                    $"{income:f2}");
                    totalIncome += income;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
