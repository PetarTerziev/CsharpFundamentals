using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcheryTournamnet
{
    class ArcheryTournamnet
    {
        static void Main(string[] args)
        {
            List<int> targetList = Console.ReadLine().Split("|").Select(int.Parse).ToList();
            int points = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Game over")
                {
                    break;
                }

                string[] shootInfo = input.Split().ToArray();

                string command = shootInfo[0];

                switch (command)
                {
                    case "Reverse":
                        targetList.Reverse();
                        break;
                    case "Shoot":
                        string[] directionInfo = shootInfo[1].Split("@").ToArray();
                        string direction = directionInfo[0];
                        int startIndex = int.Parse(directionInfo[1]);
                        int offset = int.Parse(directionInfo[2]);
                        int indexToShot = -1;

                        if (startIndex < 0 || startIndex >= targetList.Count)
                        {
                            continue;
                        }
                        else if (direction == "Right")
                        {
                            indexToShot = (startIndex + (offset % targetList.Count)) % targetList.Count;
                        }
                        else if (direction == "Left")
                        {
                            indexToShot = startIndex - (offset % targetList.Count);

                            if (indexToShot < 0)
                            {
                                indexToShot += targetList.Count;
                            }
                        }

                        points += Math.Min(targetList[indexToShot], 5);
                        targetList[indexToShot] -= Math.Min(targetList[indexToShot], 5);
                        
                        break;
                }
            }
            
            Console.WriteLine(string.Join(" - ", targetList));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
