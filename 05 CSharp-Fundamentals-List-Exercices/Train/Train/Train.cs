using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Train
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine().Split().Select(int.Parse).ToList();
            int wagonCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    Console.WriteLine(string.Join(" ", train));
                    break;
                }

                int passengers = 0;
                bool successParse = int.TryParse(input, out passengers);

                List<string> tokens = new List<string>();

                if (!successParse)
                {
                    tokens = input.Split().ToList();
                    train.Add(int.Parse(tokens[1]));
                }
                else
                {
                    PassengerBoarding(train, passengers, wagonCapacity);
                }
            }
        }
        static List<int> PassengerBoarding(List<int> trainList, int passengerNumber, int WagonCapacity)
        {
            List<int> boardedTrain = trainList;
     
            for (int i = 0; i < boardedTrain.Count; i++)
            {
                if (WagonCapacity >= passengerNumber + boardedTrain[i])
                {
                    boardedTrain[i] += passengerNumber;
                    break;
                }
            }

            return boardedTrain;
        }
    }
}
