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
       
        public static void Main(String[] args)
        {
            //Boxing and Unboxing
            List<Object> L = new List<Object>();
            for (int i = 0; i < 5; ++i)
                L.Add("Numarul " + i.ToString());
            for (int i = 5; i < 10; ++i)
                L.Add(i);
            for (int i = 0; i < 5; ++i)
                WriteLine((String)L[i]);
            for (int i = 5; i < 10; ++i)
                WriteLine((int)L[i]);
        } 
       
    }
}
