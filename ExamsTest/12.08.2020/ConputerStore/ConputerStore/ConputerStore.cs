using System;

namespace ConputerStore
{
    class ConputerStore
    {
        static void Main(string[] args)
        {
            decimal pcTotalPrice = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "special" || input == "regular")
                {
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

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {pcTotalPrice:f2}$");
                Console.WriteLine($"Taxes: {pcTotalPrice * 1.2m:f2}$");
                Console.WriteLine(new string('-', 11));
                decimal totalPriceAfterDiscount = (pcTotalPrice * 1.2m) * 0.9m;
                Console.WriteLine($"Total price: {totalPriceAfterDiscount:f2}$");
            }
        }
    }
}
