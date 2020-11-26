using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Courses
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesList = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] courseInfo = Console.ReadLine().Split(" : ").ToArray();

                string courseName = courseInfo[0];

                if (courseName == "end")
                {
                    break;
                }

                string studentName = courseInfo[1];
                bool isCoursesExist = coursesList.ContainsKey(courseName);

                if (!isCoursesExist)
                {
                    coursesList.Add(courseName, new List<string>());
                }

                coursesList[courseName].Add(studentName);
            }

            foreach (var pair in coursesList.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Count}");

                foreach (var value in pair.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}
