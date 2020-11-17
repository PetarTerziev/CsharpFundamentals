using System;
using System.Linq;

namespace LadyBugs
{
    class LadyBugs
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] initialPos = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] field = new int[size];

            for (int i = 0; i < initialPos.Length; i++)
            {
                if (initialPos[i] >= 0 && initialPos[i] < field.Length)
                {
                    field[initialPos[i]] = 1;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] elements = input.Split();

                int ladybugStartPos = int.Parse(elements[0]);
                string direction = elements[1];
                int posModifier = int.Parse(elements[2]);

                if (ladybugStartPos < 0 || ladybugStartPos > field.Length - 1 || field[ladybugStartPos] == 0)
                {
                    continue;
                }

                field[ladybugStartPos] = 0;

                if (direction == "right")
                {
                    int landIndex = ladybugStartPos + posModifier;

                    if (landIndex > field.Length - 1)
                    {
                        continue;
                    }

                    if (field[landIndex] == 1)
                    {
                        while (field[landIndex] == 1)
                        {
                            landIndex += posModifier;

                            if (landIndex > field.Length - 1)
                            {
                                break;
                            }
                        }
                    }

                    if (landIndex >= 0 && landIndex <= field.Length - 1)
                    {
                        field[landIndex] = 1;
                    }
                }
                else if (direction == "left")
                {
                    int landIndex = ladybugStartPos - posModifier;

                    if (landIndex < 0)
                    {
                        continue;
                    }

                    if (field[landIndex] == 1)
                    {
                        while (field[landIndex] == 1)
                        {
                            landIndex -= posModifier;

                            if (landIndex < 0)
                            {
                                break;
                            }
                        }
                    }
                    if (landIndex >= 0 && landIndex <= field.Length - 1)
                    {
                        field[landIndex] = 1;
                    }
                }
            }
            Console.WriteLine(String.Join(" ", field));
        }
    }
}
