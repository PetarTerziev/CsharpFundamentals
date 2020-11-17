using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class AnonymousThreat
    {
        static void Main(string[] args)
        {
            List<string> inputList = ReadNewLine();

            while (true)
            {
                string[] command = Console.ReadLine().Split().ToArray();


                if (command[0] == "3:1")
                {
                    break;
                }
                if (command[0] == "merge")
                {
                    MergeLists(inputList, command);
                }
                else
                {
                    DivideList(inputList, command);
                }
            }

            Console.WriteLine(string.Join(" ", inputList));
        }
        static List<string> ReadNewLine()
        {
            List<string> numsList = Console.ReadLine().Split().ToList();

            return numsList;
        }
        static List<string> MergeLists(List<string> mergeList, string[] tokens)
        {
            List<string> result = mergeList;
            string mergedPositions = string.Empty;
            bool isMerged = false;
            int startIndex = int.Parse(tokens[1]);
            int endIndex = int.Parse(tokens[2]);

            if (startIndex < 0)
            {
                startIndex = 0;
            }
            else if (startIndex > mergeList.Count - 1)
            {
                startIndex = mergeList.Count - 1;
            }

            if (endIndex < 0)
            {
                endIndex = 0;
            }
            else if (endIndex > mergeList.Count - 1)
            {
                endIndex = mergeList.Count - 1;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                mergedPositions += result[i];
                isMerged = true;
            }

            if (isMerged)
            {
                result.RemoveRange(startIndex, endIndex + 1 - startIndex);
                result.Insert(startIndex, mergedPositions);
            }

            return result;
        }

        static List<string> DivideList(List<string> mergeList, string[] tokens)
        {
            List<string> result = new List<string>();
            string elementToDivide = mergeList[int.Parse(tokens[1])];
            int divider = int.Parse(tokens[2]);

            int lastPos = - 1;

            for (int i = 0; i < divider; i++)
            {
                string insertedElement = string.Empty;

                if (elementToDivide.Length % divider == 0 || elementToDivide.Length % divider == 1 && i + 1 != divider)
                {
                    for (int j = 0; j < elementToDivide.Length / divider; j++)
                    {
                        lastPos++;
                        insertedElement += elementToDivide[lastPos].ToString();
                    }
                }
                else
                {
                    for (int j = lastPos; j <= elementToDivide.Length - lastPos; j++)
                    {
                        lastPos++;
                        insertedElement += elementToDivide[lastPos].ToString();
                    }
                }

                result.Add(insertedElement);
            }
            mergeList.RemoveAt(int.Parse(tokens[1]));
            mergeList.AddRange(int.Parse(tokens[1]), result);

            return mergeList;
        }
    }
}
