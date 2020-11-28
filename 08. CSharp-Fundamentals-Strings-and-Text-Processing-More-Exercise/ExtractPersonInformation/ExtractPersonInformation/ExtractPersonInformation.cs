using System;

namespace ExtractPersonInformation
{
    class ExtractPersonInformation
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                int startIndexName = text.IndexOf("@");
                int endIndexName = text.IndexOf("|");
                int startIndexAge = text.IndexOf("#");
                int endIndexAge = text.IndexOf("*");

                string name = text.Substring(startIndexName + 1, endIndexName - startIndexName - 1);
                string age = text.Substring(startIndexAge + 1, endIndexAge - startIndexAge - 1);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
