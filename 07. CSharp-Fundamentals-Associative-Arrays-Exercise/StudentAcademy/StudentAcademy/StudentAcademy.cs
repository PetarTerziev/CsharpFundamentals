using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string studentname = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!grades.ContainsKey(studentname))
                {
                    grades.Add(studentname, new List<double>());
                }
                
                grades[studentname].Add(grade);
            }

            foreach (var pair in grades.Where(x => x.Value.Average() >= 4.50).OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value.Average():f2}");
            }
        }
    }
}
