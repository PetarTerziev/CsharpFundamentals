using System;
using System.Linq;

namespace TheLift
{
    class TheLift
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] wagon = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < wagon.Length; i++)
            {
                int peopleBoarding = 4 - wagon[i];

                if (people - peopleBoarding >= 0)
                {
                    wagon[i] += peopleBoarding;
                    people -= peopleBoarding;
                }
                else
                {
                    wagon[i] += people;
                    people = 0;
                }
            }

            int peopleBoarded = 0;

            for (int i = 0; i < wagon.Length; i++)
            {
                peopleBoarded += wagon[i];
            }

            string msg = string.Empty;
            int maxCapacity = wagon.Length * 4;

            if (people == 0 && maxCapacity > peopleBoarded)
            {
                msg = $"The lift has empty spots!";
                msg += $"\n{string.Join(" ", wagon)}";
            }
            else if (people > 0 && maxCapacity == peopleBoarded)
            {
                msg = $"There isn't enough space! {people} people in a queue!";
                msg += $"\n{string.Join(" ", wagon)}";
            }
            else if (people == 0 && maxCapacity == peopleBoarded)
            {
                msg += $"{string.Join(" ", wagon)}";
            }

            Console.WriteLine(msg);
        }
    }
}
