using System;

namespace BalancedBrakets
{
    class BalancedBrakets
    {
        static void Main(string[] args)
        {
            int numOflines = int.Parse(Console.ReadLine());

            bool isBalanced = true;
            bool isOpen = false;


            for (int i = 1; i <= numOflines; i++)
            {
                string input = Console.ReadLine();
                
                if (input == "(")
                {
                    if (!isOpen)
                    {
                        isOpen = true;
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }

                if (input == ")")
                {
                    if (isOpen)
                    {
                        isOpen = false;
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
            }

            if (isBalanced && !isOpen)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }

        }
    }
}
