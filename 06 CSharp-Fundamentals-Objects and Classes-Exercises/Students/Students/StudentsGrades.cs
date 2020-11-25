using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class StudentsGrades
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine().Split().ToArray();
                Student newStudent = new Student(studentInfo[0], studentInfo[1], double.Parse(studentInfo[2]));
                students.Add(newStudent);
            }

            students.Sort((b, a) => a.Grade.CompareTo(b.Grade));

            Student.PrintStudents(students);
        }

        class Student
        {
            public Student(string firstName, string secondName, double grade)
            {
                FirstName = firstName;
                SecondName = secondName;
                Grade = grade;
            }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public double Grade { get; set; }
            public static void PrintStudents(List<Student> students)
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.FirstName} {student.SecondName}: {student.Grade:f2}");
                }
            }
        }
    }
}
