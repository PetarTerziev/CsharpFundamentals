using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseCodeTranslator
{
    class MorseCodeTranslator
    {
        static void Main(string[] args)
        {
            string[] morseCode = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            StringBuilder message = new StringBuilder();

            foreach (var morse in morseCode)
            {
                string[] morseLetters = morse.Trim().Split().ToArray();

                foreach (var letter in morseLetters)
                {
                    message.Append(DecryptMorseToLetters(letter));
                }

                message.Append(' ');
            }

            Console.WriteLine(message);
        }

        public static string DecryptMorseToLetters(string morse)
        {

            Dictionary<string, string> morseCiphers = new Dictionary<string, string>();

            morseCiphers.Add(".-", "A");
            morseCiphers.Add("-...", "B");
            morseCiphers.Add("-.-.", "C");
            morseCiphers.Add("-..", "D");
            morseCiphers.Add(".", "E");
            morseCiphers.Add("..-.", "F");
            morseCiphers.Add("--.", "G");
            morseCiphers.Add("....", "H");
            morseCiphers.Add("..", "I");
            morseCiphers.Add(".---", "J");
            morseCiphers.Add("-.-", "K");
            morseCiphers.Add(".-..", "L");
            morseCiphers.Add("--", "M");
            morseCiphers.Add("-.", "N");
            morseCiphers.Add("---", "O");
            morseCiphers.Add(".--.", "P");
            morseCiphers.Add("--.-", "Q");
            morseCiphers.Add(".-.", "R");
            morseCiphers.Add("...", "S");
            morseCiphers.Add("-", "T");
            morseCiphers.Add("..-", "U");
            morseCiphers.Add("...-", "V");
            morseCiphers.Add(".--", "W");
            morseCiphers.Add("-..-", "X");
            morseCiphers.Add("-.--", "Y");
            morseCiphers.Add("--..", "Z");

            return morseCiphers[morse];
        }
    }
}
