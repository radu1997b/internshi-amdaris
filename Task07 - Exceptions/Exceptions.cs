using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;

namespace ConsoleApp
{

   class Program
    {
        //Create custom exception
        class InvalidNameFormatException : Exception
        {
            public InvalidNameFormatException()
            {
            }

            public InvalidNameFormatException(string name) : base(String.Format("Invalid Format of {0}", name))
            {
                
            }
            
        }
        class InvalidAgeException : Exception
        {
            public InvalidAgeException()
            {

            }
            public InvalidAgeException(string age) : base("Invalid Age: " + age)
            {

            }
        }
        class Person
        {
            public String Name { get; set; }
            public String Surname { get; set; }
            public int Age { get; set; }
            public Person(String name,String surname,int age)
            {
                
                //throw base exception
                if (age < 0)
                    throw new Exception("Invalid Age");
                Name = name;
                Age = age;
                Surname = surname;
            }
        }

        static void PrintPersonName(Person P)
        {
            //Check input and throw error
            if (P == null) 
                throw new ArgumentNullException($"Person");
            WriteLine("Person Name: {0}", P.Name);
            //using conditional compilation
#if DEBUG
            Debug.WriteLine("Person Name: " + P.Name);
#endif
        }
        static String getNewSurname()
        {
            return "adsad";
        }
        static void CheckPersonDetails(Person P)
        {
            try
            {
                if (P.Age < 18)
                    throw new Exception("Invalid Age");
                int letters = 0;
                foreach (var c in P.Name)
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                        letters++;
                //throw custom exception
                if (letters != P.Name.Length)
                    throw new InvalidNameFormatException("Name");
                letters = 0;
                foreach (var c in P.Surname)
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                        letters++;
                //throw custom exception
                if (letters != P.Surname.Length)
                    throw new InvalidNameFormatException("Surname");
            }
            //catch exceptions
            catch(InvalidNameFormatException ex) when (ex.Message.Contains("Name"))
            {
                WriteLine("Name is invalid.");
                StackTrace t = new StackTrace(true);
                foreach (var i in t.GetFrames())
                    WriteLine(i.GetFileName() + " " + i.GetMethod() + " " + i.GetFileLineNumber());

                
            }
            catch(InvalidNameFormatException ex) when (ex.Message.Contains("Surname"))
            {
                WriteLine("Surname is invalid.");
                StackTrace t = new StackTrace(true);
                foreach(var i in t.GetFrames())
                    WriteLine(i.GetFileName() + " " + i.GetMethod() + " " + i.GetFileLineNumber());

            }
            catch(Exception ex)
            {
               
                if (ex.Message.Contains("Age"))
                    throw new InvalidAgeException();
            }
            finally
            {
                WriteLine("Data processed succesfully");
            }

        }

        static void Main(String[] args)
        {
            Person P = new Person("Ion23","Rusu231",20);
            PrintPersonName(P);
            CheckPersonDetails(P);
            WriteLine("Program terminated!");
        }
    }
}