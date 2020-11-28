using System;
using System.Text;

namespace StringExplosion
{
    class StringExplosion
    {
        static void Main(string[] args)
        {

            StringBuilder text = new StringBuilder(Console.ReadLine());

            bool isExplodeTime = false;
            int length = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '>')
                {
                    isExplodeTime = true;
                    continue;
                }
                else if (isExplodeTime)
                {
                    length += int.Parse(text[i].ToString());

                    while (length > 0)
                    {
                        if (text[i] == '>')
                        {
                            break;
                        }
                        else
                        {
                            if (i + length > text.Length)
                            {
                                length = text.Length - i;
                            }

                            text.Remove(i, 1);
                            length--;
                        }
                    }

                    if (length == 0)
                    {
                        isExplodeTime = false;
                        i -= 1;
                    }
                }
            }

            Console.WriteLine(text);
        }
    }
}
