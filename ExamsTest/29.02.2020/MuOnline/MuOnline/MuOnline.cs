using System;
using System.Linq;

namespace MuOnline
{
    class MuOnline
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split("|").ToArray();
            int health = 100;
            long bitcoinsAmount = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                string command = rooms[i].Split()[0];
                int number = int.Parse(rooms[i].Split()[1]);

                if (command == "potion")
                {
                    int healedAmout = health + number <= 100 ? number : 100 - health;
                    health += healedAmout;

                    Console.WriteLine($"You healed for {healedAmout} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (command == "chest")
                {
                    bitcoinsAmount += number;

                    Console.WriteLine($"You found {number} bitcoins.");
                }
                else
                {
                    health -= number;

                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                }
            }

            if (health > 0)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoinsAmount}");
                Console.WriteLine($"Health: {health}");
            }
        }

    }
}
