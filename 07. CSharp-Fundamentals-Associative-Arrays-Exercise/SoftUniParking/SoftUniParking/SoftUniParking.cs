using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Parking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingList = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parkingInfo = Console.ReadLine().Split().ToArray();

                string command = parkingInfo[0];
                string userName = parkingInfo[1];
                bool isUserExist = parkingList.ContainsKey(userName);

                if (command == "register")
                {
                    string licensePlateNumber = parkingInfo[2];

                    if (!isUserExist)
                    {
                        parkingList.Add(userName, licensePlateNumber);

                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                }
                else
                {
                    if (isUserExist)
                    {
                        parkingList.Remove(userName);

                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                }

            }
            
            foreach (var pair in parkingList)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }
    }
}
