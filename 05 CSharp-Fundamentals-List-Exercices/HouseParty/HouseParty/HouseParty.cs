using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class HouseParty
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string guestInfo = Console.ReadLine();
                string guestName = GetGuestInfo(guestInfo)[0];
                string guestAction = GetGuestInfo(guestInfo)[1];

                if (guestAction == "is")
                {
                    if (guestList.Contains(guestName))
                    {
                        PrintMessage($"{guestName} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(guestName);
                    }
                }
                else
                {
                    if (guestList.Contains(guestName))
                    {
                        guestList.Remove(guestName);

                    }
                    else
                    {
                        PrintMessage($"{guestName} is not in the list!");
                    }
                }
            }

            foreach (var guest in guestList)
            {
                PrintMessage(guest);
            }
        }

        static List<string> GetGuestInfo(string guestInfo) 
        {
            List<string> guestList = guestInfo.Split().ToList();

            if (guestList.Count == 3)
            {
                guestList.Remove("Going");
            }
            else
            {
                guestList.Remove("Going");
                guestList.Remove("is");
            }

            return guestList;
        }

        static void PrintMessage(string message) 
        {
            Console.WriteLine(message);
        }
    }
}
