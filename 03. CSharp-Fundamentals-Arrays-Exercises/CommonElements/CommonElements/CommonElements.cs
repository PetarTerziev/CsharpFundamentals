using System;

namespace CommonElements
{
    class CommonElements
    {
        static void Main(string[] args)
        {
            string[] stringsArrOne = Console.ReadLine().Split();
            string[] stringsArrTwo = Console.ReadLine().Split();
            string identElements = string.Empty;

            for (int i = 0; i < stringsArrTwo.Length; i++)
            {
                for (int j = 0; j < stringsArrOne.Length; j++)
                {
                    if (stringsArrTwo[i] == stringsArrOne[j])
                    {
                        identElements += $"{stringsArrTwo[i]} ";
                    }
                }
            }

            Console.WriteLine(identElements);
        }
    }
}
