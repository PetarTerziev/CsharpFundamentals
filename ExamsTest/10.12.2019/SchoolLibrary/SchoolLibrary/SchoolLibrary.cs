using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolLibrary
{
    class SchoolLibrary
    {
        static void Main(string[] args)
        {
            List<string> bookList = Console.ReadLine().Split("&").ToList();

            while (true)
            {
                string[] bookInfo = Console.ReadLine().Split(" | ").ToArray();

                if (bookInfo[0] == "Done")
                {
                    break;
                }

                string command = bookInfo[0];

                switch (command)
                {
                    case "Add Book":
                        if (!bookList.Contains(bookInfo[1]))
                        {
                            bookList.Insert(0, bookInfo[1]);
                        }
                        break;
                    case "Take Book":
                        if (bookList.Contains(bookInfo[1]))
                        {
                            bookList.Remove(bookInfo[1]);
                        }
                        break;
                    case "Swap Books":
                        if (bookList.Contains(bookInfo[1]) && bookList.Contains(bookInfo[2]))
                        {
                            int indexBookOne = bookList.IndexOf(bookInfo[1]);
                            int indexBookTwo = bookList.IndexOf(bookInfo[2]);
                            bookList[indexBookOne] = bookInfo[2];
                            bookList[indexBookTwo] = bookInfo[1];
                        }
                        break;
                    case "Insert Book":
                        bookList.Add(bookInfo[1]);
                        break;
                    case "Check Book":
                        int index = int.Parse(bookInfo[1]);
                        if (index >= 0 && index < bookList.Count)
                        {
                            Console.WriteLine(bookList[index]);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", bookList));
        }
    }
}
