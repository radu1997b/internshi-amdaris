using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Linq.ExtensionMethods;

namespace Linq
{
    public delegate bool IsGreater(Person P1, Person P2);
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; }
        public string Surname { get; }
        public Person(string name,string surname,int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        public override string ToString()
        {
            return Name + " " + Surname + String.Format(" - {0} age old.", Age);
        }
    }
    class Program
    {
        static Person maxim(List<Person> L,IsGreater isGreater)
        {
            Person result = L[0];
            for (var i = 1; i < L.Count; ++i)
                if (isGreater(L[i], result))
                    result = L[i];
            return result;
        }
        public static bool AIsGreaterThanB(Person P1,Person P2)
        {
            return P1.Age > P2.Age;
        }
        static void Main(string[] args)
        {
            List<Person> Persons = new List<Person> { new Person("Ion", "Andrei", 20), new Person("Vasile", "Macovei", 13), new Person("Ion", "Creanga", 45) };
            //Creating a new instance of IsGreater delegate
            IsGreater F = new IsGreater(AIsGreaterThanB);
            Person result = maxim(Persons, F);
            WriteLine(result);
            //Using anonymous delegate
            result = maxim(Persons, delegate (Person P1, Person P2) {
                return P1.Age < P2.Age;
            });
            WriteLine(result);
            //using lambda expresions
            result = maxim(Persons, (a, b) => {
                return a.Age > b.Age;
            });
            WriteLine(result);
            //using an extension method
            int res = Persons.GetNumOfAdultPersons();
            WriteLine("Num of adult persons: {0}", res);
            var query = Persons.Where(p => p.Name.Contains('a'));
            foreach (var q in query)
                WriteLine(q);
            WriteLine();
            var query2 = Persons.Select(p => new Person(p.Name,p.Surname,++p.Age));
            foreach (var q in query2)
                WriteLine(q);
        }
    }
}
