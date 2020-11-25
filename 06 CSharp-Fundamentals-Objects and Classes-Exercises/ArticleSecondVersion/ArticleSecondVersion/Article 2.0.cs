using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    class Articles
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            ListArticle articles = new ListArticle();
            

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Article newArticle = new Article(tokens[0], tokens[1], tokens[2]);

                articles.Article.Add(newArticle);
            }

            string filter = Console.ReadLine();

            ListArticle.PrintArticles(articles.Article, filter);
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
        }

        class ListArticle
        {
            public ListArticle()
            {
                Article = new List<Article>();
            }
            public List<Article> Article { get; set; }

            public static void PrintArticles(List<Article> articles, string filter)
            {
                if (filter == "title")
                {
                    foreach (var article in articles.OrderBy(a => a.Title))
                    {
                        Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                    }
                }
                else if (filter == "author")
                {
                    foreach (var article in articles.OrderBy(a => a.Author))
                    {
                        Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                    }
                }
                else
                {
                    foreach (var article in articles.OrderBy(a => a.Content))
                    {
                        Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                    }
                }
            }
        }
    }
}
