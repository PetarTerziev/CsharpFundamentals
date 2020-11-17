using System;

namespace EncryptSortAndPrint_Array
{
    class EncryptSortAndPrintArray
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] numbersArr = new int[num];

            for (int i = 0; i < num; i++)
            {
                string word = Console.ReadLine();
                int encryptedResult = 0;

                for (int j = 0; j < word.Length; j++)
                {
                    string lowerWord = word.ToLower();

                    if (lowerWord[j] == 'a' || lowerWord[j] == 'e' 
                        || lowerWord[j] == 'i'
                        || lowerWord[j] == 'u' || lowerWord[j] == 'o')
                    {
                        encryptedResult += word[j] * word.Length;
                    }
                    else
                    {
                        encryptedResult += word[j] / word.Length;
                    }
                }

                numbersArr[i] = encryptedResult;
            }

            for (int i = 0; i < numbersArr.Length - 1; i++)
            {
                int temp = int.MinValue;

                for (int j = i + 1; j < numbersArr.Length; j++)
                {
                    if (numbersArr[i] > numbersArr[j])
                    {
                        temp = numbersArr[i];
                        numbersArr[i] = numbersArr[j];
                        numbersArr[j] = temp;
                    }
                }
            }

            Console.WriteLine(String.Join("\n", numbersArr));
        }
    }
}
