using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split().ToArray();
                Engine newEngine = new Engine(int.Parse(info[1]), int.Parse(info[2]));
                Cargo newCargo = new Cargo(int.Parse(info[3]), info[4]);
                Car newCar = new Car(info[0], newEngine, newCargo);
                cars.Add(newCar);
            }

            string command = Console.ReadLine();
            
            if (command == "fragile")
            {
                var filteredList = cars.Where(x => (x.Cargo.Type == command) && (x.Cargo.Weight < 1000)).ToArray();
                Console.WriteLine(string.Join(Environment.NewLine, filteredList.Select(x => x.Model)));
            }
            else
            {
                var filteredList = cars.Where(x => (x.Cargo.Type == command) && (x.Engine.Power > 250)).ToArray();
                Console.WriteLine(string.Join(Environment.NewLine, filteredList.Select(x => x.Model)));
            }
        }
        class Cargo
        {
            public int Weight { get; set; }
            public string Type { get; set; }

            public Cargo(int weight, string type)
            {
                this.Weight = weight;
                this.Type = type;
            }
        }
        class Engine
        {
            public int Speed { get; set; }
            public int Power { get; set; }

            public Engine(int speed, int power)
            {
                this.Speed = speed;
                this.Power = power;
            }
        }
        class Car
        {
            public string Model { get; set; }
            public Engine Engine { get; set; }
            public Cargo Cargo { get; set; }
            public Car(string model, Engine engine, Cargo cargo)
            {
                this.Model = model;
                this.Engine = engine;
                this.Cargo = cargo;
            }

            public override string ToString()
            {
                return this.Model;
            }
        }
    }
}
