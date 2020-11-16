using System;

namespace DataTypeFinder
{
    class DataType
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                bool successParseInt = int.TryParse(input, out int outputInt);
                bool successParseFloat = float.TryParse(input, out float outputFloat);
                bool successParseChar = char.TryParse(input, out char outputChar);
                bool succesParseBool = bool.TryParse(input, out bool outputBool);

                string message = string.Empty;

                if (successParseInt)
                {
                    message = $"{input} is integer type";
                }
                else if (successParseFloat)
                {
                    message = $"{input} is floating point type";
                }
                else if (succesParseBool)
                {
                    message = $"{input} is boolean type";
                }
                else if (successParseChar)
                {
                    message = $"{input} is character type";
                }
                else
                {
                    message = $"{input} is string type";
                }

                Console.WriteLine(message);
            }
        }
    }
}
