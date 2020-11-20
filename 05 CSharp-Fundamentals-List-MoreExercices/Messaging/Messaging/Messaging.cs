using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Messaging
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

                for (int i = 0; i < text.Length; i++)
                {
                    int index = sum % text.Length;
                    message.Append(text[index]);
                    text.Remove(index, 1);
                }
            }

            Console.WriteLine(message);
        }
    }
}
