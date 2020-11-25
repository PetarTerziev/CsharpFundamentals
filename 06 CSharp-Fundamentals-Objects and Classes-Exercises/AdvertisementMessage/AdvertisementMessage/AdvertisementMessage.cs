using System;
using System.Collections.Generic;

namespace AdvertisementMessage
{
    class AdvertisementMessage
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.",
                                            "Best product of its category.", "Exceptional product.",
                                             "I can’t live without this product." };
            string[] events = new string[]{"Now I feel good.", "I have succeeded with this product.",
                                            "Makes miracles. I am happy of the results!",
                                            "I cannot believe but now I feel awesome.",
                                            "Try it yourself, I am very satisfied.", "I feel great!"};
            string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            List<Message> messages = new List<Message>();

            for (int i = 0; i < number; i++)
            {
                Message newMessage = new Message();

                newMessage.Phrases = Randomizer(phrases);
                newMessage.Events = Randomizer(events);
                newMessage.Authors = Randomizer(authors);
                newMessage.Cities = Randomizer(cities);
                
                messages.Add(newMessage);
            }

            Message.PrintMessages(messages);
        }

        class Message
        {
            public string Phrases { get; set; }
            public string Events { get; set; }
            public string Authors { get; set; }
            public string Cities { get; set; }

            public static void PrintMessages(List<Message> messages)
            {
                foreach (var message in messages)
                {
                    Console.WriteLine($"{message.Phrases} {message.Events} {message.Authors} - {message.Cities}");
                }
            }

        }

        public static string Randomizer(string[] words)
        {
            string message = string.Empty;
            Random newRand = new Random();
            message = words[newRand.Next(0, words.Length)];

            return message;
        }
    }
}
