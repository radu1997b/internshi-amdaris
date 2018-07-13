using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp
{

    class Angle : IComparable
    {

        public int Degrees { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
        public Angle(int degrees = 0, int minutes = 0, int seconds = 0)
        {
            if (minutes < 0 || minutes >= 60)
            {
                minutes = 0;
            }
            if(seconds < 0 || seconds >= 60)
            {
                seconds = 0;
            }
            this.Degrees = degrees;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            Angle otherAngle = obj as Angle;
            if (otherAngle != null)
            {
                if (Degrees != otherAngle.Degrees)
                    return Degrees - otherAngle.Degrees;
                else if (Minutes != otherAngle.Minutes)
                    return Minutes - otherAngle.Minutes;
                return Seconds - otherAngle.Seconds;
            }
            else throw new ArgumentException("Object is not an Angle");
        }
        public static Angle operator+ (Angle a,Angle b)
        {
            Angle result = new Angle();
            result.Seconds = a.Seconds + b.Seconds;
            if (result.Seconds >= 60)
            {
                result.Minutes++;
                result.Seconds %= 60;
            }
            result.Minutes += a.Minutes + b.Minutes;
            if(result.Minutes >= 60)
            {
                result.Degrees++;
                result.Minutes %= 60;
            }
            result.Degrees += a.Degrees + b.Degrees;
            return result;
        }
        public static Angle operator- (Angle a,Angle b)
        {
            Angle result = new Angle();
            result.Seconds = a.Seconds - b.Seconds;
            if(result.Seconds < 0)
            {
                result.Seconds += 60;
                result.Minutes--;
            }
            result.Minutes += a.Minutes - b.Minutes;
            if(result.Minutes < 0)
            {
                result.Degrees--;
                result.Minutes += 60;
            }
            result.Degrees += a.Degrees - b.Degrees;
            return result;
        }
        public override bool Equals(object obj)
        {
            Angle otherAngle = obj as Angle;
            if (otherAngle == null)
                return false;
            return CompareTo(otherAngle) == 0;
        }
        public override int GetHashCode()
        {
            return Degrees + Minutes + Seconds;
        }
        public static bool operator!= (Angle a,Angle b)
        {
            return a.CompareTo(b) != 0;
        }
        public static bool operator== (Angle a,Angle b)
        {
            return !(a != b);
        }
        public static bool operator< (Angle a,Angle b)
        {
            return a.CompareTo(b) < 0;
        }
        public static bool operator> (Angle a,Angle b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator>= (Angle a,Angle b)
        {
            return a.CompareTo(b) >= 0;
        }
        public static bool operator<= (Angle a,Angle b)
        {
            return !(a > b);
        }
        public override string ToString()
        {
            return $"{Degrees} deg {Minutes}' {Seconds}''";
        }

    }

    class SortAnglesBySeconds : IComparer<Angle>
    {
        public int Compare(Angle x, Angle y)
        {
            return x.Seconds - y.Seconds;
        }
    }
    class Program
    {
        static void Main()
        {
            List < Angle > L = new List<Angle>(new Angle[] { new Angle(1, 2, 3), new Angle(34, 2, 3), new Angle(4, 3, 2), new Angle(34, 56, 32) });
            L.Sort();
            foreach (var angle in L)
                WriteLine(angle);
         }
    }
}