using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class WinningTicket
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[2] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine($"invalid ticket");
                }
                else
                {
                    Regex rgxJackpot = new Regex(@"(([#]{20})|([\^]{20})|([@]{20})|([$]{20}))");

                    if (rgxJackpot.IsMatch(ticket))
                    {
                        char winningChar = rgxJackpot.Match(ticket).Value[0];

                        Console.WriteLine($"ticket \"{ticket}\" - 10{winningChar} Jackpot!");

                        continue;
                    }

                    Regex rgxSixWins = new Regex(@"([@]{6,}|[\$]{6,}|[\^]{6,}|[#]{6,}).+(\1)");
                    Match result = rgxSixWins.Match(ticket);

                    if (rgxSixWins.IsMatch(ticket) && result.Groups[1].Value == result.Groups[2].Value)
                    {
                        char winningChar = result.Groups[1].Value[0];

                        Console.WriteLine($"ticket \"{ticket}\" - {result.Groups[1].Value.Count()}{winningChar}");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
            }
        }
    }
}
