using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogueExercises
{
    class VehicleCatalogueExercises
    {
        static void Main(string[] args)
        {
            var catalog = new Catalog();

            while (true)
            {
                string[] vehicle = Console.ReadLine().Split().ToArray();

                if (vehicle[0] == "End")
                {
                    break;
                }

                if (vehicle[0] == "car")
                {
                    Car newCar = Car.ReadNewCar(vehicle);
                    catalog.Cars.Add(newCar);
                }
                else
                {
                    Truck newTruck = Truck.ReadNewTruck(vehicle);
                    catalog.Trucks.Add(newTruck);
                }
            }

            while (true)
            {
                string vehicleModel = Console.ReadLine();

                if (vehicleModel == "Close the Catalogue")
                {
                    break;
                }

                if (catalog.Cars.Any(x => x.Model == vehicleModel))
                {
                    Console.WriteLine(catalog.Cars.Where(x => x.Model == vehicleModel).ToString());
                }
                if (catalog.Trucks.Any(x => x.Model == vehicleModel))
                {
                    Console.WriteLine(catalog.Trucks.First(x => x.Model == vehicleModel));
                }

                Catalog.PrintVehicles(catalog.Cars, vehicleModel);
                Catalog.PrintVehicles(catalog.Trucks, vehicleModel);
            }

            double averageHorsePowerCars = catalog.Cars.Sum(c => int.Parse(c.HorsePower));
            double countCars = catalog.Cars.Count();
            double averageHorsePowerTrucks = catalog.Trucks.Sum(c => int.Parse(c.HorsePower));
            double countTrucks = catalog.Trucks.Count();
            double carsAverageHPCars = averageHorsePowerCars / countCars;
            double trucksAverageHPCars = averageHorsePowerTrucks / countTrucks;

            carsAverageHPCars = countCars == 0 ? 0 : carsAverageHPCars;
            trucksAverageHPCars = countTrucks == 0 ? 0 : trucksAverageHPCars;

            Console.WriteLine($"Cars have average horsepower of: {carsAverageHPCars:f2}.");

            Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHPCars:f2}.");


        }
        class Truck
        {
            public string Model { get; set; }
            public string Color { get; set; }
            public string HorsePower { get; set; }

            public static Truck ReadNewTruck(string[] vehicleInfo)
            {
                Truck newTruck = new Truck();

                newTruck.Model = vehicleInfo[1];
                newTruck.Color = vehicleInfo[2];
                newTruck.HorsePower = vehicleInfo[3];

                return newTruck;
            }

        }
        class Car
        {
            public string Model { get; set; }
            public string Color { get; set; }
            public string HorsePower { get; set; }

            public static Car ReadNewCar(string[] vehicleInfo)
            {
                Car newCar = new Car();

                newCar.Model = vehicleInfo[1];
                newCar.Color = vehicleInfo[2];
                newCar.HorsePower = vehicleInfo[3];

                return newCar;
            }
        }

        class Catalog
        {
            public Catalog()
            {
                Trucks = new List<Truck>();
                Cars = new List<Car>();
            }
            public List<Truck> Trucks { get; set; }
            public List<Car> Cars { get; set; }

            public static void PrintVehicles(List<Car> cars, string filter)
            {
                foreach (var car in from car in cars
                                    where car.Model == filter
                                    select new {car.Model, car.Color, car.HorsePower})
                {
                    if (car.Model == null) 
                    {
                        break;
                    }

                    Console.WriteLine("Type: Car");
                    Console.WriteLine($"Model: {car.Model}\nColor: " +
                                      $"{car.Color}\nHorsepower: {car.HorsePower}");
                }
            }
            public static void PrintVehicles(List<Truck> trucks, string filter)
            {

                foreach (var truck in from truck in trucks
                                      where truck.Model == filter
                                      select new { truck.Model, truck.Color, truck.HorsePower})
                {
                    if (truck.Model == null)
                    {
                        break;
                    }

                    Console.WriteLine("Type: Truck");
                    Console.WriteLine($"Model: {truck.Model}\nColor:" +
                                     $" {truck.Color}\nHorsepower: {truck.HorsePower}");
                }
            }
        }
    }
}
