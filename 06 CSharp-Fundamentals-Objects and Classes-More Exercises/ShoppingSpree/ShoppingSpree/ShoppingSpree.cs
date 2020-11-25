using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class ShoppingSpree
    {
        static void Main(string[] args)
        {
            List<string> personsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries)
                                                         .ToList();
            List<string> productsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries)
                                                        .ToList();
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();


            for (int i = 0; i < personsInfo.Count; i++)
            {
                Person newPerson = Person.ReadNewPerson(personsInfo, i);
                persons.Add(newPerson);
            }

            for (int i = 0; i < productsInfo.Count; i++)
            {
                Product newProduct = Product.ReadNewProduct(productsInfo, i);
                products.Add(newProduct);
            }

            while (true)
            {
                string[] purchaseInfo = Console.ReadLine().Split().ToArray();

                if (purchaseInfo[0] == "END")
                {
                    break;
                }

                string buyerName = purchaseInfo[0];
                string productName = purchaseInfo[1];
                var productList = products.Where(x => x.Name == productName).ToArray();
                decimal price = productList[0].Price;
                var buyerInfo = persons.Where(x => x.Name == buyerName).ToArray();
                decimal availableMoney = buyerInfo[0].Money;

                if (price <= availableMoney)
                {
                    int index = persons.FindIndex(x => x.Name == buyerName);
                    persons[index].UpdatePerson(productName, price);

                    Console.WriteLine($"{buyerName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{buyerName} can't afford {productName}");
                }
            }

            persons.ForEach(x => Console.WriteLine(x));
        }

        class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }

            public Product(string name, decimal price)
            {
                this.Name = name;
                this.Price = price;
            }
            public static Product ReadNewProduct(List<string> productsInfo, int index)
            {
                int indexEquals = productsInfo[index].IndexOf("=");
                string productName = productsInfo[index].Substring(0, indexEquals);
                decimal price = decimal.Parse(productsInfo[index]
                                               .Substring(indexEquals + 1));
                Product newProduct = new Product(productName, price);

                return newProduct;
            }
        }

        class Person
        {
            public string Name { get; set; }
            public decimal Money { get; set; }
            public List<string> Products { get; set; }

            public Person(string name, decimal money)
            {
                this.Name = name;
                this.Money = money;
                this.Products = new List<string>();
            }

            public static Person ReadNewPerson(List<string> personsInfo, int index) 
            {
                int indexEquals = personsInfo[index].IndexOf("=");
                string personName = personsInfo[index].Substring(0, indexEquals);
                decimal personSavings = decimal.Parse(personsInfo[index]
                                                   .Substring(indexEquals + 1));
                Person newPerson = new Person(personName, personSavings);

                return newPerson;
            }

            public void UpdatePerson(string productName, decimal price)
            {
                this.Money -= price;
                this.Products.Add(productName);
            }

            public override string ToString()
            {
                if (this.Products.Count == 0)
                {
                    return $"{this.Name} - Nothing bought";
                }
                else
                {
                    return $"{this.Name} - {string.Join(", ", this.Products)}";
                }
            }
        }
    }
}
