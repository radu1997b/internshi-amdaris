using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp
{
    
    class Person
    {
        static int Count;
        private String Name;
        static Person()
        {
            Count = 0;
        }
        public Person(String Name)
        {
            this.Name = Name;
            Count++;
        }

        public string getName()
        {
            return Name;
            int x = Person.Count();
        }

        public static void NumberOfPersons()
        {
            WriteLine("There are {0} persons.", Count);
            var s = getName();
            var obj = new Person("sfsad");
            obj.getName();
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            var Mihai = new Person("Mihai");
            var Ion = new Person("Ion");
            Person.NumberOfPersons();
        } 
    }
}
