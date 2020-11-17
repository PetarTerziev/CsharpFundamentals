using System;

namespace ArrayRotation
{
    class ArrayRotation
    {
        static void Main(string[] args)
        {
            string[] strigsArr = Console.ReadLine().Split();
            int numRot = int.Parse(Console.ReadLine());

            for (int i = 0; i < numRot; i++)
            {
                string[] tempArr = new string [strigsArr.Length];

                for (int j = 0; j < strigsArr.Length; j++)
                {
                    if (j == strigsArr.Length - 1)
                    {
                        tempArr[j] = strigsArr[0];
                    }
                    else
                    {
                        tempArr[j] = strigsArr[j + 1];
                    }
                }

                strigsArr = tempArr;
            }

            Console.WriteLine(String.Join(" ", strigsArr));
        }
    }
}
