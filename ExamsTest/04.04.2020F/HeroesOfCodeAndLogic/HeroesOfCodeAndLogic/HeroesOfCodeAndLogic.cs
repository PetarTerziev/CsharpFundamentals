using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogic
{
    class HeroesOfCodeAndLogic
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> listOfHeroes = new Dictionary<string, Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] heroInfo = Console.ReadLine().Split().ToArray();
                string heroName = heroInfo[0];
                int health = int.Parse(heroInfo[1]);
                int mana = int.Parse(heroInfo[2]);

                if (!listOfHeroes.ContainsKey(heroName))
                {
                    listOfHeroes.Add(heroName, new Hero(heroName, health, mana));
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" - ").ToArray();
                string command = tokens[0];

                if (command == "End")
                {
                    break;
                }

                string heroName = tokens[1];
                Hero currentHero = listOfHeroes[heroName];

                switch (command)
                {
                    case "Heal":
                        int amountHp = int.Parse(tokens[2]);
                        int healedAmount = currentHero.Health + amountHp <= 100 ? amountHp 
                                         : 100 - currentHero.Health;

                        currentHero.Health += healedAmount;
                        listOfHeroes[heroName] = currentHero;

                        Console.WriteLine($"{heroName} healed for {healedAmount} HP!");

                        break;
                    case "Recharge":
                        int amountMp = int.Parse(tokens[2]);
                        int rechargedAmount = currentHero.Mana + amountMp <= 200 ? amountMp
                                         : 200 - currentHero.Mana;

                        currentHero.Mana += rechargedAmount;
                        listOfHeroes[heroName] = currentHero;

                        Console.WriteLine($"{heroName} recharged for {rechargedAmount} MP!");

                        break;
                    case "CastSpell":
                        int neededMp = int.Parse(tokens[2]);
                        string spellName = tokens[3];

                        if (currentHero.Mana >= neededMp)
                        {
                            currentHero.Mana -= neededMp;
                            listOfHeroes[heroName] = currentHero;

                            Console.WriteLine($"{heroName} has successfully cast {spellName} " +
                                              $"and now has {currentHero.Mana} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        
                        break;
                    case "TakeDamage":

                        int atackPower = int.Parse(tokens[2]);
                        string attackerName = tokens[3];
                        currentHero.Health -= atackPower;

                        if (currentHero.Health > 0)
                        {
                            listOfHeroes[heroName] = currentHero;

                            Console.WriteLine($"{heroName} was hit for {atackPower} HP by {attackerName} " +
                                              $"and now has {currentHero.Health} HP left!");
                        }
                        else
                        {
                            listOfHeroes.Remove(heroName);
                            Console.WriteLine($"{heroName} has been killed by {attackerName}!");
                        }

                        break;
                }

            }

            PrintHeroes(listOfHeroes);
        }

        class Hero
        {
            public Hero(string name, int health, int mana)
            {
                this.Name = name;
                this.Health = health;
                this.Mana = mana;
            }

            public string Name { get; set; }
            public int Health { get; set; }
            public int Mana { get; set; }

            public override string ToString()
            {
                return $"{this.Name}\n  HP: {this.Health} \n  MP: {this.Mana}"; 
            }
        }

        static void PrintHeroes(Dictionary<string, Hero> heroes)
        {
            foreach (var hero in heroes.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Value.Name))
            {
                Console.WriteLine(hero.Value);
            }
        }
    }
}
