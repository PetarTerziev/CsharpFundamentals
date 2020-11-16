using System;

namespace RefractorPrimeCheker
{
    class RefracktorPrime
    {
        static void Main(string[] args)
        {
            int nummber = int.Parse(Console.ReadLine());

            for (int i = 2; i <= nummber; i++)
            {
                bool isPrime = true;

                for (int sqrt = 2; sqrt < i; sqrt++)
                {
                    if (i % sqrt == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine($"{i} -> {isPrime.ToString().ToLower()}");
            }

        }
    }
}
