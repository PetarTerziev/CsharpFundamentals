using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class StarEnigma
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();


            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                Regex rgx = new Regex(@"[starSTAR]");
                int secretCount = rgx.Matches(message).ToArray().Count();
                message = DecryptMessage(message, secretCount);
                Regex rgxMessage =
                    new Regex(@"\@([A-Za-z]+)(?:[^@\-!:>]*):(\d+)(?:[^@\-!:>]*)!([AD])!(?:[^@\-!:>]*)->(\d+)(?:[^@\-!:>]*)");
                

                if (rgxMessage.IsMatch(message))
                {
                    Match attackMessage = rgxMessage.Match(message);
                    string planetName = attackMessage.Groups[1].Value;
                    string attackType = attackMessage.Groups[3].Value;

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            int countAttackedPlanets = attackedPlanets.Count == 0 ? 0 : attackedPlanets.Count;
            int countDestroyedPlanets = destroyedPlanets.Count == 0 ? 0 : destroyedPlanets.Count;


            Console.WriteLine($"Attacked planets: {countAttackedPlanets}");
            foreach (var planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {countDestroyedPlanets}");
            foreach (var planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }


        static public string DecryptMessage(string message, int codeBreaker)
        {
            StringBuilder result = new StringBuilder();
            foreach (var ch in message)
            {
                char newCh = Convert.ToChar(ch - codeBreaker);

                result.Append(newCh);
            }

            return result.ToString();
        }
    }
}
