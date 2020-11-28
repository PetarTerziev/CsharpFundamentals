using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedFroSpeed3
{
    class NeedFroSpeed3
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> listOfCars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split("|").ToArray();
                string carName = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                if (!listOfCars.ContainsKey(carName))
                {
                    fuel = fuel > 75 ? 75 : fuel;

                    listOfCars.Add(carName, new Car(carName, mileage, fuel));
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" : ").ToArray();
                string command = tokens[0];

                if (command == "Stop")
                {
                    break;
                }

                string carName = tokens[1];
                Car currentCar = listOfCars[carName];

                switch (command)
                {
                    case "Refuel":
                        int fuelLt = int.Parse(tokens[2]);
                        int fueledLeters = currentCar.Fuel + fuelLt <= 75 ? fuelLt
                                         : 75 - currentCar.Fuel;

                        currentCar.Fuel += fueledLeters;
                        listOfCars[carName] = currentCar;

                        Console.WriteLine($"{carName} refueled with {fueledLeters} liters");

                        break;
                    case "Revert":

                        int KM = int.Parse(tokens[2]);

                        if (currentCar.Mileage - KM <= 10000)
                        {
                            currentCar.Mileage = 10000;
                        }
                        else
                        {
                            currentCar.Mileage -= KM;
                            Console.WriteLine($"{carName} mileage decreased by {KM} kilometers");

                        }

                        listOfCars[carName] = currentCar;

                        break;
                    case "Drive":

                        int distance = int.Parse(tokens[2]);
                        int neededFuel = int.Parse(tokens[3]);

                        if (currentCar.Fuel >= neededFuel)
                        {
                            currentCar.Fuel -= neededFuel;
                            currentCar.Mileage += distance;
                            listOfCars[carName] = currentCar;

                            Console.WriteLine($"{carName} driven for {distance} kilometers. " +
                                             $"{neededFuel} liters of fuel consumed.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough fuel to make that ride");
                        }

                        break;
                }

                if (currentCar.Mileage >= 100000)
                {
                    listOfCars.Remove(carName);
                    Console.WriteLine($"Time to sell the {carName}!");
                }
            }

            PrintCars(listOfCars);
        }

        class Car
        {
            public Car(string name, int mileage, int fuel)
            {
                this.Name = name;
                this.Mileage = mileage;
                this.Fuel = fuel;
            }

            public string Name { get; set; }
            public int Mileage { get; set; }
            public int Fuel { get; set; }

            public override string ToString()
            {
                return $"{this.Name} -> Mileage: {this.Mileage} kms, Fuel in the tank: {this.Fuel} lt.";
            }
        }

        static void PrintCars(Dictionary<string, Car> cars)
        {
            foreach (var car in cars.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Value.Name))
            {
                Console.WriteLine(car.Value);
            }
        }
    }
}
