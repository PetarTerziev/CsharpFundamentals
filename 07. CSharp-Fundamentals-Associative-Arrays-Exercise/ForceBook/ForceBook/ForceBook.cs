using System;
using System.Collections.Generic;
using System.Linq;


namespace ForceBook
{
    class ForceBook
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceList = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Lumpawaroo")
                {
                    break;
                }

                string sideName = string.Empty;
                string userName = string.Empty;
                string command = "|";

                if (input.Contains("|"))
                {
                    sideName = input.Split("|").ToArray()[0].Trim();
                    userName = input.Split("|").ToArray()[1].Trim();
                }
                else
                {
                    sideName = input.Split("->").ToArray()[1].Trim();
                    userName = input.Split("->").ToArray()[0].Trim();
                    command = "->";
                }

                SideUpdate(forceList, command, sideName, userName);

            }

            foreach (var side in forceList.Where(x => x.Value.Count > 0)
                                          .OrderByDescending(x => x.Value.Count)
                                          .ThenBy(x => x.Key))
            {
                PrintMessage($"Side: {side.Key}, Members: {side.Value.Count}");

                side.Value.OrderBy(x => x).ToList().ForEach(x => PrintMessage($"! {x}"));
            }
        }

        public static Dictionary<string, List<string>> SideUpdate(Dictionary<string, List<string>> forceList,
                                                                            string command, string sideName,
                                                                            string userName) 
        {
            bool isUserExist = false;
            string side = string.Empty;

            foreach (var pair in forceList)
            {
                foreach (var user in pair.Value)
                {
                    if (user == userName)
                    {
                        isUserExist = true;
                        side = pair.Key;
                        break;
                    }
                }

                if (isUserExist)
                {
                    break;
                }
            }

            if (command == "|")
            {
                if (!forceList.ContainsKey(sideName) && !isUserExist)
                {
                    forceList.Add(sideName, new List<string>());
                    forceList[sideName].Add(userName);
                }
                else if(!isUserExist)
                {
                    forceList[sideName].Add(userName);
                }

            }
            else
            {
                if (!forceList.ContainsKey(sideName))
                {
                    forceList.Add(sideName, new List<string>());
                    forceList[sideName].Add(userName);

                    if (isUserExist)
                    {
                        forceList[side].Remove(userName);
                    }

                }
                else if (isUserExist)
                {
                    forceList[side].Remove(userName);
                    forceList[sideName].Add(userName);
                }
                else if (!isUserExist)
                {
                    forceList[sideName].Add(userName);
                }

                PrintMessage($"{userName} joins the {sideName} side!");
            }

            return forceList;
            
        }

        static public void PrintMessage(string message) 
        {
            Console.WriteLine(message);
        }
    }
}
