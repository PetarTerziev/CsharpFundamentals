using System;
using System.Linq;

namespace TheImitationGame
{
    class TheImitationGame
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens[0] == "Decode")
                {
                    break;
                }

                switch (tokens[0])
                {
                    case "ChangeAll":
                        message = message.Replace(tokens[1], tokens[2]);
                        break;
                    case "Insert":
                        message = message.Insert(int.Parse(tokens[1]), tokens[2]);
                        break;
                    case "Move":
                        string temp = message.Substring(0, int.Parse(tokens[1]));
                        message = message.Remove(0, int.Parse(tokens[1]));
                        message = message + temp;
                        break;
                }   
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
