using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretChat
{
    class SecretChat
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(":|:").ToArray();
                string command = tokens[0];

                if (command == "Reveal")
                {
                    break;
                }

                switch (command)
                {
                    case "InsertSpace":
                        message = message.Insert(int.Parse(tokens[1]), " ");
                        break;
                    case "ChangeAll":
                        message = message.Replace(tokens[1], tokens[2]);
                        break;
                    case "Reverse":
                        string substringToReplace = tokens[1];

                        if (!message.Contains(substringToReplace))
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        else
                        {
                            int index = message.IndexOf(substringToReplace);
                            message = message.Remove(index, substringToReplace.Length);
                            substringToReplace = substringToReplace.Select(x => x.ToString())
                                                                   .Reverse()
                                                                   .ToList()
                                                                   .Aggregate((a, b) => a + b);
                            message = $"{message}{substringToReplace}";
                        }
                        break;
                }

                Console.WriteLine(message);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
