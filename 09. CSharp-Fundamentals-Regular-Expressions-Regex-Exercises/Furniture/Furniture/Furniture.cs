using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Furniture
    {
        static void Main(string[] args)
        {
            List<string> boughtFurniture = new List<string>();
            decimal totalAmount = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Purchase")
                {
                    break;
                }

                Regex rgx = new Regex(@">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)");

                if (rgx.IsMatch(input))
                {
                    Match furniture = rgx.Match(input);
                    string keyName = furniture.Groups["name"].Value;
                    decimal amount = decimal.Parse(furniture.Groups["price"].Value) 
                        * decimal.Parse(furniture.Groups["quantity"].Value);
                    totalAmount += amount;
                    boughtFurniture.Add(keyName);
                }
            }

            Console.WriteLine($"Bought furniture:");
            if (boughtFurniture.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, boughtFurniture));
            }
            Console.WriteLine($"Total money spend: {totalAmount:f2}");
        }
    }
}
