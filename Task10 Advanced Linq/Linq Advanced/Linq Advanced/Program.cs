using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Linq_Advanced
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
            public Person(string name,string surname,int age)
            {
                Name = name;
                Surname = surname;
                Age = age;
            }
            public override string ToString()
            {
                return Name + " " + Surname + " - " + Age.ToString() + " years old.";
            }
        }
        class Child
        {
            public string Name { get; set; }
            public string FatherName { get; set; }
            public Child(string name,string fatherName)
            {
                Name = name;
                FatherName = fatherName;
            }
        }
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>(new Person[] { new Person("Creanga", "Ion", 55),
                                                                      new Person("Eminescu", "Mihai", 35),
                                                                      new Person("Alexandru", "Ion", 44),
                                                                      new Person("Ion", "Andrei", 13),
                                                                      new Person("Vasile","Blaga",41)});
            List<Child> childList = new List<Child>(new Child[] { new Child("Radu", "Creanga"), new Child("Cristian", "Alexandru") });
            //Filtering operator
            WriteLine("Filtering operation result:");
            var result = personList.Where(p => p.Age > 40).Skip(1);
            foreach (var r in result)
                WriteLine(r);
            //Projection operator
            WriteLine("\nProjection operator result:");
            var projectionResult = personList.Select(p => p.Name + " " + p.Surname);
            foreach (var r in projectionResult)
                WriteLine(r);
            //Join operators
            WriteLine("\nOrdering operator result:");
            var joinResult = personList.Join(childList, parent => parent.Name,
                                             child => child.FatherName,
                                             (parent, child) => new { FatherName = parent.Name + " " + parent.Surname, ChildName = child.Name });
            foreach (var r in joinResult)
            {
                WriteLine("Dad\'s name: " + r.FatherName + "\nSon\'s name:" + r.ChildName);
            }
            WriteLine("\nOrdering query result:");
            //Ordering operator
            var orderingResult = personList.OrderBy(p => p.Name).ThenBy(p => p.Surname).ThenBy(p => p.Age);
            foreach (var r in orderingResult)
                WriteLine(r);
            //Gropuing operator
            WriteLine("\nGrouping operator result:");
            var groupResult = personList.GroupBy(x => x.Age );
            foreach (var r in groupResult)
            {
                foreach (var p in r)
                    Write(p);
                WriteLine();
            }
            //Set operator 
            List<int> num1 = new List<int>(new int[] { 1, 2, 3, 4 });
            List<int> num2 = new List<int>(new int[] { 3, 4, 5, 6 });
            WriteLine("\nSet operator result:");
            var setOpResult = num1.Intersect(num2);
            foreach (var r in setOpResult)
                Write(r + " ");
            //Conversion operator
            WriteLine("\n\nConversion operator result:");
            var toArrayResult = personList.Where(p => p.Age > 40).ToList();
            foreach (var i in toArrayResult)
                WriteLine(i);
            //Element operation
            WriteLine("\nElement Operation:");
            var elementOp = personList.Last();
            WriteLine(elementOp);
            //Aggregation method
            WriteLine("\nAggregation method:");
            var aggregationResult = personList.Count();
            WriteLine(aggregationResult);
            WriteLine("\nQuantifier operator:");
            var quantifierOperator = personList.Any(p => p.Age == 12);
            WriteLine(quantifierOperator);
        }
    }
}