using System;

namespace CounterStrike
{
    class CounterStrike
    {
        static void Main(string[] args)
        {
            ushort enegy = ushort.Parse(Console.ReadLine());
            ushort counterWins = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End of battle")
                {
                    Console.WriteLine($"Won battles: {counterWins}. Energy left: {enegy}");
                    break;
                }

                ushort distance = ushort.Parse(input);

                if (enegy - distance < 0)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {counterWins} " +
                                        $"won battles and {enegy} energy");
                    break;
                }
                else
                {
                    enegy -= distance;
                    counterWins++;

                    if (counterWins % 3 == 0)
                    {
                        enegy += counterWins;
                    }
                }
            }
        }
    }
}
