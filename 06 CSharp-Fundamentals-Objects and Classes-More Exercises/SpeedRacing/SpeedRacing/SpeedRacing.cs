using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class SpeedRacing
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split().ToArray();
                cars.Add(Car.ReadNewCar(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2])));
            }

            while (true)
            {
                string [] driveInfo = Console.ReadLine().Split().ToArray();

                if (driveInfo[0] == "End")
                {
                    break;
                }

                if (Car.IsEnoughFuel(cars, driveInfo))
                {
                    Car.Drive(cars, driveInfo);
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                
            }

            cars.ForEach(x => Console.WriteLine(x));

        }

        class Car
        {
            public string Model { get; set; }
            public double FuelAmount { get; set; }
            public double FuelConsumption { get; set; }
            public int TraveledDistance { get; set; }


            public Car(string model, double fuelAmount, double fuelConsumption)
            {
                this.Model = model;
                this.FuelAmount = fuelAmount;
                this.FuelConsumption = fuelConsumption;
            }

            public Car(int traveledDistance)
            {
                this.TraveledDistance = traveledDistance;
            }

            public static Car ReadNewCar(string model, double fuelAmount, double fuelConsumption)
            {
                Car newCar = new Car(model, fuelAmount, fuelConsumption);

                return newCar;
            }
            public static bool IsEnoughFuel(List<Car> cars, string[] driveInfo)
            {
                string carModel = driveInfo[1];
                int amountOfKm = int.Parse(driveInfo[2]);
                var drivedCar = cars.Where(x => x.Model == carModel).ToList();
                double neededFuel = amountOfKm * drivedCar[0].FuelConsumption;
                double fuel = drivedCar[0].FuelAmount;

                if (neededFuel <= fuel)
                {
                    return true;
                }

                return false;
            }
            public static List<Car> Drive (List<Car> cars, string[] driveInfo)
            {
                string carModel = driveInfo[1];
                int amountOfKm = int.Parse(driveInfo[2]);
                var drivedCar = cars.Where(x => x.Model == carModel).ToList();
                int index = cars.FindIndex(x => x.Model == carModel);
                double neededFuel = amountOfKm * drivedCar[0].FuelConsumption;
                double fuel = drivedCar[0].FuelAmount;

                cars[index].TraveledDistance += amountOfKm;
                cars[index].FuelAmount -= neededFuel;

                return cars;
            }

            public override string ToString()
            {
                return $"{this.Model} {this.FuelAmount:f2} {this.TraveledDistance}";
            }
        }
    }
}
