using System;

namespace ExtraxtFile
{
    class ExtraxtFile
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            while (path.Contains(@"\"))
            {
                int endIndex = path.IndexOf(@"\");

                path = path.Remove(0, endIndex + 1); 
            }

            Console.WriteLine($"File name: {path.Substring(0, path.IndexOf("."))}");
            Console.WriteLine($"File extension: {path.Substring(path.IndexOf(".") + 1)}");
        }
    }
}
