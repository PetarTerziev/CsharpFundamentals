using System;

namespace DecryptingMessages
{
    class DecryptingMessages
    {
        static void Main(string[] args)
        {
            int keyNumber = int.Parse(Console.ReadLine());
            int numLines = int.Parse(Console.ReadLine());
            string message = string.Empty;

            for (int i = 1; i <= numLines; i++)
            {
                message += (char)(char.Parse(Console.ReadLine()) + keyNumber);
            }

            Console.WriteLine(message);


        }
    }
}
