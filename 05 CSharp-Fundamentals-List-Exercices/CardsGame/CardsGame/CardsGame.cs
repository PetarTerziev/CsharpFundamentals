using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class CardsGame
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayerDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            GameJudge(firstPlayerDeck, secondPlayerDeck);
        }

        static void GameJudge(List<int> firstDeck, List<int> secondDeck)
        {
            List<int> playerOneResult = firstDeck;
            List<int> playerTwoResult = secondDeck;

            while (playerOneResult.Count != 0 && playerTwoResult.Count != 0)
            {
                int cardDeckOne = playerOneResult[0];
                int cardDeckTwo = playerTwoResult[0];

                if (cardDeckOne == cardDeckTwo)
                {
                    playerOneResult.RemoveAt(0);
                    playerTwoResult.RemoveAt(0);
                }
                else if (cardDeckOne > cardDeckTwo)
                {
                    playerOneResult.Add(cardDeckOne);
                    playerOneResult.Add(cardDeckTwo);
                    playerOneResult.RemoveAt(0);
                    playerTwoResult.RemoveAt(0);
                }
                else if (cardDeckOne < cardDeckTwo)
                {
                    playerTwoResult.Add(cardDeckTwo);
                    playerTwoResult.Add(cardDeckOne);
                    playerOneResult.RemoveAt(0);
                    playerTwoResult.RemoveAt(0);
                }
            }

            if (playerOneResult.Count != 0)
            {
                Console.WriteLine($"First player wins! Sum: {playerOneResult.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwoResult.Sum()}");
            }
        }
    }
}
