using System;
using System.Linq;

namespace Articles
{
    class Articles
    {
        static void Main(string[] args)
        {
            string[] bookInfo = Console.ReadLine().Split(", ").ToArray();
            int n = int.Parse(Console.ReadLine());

            Article newArticle = new Article(bookInfo[0], bookInfo[1], bookInfo[2]);

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens[0] == "Edit")
                {
                    newArticle.Edit(tokens[1]);
                }
                else if (tokens[0] == "ChangeAuthor")
                {
                    newArticle.ChangeAuthor(tokens[1]);
                }
                else if (tokens[0] == "Rename")
                {
                    newArticle.Rename(tokens[1]);
                }
            }

            Console.WriteLine(newArticle.ToString());
        }

        class Article
        {
            public Article(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }

            public string Title;
            public string Content;
            public string Author;

            public void Edit(string newContent) 
            {
                this.Content = newContent;
            }
            public void ChangeAuthor(string newAuthor)
            {
                this.Author = newAuthor;
            }

            public void Rename(string newTitle)
            {
                this.Title = newTitle;
            }

            public override string ToString()
            {
                return$"{this.Title} - {this.Content}: {this.Author}";
            }
        }
    }
}
