using System;
using System.Text;

namespace CaesarCipher
{
    class CaesarCipher
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder(Console.ReadLine());

            for (int i = 0; i < text.Length; i++)
            {              
                text[i] = Convert.ToChar(text[i] + 3);
            }

            Console.WriteLine(text);
        }
    }
}
