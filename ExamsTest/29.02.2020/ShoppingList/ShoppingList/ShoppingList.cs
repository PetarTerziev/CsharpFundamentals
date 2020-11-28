using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList
{
    class ShoppingList
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine().Split("!").ToList();

            while (true)
            {
                string input = Console.ReadLine();


                if (input == "Go Shopping!")
                {
                    break;
                }

                UpdateList(shoppingList, input.Split().ToArray());
            }

            Console.WriteLine(string.Join(", ", shoppingList));

        }

        static public List<string> UpdateList(List<string> shoppingList, string[] tokens) 
        {
            string command = tokens[0];
            string itemName = tokens[1];
            bool isItemExist = shoppingList.Contains(itemName);
            switch (command)
            {
                case "Urgent":
                    if (!isItemExist)
                    {
                        shoppingList.Insert(0, itemName);
                    }
                    break;
                case "Unnecessary":
                    if (isItemExist)
                    {
                        shoppingList.Remove(itemName);
                    }
                    break;
                case "Correct":
                    if (isItemExist)
                    {
                        int index = shoppingList.IndexOf(itemName);
                        shoppingList[index] = tokens[2];
                    }
                    break;
                case "Rearrange":
                    if (isItemExist)
                    {
                        shoppingList.Remove(itemName);
                        shoppingList.Add(itemName);
                    }
                    break;
            }

            return shoppingList;
        }
    }
}
