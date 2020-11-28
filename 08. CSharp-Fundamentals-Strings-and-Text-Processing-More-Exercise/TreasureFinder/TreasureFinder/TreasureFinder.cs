using System;
using System.Linq;
using System.Text;

namespace TreasureFinder
{
    class TreasureFinder
    {
        static void Main(string[] args)
        {
            int[] keyNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "find")
                {
                    break;
                }

                PrintHiddenMessage(DecryptHiddenMessage(input, keyNumbers).ToString());
            }
        }

        public static StringBuilder DecryptHiddenMessage(string text, int[] key)
        {
            StringBuilder result = new StringBuilder(text);

            for (int i = 0; i < result.Length; i++)
            {
                int keyIndex = i % key.Length; 
                result[i] = Convert.ToChar(result[i] - key[keyIndex]);
            }

            return result;
        }

        public static void PrintHiddenMessage(string text)
        {

            int startIndexTreasure = text.IndexOf("&");
            int endIndexTreasure = text.IndexOf("&", startIndexTreasure + 1);
            int startIndexCoord = text.IndexOf("<");
            int endIndexCoord = text.IndexOf(">");

            string treasureType = text.Substring(startIndexTreasure + 1, endIndexTreasure - startIndexTreasure - 1);
            string coordinates = text.Substring(startIndexCoord + 1, endIndexCoord - startIndexCoord - 1);
            
            Console.WriteLine($"Found {treasureType} at {coordinates}");
        }
    }
}
