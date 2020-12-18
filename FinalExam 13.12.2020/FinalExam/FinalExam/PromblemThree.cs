using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinalExam
{
    class PromblemThree
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            Dictionary<string, User> userStatistics = new Dictionary<string, User>();

            while (true)
            {
                string[] usersInfo = Console.ReadLine().Split("=").ToArray();
                string command = usersInfo[0];

                if (command == "Statistics")
                {
                    break;
                }

                string userName = usersInfo[1];

                switch (command)
                {
                    case "Add":
                        if (!userStatistics.ContainsKey(userName))
                        {
                            userStatistics.Add(userName, new User(userName, int.Parse(usersInfo[2]), int.Parse(usersInfo[3])));
                        }
                        break;
                    case "Message":
                        string sender = userName;
                        string receiver = usersInfo[2];
                        if (userStatistics.ContainsKey(sender) && userStatistics.ContainsKey(receiver))
                        {
                            User senderTemp = userStatistics[sender];
                            User receiverTemp = userStatistics[receiver];

                            if (senderTemp.SentMessages + senderTemp.ReceivedMessages + 1 == maxCapacity)
                            {
                                userStatistics.Remove(sender);
                                Console.WriteLine($"{userName} reached the capacity!");
                            }
                            else
                            {
                                userStatistics[sender].SentMessages += 1;
                            }

                            if (receiverTemp.SentMessages + receiverTemp.ReceivedMessages + 1 == maxCapacity)
                            {
                                userStatistics.Remove(receiver);
                                Console.WriteLine($"{receiver} reached the capacity!");
                            }
                            else
                            {
                                userStatistics[receiver].ReceivedMessages += 1;
                            }
                        }
                        break;
                    case "Empty":
                        if (userName == "All")
                        {
                            userStatistics.Clear();
                        }
                        else if (userStatistics.ContainsKey(userName))
                        {
                            userStatistics.Remove(userName);
                        }
                        break;
                }
            }

            
                int userCount = userStatistics.Count == 0 ? 0 : userStatistics.Count;

                Console.WriteLine($"Users count: {userCount}");

                foreach (var user in userStatistics.OrderByDescending(x => x.Value.ReceivedMessages)
                                                    .ThenBy(x => x.Value.Name))
                {
                    Console.WriteLine(user.Value);
                }
        }

        class User
        {
            public User(string name, int sent, int received)
            {
                this.Name = name;
                this.SentMessages = sent;
                this.ReceivedMessages = received;
            }
            public string Name { get; set; }
            public int SentMessages { get; set; }
            public int ReceivedMessages { get; set; }

            public override string ToString()
            {
                return $"{this.Name} - {this.SentMessages + this.ReceivedMessages}"; 
            }
        }
    }
}
