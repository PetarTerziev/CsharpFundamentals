using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    class OldestFamilyMember
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] memberInfo = Console.ReadLine().Split().ToArray();
                Person newPerson = new Person(memberInfo[0], int.Parse(memberInfo[1]));
                family.AddMember(family, newPerson);
            }

            Console.WriteLine(family.GetOldestMember());
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }

        class Family
        {
            public List<Person> FamilyList { get; set; }

            public Family()
            {
                this.FamilyList = new List<Person>();
            }

            public Family AddMember(Family family, Person person) 
            {
                if (!family.FamilyList.Any(x => x.Name == person.Name))
                {
                    family.FamilyList.Add(person);
                }

                return family;
            }

            public string GetOldestMember() 
            {
                this.FamilyList = this.FamilyList.OrderByDescending(x => x.Age).ToList();

                return $"{this.FamilyList[0].Name} {this.FamilyList[0].Age}";
            }
        }
    }
}
