using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class FancyBarcodes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                Regex rgxValidBarcode = new Regex(@"([@][#]{1,})([A-Z][A-Za-z0-9]{4,}[A-Z])([@][#]{1,})");

                if (rgxValidBarcode.IsMatch(barcode))
                {
                    string productName = rgxValidBarcode.Match(barcode).Groups[2].Value;

                    Regex rgxNumbers = new Regex(@"\d+");
                    
                    if (!rgxNumbers.IsMatch(productName))
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    {
                        MatchCollection productGroupMatch = rgxNumbers.Matches(productName);
                        string productGroup = productGroupMatch.Cast<Match>()
                                                               .Select(x => x.Value.ToString())
                                                               .ToArray()
                                                               .Aggregate((a, b) => a + b);

                        Console.WriteLine($"Product group: {productGroup}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
