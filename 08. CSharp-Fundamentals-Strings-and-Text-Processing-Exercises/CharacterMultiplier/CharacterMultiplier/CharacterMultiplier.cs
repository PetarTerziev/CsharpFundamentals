using System;
using System.Linq;

namespace CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();

            string shortWord = words[0].Length <= words[1].Length ? words[0] : words[1];
            string largeWord = words[0].Length > words[1].Length ? words[0] : words[1];

            int sum = 0;

            for (int i = 0; i < largeWord.Length; i++)
            {
                sum += i < shortWord.Length ? shortWord[i] * largeWord[i] : largeWord[i];
            }

            Console.WriteLine(sum);
        }
    }
}
