using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class OrderByAge
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            while (true)
            {
                string[] personInfo = Console.ReadLine().Split().ToArray();

                if (personInfo[0] == "End")
                {
                    break;
                }

                Person newPerson = new Person();
                newPerson.Name = personInfo[0];
                newPerson.ID = personInfo[1];
                newPerson.Age = int.Parse(personInfo[2]);
                persons.Add(newPerson);
            }

            Person.PrintPerson(persons);
        }

        class Person
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }

            public static void PrintPerson(List<Person> persons) 
            {
                foreach (var person in persons.OrderBy(p => p.Age))
                {
                    Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
                }
            }
        }

    }
}
