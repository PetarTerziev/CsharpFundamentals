using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal[]> productsList = new Dictionary<string, decimal[]>();

            while (true)
            {
                string[] productInfo = Console.ReadLine().Split().ToArray();

                if (productInfo[0] == "buy")
                {
                    break;
                }

                string productName = productInfo[0];
                decimal price = decimal.Parse(productInfo[1]);
                decimal quantity = decimal.Parse(productInfo[2]);

                if (!productsList.ContainsKey(productName))
                {
                    productsList.Add(productName, new decimal[2] {price, quantity});
                }
                else
                {
                    productsList[productName][1] += quantity;

                    if (productsList[productName][0] != price)
                    {
                        productsList[productName][0] = price;
                    }
                }
            }

            foreach (var product in productsList)
            {
                decimal purchasePrice = product.Value[0] * product.Value[1];

                Console.WriteLine($"{product.Key} -> {purchasePrice:f2}");
            }
        }
    }
}
