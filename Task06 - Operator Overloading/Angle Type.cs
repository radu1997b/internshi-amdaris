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

        private int degrees;
        private int minutes;
        private int seconds;
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
            this.degrees = degrees;
            this.minutes = minutes;
            this.seconds = seconds;
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            Angle otherAngle = obj as Angle;
            if (otherAngle != null)
            {
                if (degrees != otherAngle.degrees)
                    return degrees - otherAngle.degrees;
                else if (minutes != otherAngle.minutes)
                    return minutes - otherAngle.minutes;
                return seconds - otherAngle.seconds;
            }
            else throw new ArgumentException("Object is not an Angle");
        }
        public static Angle operator+ (Angle a,Angle b)
        {
            Angle result = new Angle();
            result.seconds = a.seconds + b.seconds;
            if (result.seconds >= 60)
            {
                result.minutes++;
                result.seconds %= 60;
            }
            result.minutes += a.minutes + b.minutes;
            if(result.minutes >= 60)
            {
                result.degrees++;
                result.minutes %= 60;
            }
            result.degrees += a.degrees + b.degrees;
            return result;
        }
        public static Angle operator- (Angle a,Angle b)
        {
            Angle result = new Angle();
            result.seconds = a.seconds - b.seconds;
            if(result.seconds < 0)
            {
                result.seconds += 60;
                result.minutes--;
            }
            result.minutes += a.minutes - b.minutes;
            if(result.minutes < 0)
            {
                result.degrees--;
                result.minutes += 60;
            }
            result.degrees += a.degrees - b.degrees;
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
            return degrees + minutes + seconds;
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
            return $"{degrees} deg {minutes}' {seconds}''";
        }

    }
    class Program
    {
        static void Main()
        {
            Angle a1 = new Angle(12, 45, 45);
            Angle a2 = new Angle(2, 34, 55);
            WriteLine(a1 >= a2);
            a1 += a2;
        }
    }
}