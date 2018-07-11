using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp
{
    
    class Car
    {
        private String Color;
        public String Name;
        private int numOfSeats;

        public Car(String Color,String Name,int numOfSeats)
        {
            this.Color = Color;
            this.Name = Name;
            this.numOfSeats = numOfSeats;
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            // Reference Type
            var Ford = new Car("Red", "Ford Focus", 5);
            Ford = new Car("asdas", "asdas", 2);
            var Opel = Ford;
            Opel.Name = "Opel";
            //Value Type
            int x = 10;
            int y = x;
            y = 20;
            WriteLine(x);
        } 
    }
}
