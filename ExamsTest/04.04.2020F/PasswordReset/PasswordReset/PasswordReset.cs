using System;
using System.Linq;
using System.Text;

namespace PasswordReset
{
    class PasswordReset
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string command = input[0];

                if (command == "Done")
                {
                    break;
                }

                switch (command)
                {
                    case "TakeOdd":
                        password = ReturnOddPosition(password);
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int startPos = int.Parse(input[1]);
                        int length = int.Parse(input[2]);

                        password = CutPassword(password, startPos, length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string replaceStr = input[1];
                        string subStr = input[2];

                        if (password.Contains(replaceStr))
                        {
                            password = password.Replace(replaceStr, subStr);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }

                        break;
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
        static public string ReturnOddPosition(string input) 
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i < input.Length; i+=2)
            {
                result.Append(input[i]);
            }

            return result.ToString();
        
        }
        static public string CutPassword(string input, int startPos, int length)
        {
            StringBuilder result = new StringBuilder();

            string leftSeq = input.Substring(0, startPos);
            string rigthSeq = input.Substring(startPos + length, input.Length - (startPos + length));
            result.Append(leftSeq).Append(rigthSeq);

            return result.ToString();
        }
    }
}
