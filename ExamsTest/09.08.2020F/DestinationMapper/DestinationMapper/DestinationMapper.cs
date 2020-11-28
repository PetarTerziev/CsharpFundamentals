using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex rx = new Regex(@"(?<Delimiter>\=|/)(?<Destination>[A-Z][A-Z,a-z]{2,})\1");

            MatchCollection matches = rx.Matches(input);
            int destinationPoints = 0;

            for (int i = 0; i < matches.Count; i++)
            {
                destinationPoints += matches[i].Groups["Destination"].Value.ToString().Length;
            }
            
            Console.WriteLine($"Destinations: " +
                             $"{string.Join(", ", matches.Select(x => x.Groups["Destination"].Value))}");

            Console.WriteLine($"Travel Points: {destinationPoints}");
        }
    }
}
