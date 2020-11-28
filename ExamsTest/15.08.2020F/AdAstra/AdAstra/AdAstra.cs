using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class AdAstra
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Food> foods = new List<Food>();

            var newRegex = new Regex(@"(#|\|)([A-zA-z ]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d+)\1");
            var matches = newRegex.Matches(input);

            foreach (var match in matches)
            {
                char[] delimiter = new char[] { '#', '|' };

                string [] foodInfo = match.ToString().Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToArray();

                Food newFood = new Food(foodInfo[0], foodInfo[1], int.Parse(foodInfo[2]));
                foods.Add(newFood);
            }

            int totalCalories = foods.Sum(x => x.Calories);
            int days = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");
            
            if (foods.Count > 0)
            {
                foods.ForEach(x => Console.WriteLine(x));
            }
        }
        class Food
        {
            public string Name { get; set; }
            public string Date { get; set; }
            public int Calories { get; set; }

            public Food(string name, string date, int cal)
            {
                this.Name = name;
                this.Date = date;
                this.Calories = cal;
            }

            public override string ToString()
            {
                return $"Item: {this.Name}, Best before: {this.Date}, Nutrition: {this.Calories}";
            }
        }
    }
}
