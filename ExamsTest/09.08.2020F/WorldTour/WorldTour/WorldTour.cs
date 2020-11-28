using System;
using System.Linq;

namespace WorldTour
{
    class WorldTour
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            while (true)
            {
                string[] input = Console.ReadLine().Split(":").ToArray();

                if (input[0] == "Travel")
                {
                    break;
                }

                string command = input[0];

                switch (command)
                {
                    case "Add Stop":
                        short index = short.Parse(input[1]);

                        if (index >= 0 && index < str.Length)
                        {
                            string tempLeft = str.Substring(0, index);
                            string rightTemp = str.Substring(index, str.Length - index);

                            string temp = $"{tempLeft}{input[2]}{rightTemp}";
                            str = temp;
                        }
                        break;
                    case "Remove Stop":

                        short startIndex = short.Parse(input[1]);
                        short endIndex = short.Parse(input[2]);

                        if (startIndex <= endIndex && startIndex >= 0 && startIndex < str.Length
                                    && endIndex >= 0 && endIndex < str.Length)
                        {
                            string temp = str.Remove(startIndex, endIndex - startIndex + 1);
                            str = temp;
                        }
                        break;
                    case "Switch":

                        if (str.Contains(input[1]))
                        {
                            string temp = str.Replace(input[1], input[2]);
                            str = temp;
                        }
                        break;
                }

                Console.WriteLine(str);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {str}");
        }
    }
}
