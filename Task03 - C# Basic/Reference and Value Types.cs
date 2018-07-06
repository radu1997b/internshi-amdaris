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
        private String Name;
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
            //Value Type
            int x = 10;
            WriteLine(x);
        } 
    }
}
