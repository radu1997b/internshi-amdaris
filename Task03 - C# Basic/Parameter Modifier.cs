using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp
{


    class Program
    {
        class Car
        {
            private String Name;
            public Car(String Name)
            {
                this.Name = Name;
            }
            public String ShowName()
            {
                return Name;
            }
        }

        class Person
        {
            private String Name;
            public Person(String Name)
            {
                this.Name = Name;
            }
            public String ShowName()
            {
                return Name;
            }
        }
        static int suma(int a,int b)
        {
            return a + b;
        }
        static void swap(ref int a,ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }
        static void CreateAPersonAndCar(out Person P,out Car C)
        {
            P = new Person("Radu");
            C = new Car("Audi");
        }
        public static void Main(String[] args)
        {
            int a = 1, b = 2;
            WriteLine(suma(a, b));
            swap(ref a, ref b);
            WriteLine("a = " + a.ToString() + ", b = " + b.ToString());
            Person P;
            Car C;
            CreateAPersonAndCar(out P, out C);
            WriteLine("Perons Name: " + P.ShowName() + ", Car Name: " + C.ShowName());
        } 
    }
}
