using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    

    class Program
    {

        static int sumOf(int[] arr)
        {
            var sum = 0;
            for (var i = 0; i < arr.Length; ++i)
                sum += arr[i];
            return sum;
        }

        static void DeleteEven(ref int[] arr)
        {
            int[] newArr = new int[arr.Length];
            int nrEven = 0;
            for (int i = 0; i < arr.Length; ++i)
                if (arr[i] % 2 == 0)
                    newArr[nrEven++] = arr[i];
            Array.Resize(ref newArr, nrEven);
            arr = newArr;
        }

        static int[][] mult(int[][] a,int[][] b)
        {

            if (a[0].Length != b.Length)
                throw new Exception("Nu se pot inmulti matricile date!");
            int[][] rez = new int[a.Length][];
            for (int i = 0; i < rez.Length; ++i)
                rez[i] = new int[b[0].Length];
            for (int i = 0; i < a.Length; ++i)
                for (int j = 0; j < b[0].Length; ++j)
                    for (int k = 0; k < b.Length; ++k)
                        rez[i][j] += a[i][k] * b[k][j];
            return rez;
        }

        static void InsertAfterMin(ref int[][] a)
        {
            int min = int.MaxValue;
            int minRowInd = 0;
            for (int i = 0; i < a.Length; ++i)
                for (int j = 0; j < a[i].Length; ++j)
                   if(min > a[i][j])
                    {
                        min = a[i][j];
                        minRowInd = i;
                    }
            Array.Resize(ref a, a.Length + 1);
            for (int i = a.Length - 1; i >= minRowInd + 2; --i)
                a[i] = a[i - 1];
            a[minRowInd + 1] = new int[a[0].Length];
        }


        static void FirsAndLastIndexOf(String S,char C,out int first,out int last)
        {
            first = last = -1;
            for (int i = 0; i < S.Length; ++i)
                if (S[i] == C && first == -1)
                {
                    first = last = i;
                }
                else if (S[i] == C)
                    last = i;
        }

        static String DeleteAllWordsContainsX(String S,char C)
        {
            var arr = S.Split(' ');
            String[] rez = new string[arr.Length];
            int count = 0;
            foreach (var elem in arr)
                if (!elem.Contains(C))
                    rez[count++] = elem;
            Array.Resize(ref rez, count);
            return String.Join(" ", rez);
        }

        static int pow(int b,int exp)
        {
            if (exp < 1)
                throw new Exception("Exxponent is less than 1");
            if (exp == 1)
                return b;
            if (exp % 2 == 0)
                return pow(b * b, exp / 2);
            return b * pow(b, exp - 1);
        }

        public static void Main(String[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            DeleteEven(ref arr);
            for (var i = 0; i < arr.Length; ++i)
                Console.Write(arr[i].ToString() + " ");
            Console.WriteLine();
            int[][] arr2 =new int[][] { new int[] { 1, 5, 6, 4 }, new int[] { 3, 4, 5, 6 }, new int[] { 5, 6, 7, 8 } };
            InsertAfterMin(ref arr2);
            for(int i = 0; i < arr2.Length; ++i)
            {
                for (int j = 0; j < arr2[i].Length; ++j)
                    Console.Write(arr2[i][j].ToString() + " ");
                Console.WriteLine();
            }
            String s = "sfsdf";
            s = s.Insert(1, "dfsdf");
            Console.WriteLine(s);
            StringBuilder sb = new StringBuilder("gdgdfgdfg", 100);
            sb.Remove(0, 2);
            Console.WriteLine(sb);
            String S = DeleteAllWordsContainsX("sadax fsdfx dfsdfx fsdfxdgdf sda sadsa sf sad sdx",'x');
            Console.WriteLine(S);
            Console.WriteLine(pow(4, 2));
        }
    }
}