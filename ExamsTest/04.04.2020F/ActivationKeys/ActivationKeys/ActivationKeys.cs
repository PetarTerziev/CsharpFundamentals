using System;
using System.Linq;
using System.Text;

namespace ActivationKeys
{
    class ActivationKeys

    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(">>>").ToArray();
                string command = tokens[0];

                if (command == "Generate")
                {
                    break;
                }

                switch (command)
                {
                    case "Contains":
                        string substring = tokens[1];
                        if (activationKey.Contains(substring))
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string capitalization = tokens[1];
                        int startIndex = int.Parse(tokens[2]);
                        int endIndex = int.Parse(tokens[3]);
                        StringBuilder flippedResult = new StringBuilder();
                        string midSeq = activationKey.Substring(startIndex, endIndex - startIndex);
                        if (capitalization == "Upper")
                        {
                            midSeq = midSeq.ToUpper();
                        }
                        else
                        {
                            midSeq = midSeq.ToLower();
                        }
                        flippedResult.Append(activationKey.Substring(0, startIndex)).Append(midSeq)
                              .Append(activationKey.Substring(endIndex, activationKey.Length - endIndex));
                        activationKey = flippedResult.ToString();
                        Console.WriteLine(activationKey);
                        break;

                    case "Slice":
                        int startInd = int.Parse(tokens[1]);
                        int endInd = int.Parse(tokens[2]);
                        StringBuilder slicedResult = new StringBuilder();
                        slicedResult.Append(activationKey.Substring(0, startInd))
                                    .Append(activationKey.Substring(endInd, activationKey.Length - endInd));
                        activationKey = slicedResult.ToString();
                        Console.WriteLine(activationKey);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
