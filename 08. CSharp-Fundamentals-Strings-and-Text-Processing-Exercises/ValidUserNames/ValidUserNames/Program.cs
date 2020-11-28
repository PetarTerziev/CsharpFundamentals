using System;
using System.Linq;

namespace ValidUserNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ").ToArray();

            foreach (var user in userNames)
            {
                if (IsCorrectUserName(user))
                {
                    Console.WriteLine(user);
                }
            }
        }

        static public bool IsCorrectUserName(string userName)
        {
            for (int i = 0; i < userName.Length; i++)
            {
                char ch = userName[i];

                if (userName.Length >= 3 && userName.Length <= 16 && 
                    (char.IsDigit(ch) || char.IsLetter(ch) || ch == '_' || ch == '-'))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
