using System;

namespace TriplesOflatinLetters
{
    class Triple
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int pos1 = 'a'; pos1 < 'a' + num ; pos1++)
            {
                for (int pos2 = 'a'; pos2 < 'a' + num; pos2++)
                {
                    for (int pos3 = 'a'; pos3 < 'a' + num; pos3++)
                    {
                        Console.WriteLine($"{(char)(pos1)}{(char)(pos2)}" +
                                            $"{(char)(pos3)}");
                    }
                }
            }
        }
    }
}
