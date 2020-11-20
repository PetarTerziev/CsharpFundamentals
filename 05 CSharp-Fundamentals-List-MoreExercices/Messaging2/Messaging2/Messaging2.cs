using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging2
{
    class Messaging2
    {
        static void Main(string[] args)
        {
            List<string> numsList = Console.ReadLine().Split().ToList();
            string text = Console.ReadLine();
            string message = string.Empty;

            foreach (var num in numsList)
            {
                int sum = 0;

                for (int i = 0; i < num.Length; i++)
                {
                    sum += int.Parse(num[i].ToString());
                }

                int index = sum % text.Length;
                message += text[index];
                text = text.Remove(index, 1);
            }

            Console.WriteLine(message);
        }
    }
}

