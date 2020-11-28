using System;

namespace ConputerStoreNew
{
    class ConputerStoreNew
    {
        static void Main(string[] args)
        {
            decimal pcTotalPrice = 0;
            bool isSpecail = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "special" || input == "regular")
                {
                    if (input == "special")
                    {
                        isSpecail = true;
                    }

                    break;
                }

                decimal componentPrice = decimal.Parse(input);

                if (componentPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                else
                {
                    pcTotalPrice += componentPrice;
                }
            }

            if (pcTotalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                decimal totalPriceAfterDiscount = pcTotalPrice * 1.2m;

                if (isSpecail)
                {
                    totalPriceAfterDiscount *= 0.9m;
                }

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {pcTotalPrice:f2}$");
                Console.WriteLine($"Taxes: {pcTotalPrice * 0.2m:f2}$");
                Console.WriteLine(new string('-', 11));
                Console.WriteLine($"Total price: {totalPriceAfterDiscount:f2}$");
            }
        }
    }
}
