using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {

            string[] inputDemons = Console.ReadLine().Split(new char[]{',',' '}, StringSplitOptions.RemoveEmptyEntries)
                                                     .ToArray();

            List<Demons> demons = new List<Demons>();

            foreach (var demon in inputDemons)
            {
                Regex rgxLetters = new Regex(@"[^0-9\+\-\*\/\.\s]");
                MatchCollection healthInfo = rgxLetters.Matches(demon);
                int health = healthInfo.Cast<Match>().Select(x => char.Parse(x.Value) + 0).ToList().Sum();
                Regex rgxNumbers = new Regex(@"([-+0-9]*(?:\.[0-9]*)?)");
                MatchCollection damageInfo = rgxNumbers.Matches(demon);
                double damage = damageInfo.Cast<Match>().Select(x =>
                {
                    if (x.Value == "")
                    {
                        return 0;
                    }
                    else
                    {
                        return double.Parse(x.Value);
                    }
                }).ToList().Sum();
                Regex rgxOperations = new Regex(@"[\/\*]");
                string[] operationsInfo = rgxOperations.Matches(demon).Cast<Match>().Select(x => x.Value).ToArray();

                foreach (var operation in operationsInfo)
                {
                    if (operation == "*")
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                demons.Add(new Demons(demon, health, damage));
            }

            Console.WriteLine(string.Join(Environment.NewLine, demons.OrderBy(x => x.Name)));   
        }

        class Demons
        {
            public Demons(string name, int health, double damage)
            {
                this.Name = name;
                this.Health = health;
                this.Damage = damage;
            }
            public string Name { get; set; }
            public int Health { get; set; }
            public double Damage { get; set; }

            public override string ToString()
            {
                return $"{this.Name} - {this.Health} health, {this.Damage:f2} damage"; 
            }
        }
    }
}
