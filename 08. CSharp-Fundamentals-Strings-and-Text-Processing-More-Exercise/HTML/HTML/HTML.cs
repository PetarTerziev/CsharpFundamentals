using System;
using System.Text;

namespace HTML
{
    class HTML
    {
        static void Main(string[] args)
        {
            string titleArticle = Console.ReadLine();
            string contentArticle = Console.ReadLine();
            StringBuilder htmlDom = new StringBuilder();

            htmlDom.Append(ReturnInHTMLFormat(titleArticle, "<h1>", "</h1>").ToString());
            htmlDom.Append(ReturnInHTMLFormat(contentArticle, "<article>", "</article>").ToString());


            while (true)
            {
                string comment = Console.ReadLine();

                if (comment == "end of comments")
                {
                    break;
                }

                htmlDom.Append(ReturnInHTMLFormat(comment, "<div>", "</div>").ToString());

            }

            Console.WriteLine(htmlDom);
        }

        public static StringBuilder ReturnInHTMLFormat(string text, string openTag, string closeTag) 
        {
            StringBuilder result = new StringBuilder();

            return result.AppendLine(openTag)
                         .Append(new string(' ', 4))
                         .AppendLine(text)
                         .AppendLine(closeTag);
        }
    }
}
