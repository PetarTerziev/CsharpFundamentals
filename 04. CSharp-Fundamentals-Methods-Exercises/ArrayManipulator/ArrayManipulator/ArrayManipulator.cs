using System;
using System.Linq;

namespace ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            int[] numArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    Console.WriteLine($"[{String.Join(", ", numArr)}]");
                    break;
                }

                string[] commandArr = command.Split().ToArray();

                if (commandArr[0] == "exchange")
                {
                    if (int.Parse(commandArr[1]) >= 0 && int.Parse(commandArr[1]) <= numArr.Length - 1)
                    {
                        numArr = ArrayExchange(numArr, int.Parse(commandArr[1]));
                    }
                    else
                    {
                        PrintMessage("Invalid index");
                    }
                }
                else if (commandArr[0] == "max")
                {
                    PrintMessage(GetMaxIndex(numArr, commandArr[1]));
                }
                else if (commandArr[0] == "min")
                {
                    PrintMessage(GetMinIndex(numArr, commandArr[1]));
                }
                else if (int.Parse(commandArr[1]) > numArr.Length)
                {
                    PrintMessage("Invalid count");
                }
                else if (commandArr[0] == "first")
                {
                    FirstLastOddEvenNumbers(numArr, commandArr);
                }
                else if (commandArr[0] == "last")
                {
                    FirstLastOddEvenNumbers(numArr, commandArr);
                }
            }
        }

        static int[] ArrayExchange(int[] numArr, int index) 
        {
            int[] tempArr = new int[numArr.Length];
            int counter = 0;

            for (int i = 0; i < numArr.Length - (index + 1); i++)
            {
                tempArr[i] = numArr[i + index + 1];
                counter++;
            }

            for (int i = 0; i < numArr.Length - counter; i++)
            {
                tempArr[i + counter] = numArr[i];
            }
            numArr = tempArr.ToArray();

            return numArr;
        }

        static string GetMinIndex(int [] numArr, string command) 
        {
            int minNum = int.MaxValue;
            int index= - 1;
            bool isEvenCommand = command == "even";


            for (int i = 0; i < numArr.Length; i++)
            {
                if (!isEvenCommand && numArr[i] % 2 != 0 && numArr[i] <= minNum)
                {
                    minNum = numArr[i];
                    index = i;
                }

                if (isEvenCommand && numArr[i] % 2 == 0 && numArr[i] <= minNum)
                {
                    minNum = numArr[i];
                    index = i;
                }
            }

            if (index != -1)
            {
                return index.ToString();
            }
            else
            {
                return "No matches";
            }
        }

        static string GetMaxIndex(int[] numArr, string command)
        {
            int maxNum = int.MinValue;
            int index = -1;
            bool isEvenCommand = command == "even";


            for (int i = 0; i < numArr.Length; i++)
            {
                if (!isEvenCommand && numArr[i] % 2 != 0 && numArr[i] >= maxNum)
                {
                    maxNum = numArr[i];
                    index = i;
                }

                if (isEvenCommand && numArr[i] % 2 == 0 && numArr[i] >= maxNum)
                {
                    maxNum = numArr[i];
                    index = i;
                }
            }

            if (index != -1)
            {
                return index.ToString();
            }
            else
            {
                return "No matches";
            }
        }

        static void FirstLastOddEvenNumbers(int [] numArr, string [] command) 
        {
            string result = string.Empty;
            int lemghtOfSequence = int.Parse(command[1]);
            bool isEvenCommand = command[2] == "even";
            int counter = 0;

            if (command[0] == "first")
            {
                for (int i = 0; i < numArr.Length; i++)
                {
                    if (isEvenCommand && numArr[i] % 2 == 0)
                    {
                        result += $"{numArr[i]} ";
                        counter++;

                        if (counter == lemghtOfSequence)
                        {
                            break;
                        }
                    }

                    if (!isEvenCommand && numArr[i] % 2 != 0)
                    {
                        result += $"{numArr[i]} ";
                        counter++;

                        if (counter == lemghtOfSequence)
                        {
                            break;
                        }
                    }
                }
            }

            if (command[0] == "last")
            {
                for (int i = numArr.Length - 1; i >=0; i--)
                {
                    if (isEvenCommand && numArr[i] % 2 == 0)
                    {
                        result += $"{numArr[i]} ";
                        counter++;

                        if (counter == lemghtOfSequence)
                        {
                            break;
                        }
                    }

                    if (!isEvenCommand && numArr[i] % 2 != 0)
                    {
                        result += $"{numArr[i]} ";
                        counter++;

                        if (counter == lemghtOfSequence)
                        {
                            break;
                        }
                    }
                }
            }

            string[] strArr = result.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (command[0] == "last")
            {
                Array.Reverse(strArr);
            }

            PrintMessage($"[{String.Join(", ", strArr)}]");
        }
        static void PrintMessage(string message) 
        {
            Console.WriteLine(message);
        }
    }
}
