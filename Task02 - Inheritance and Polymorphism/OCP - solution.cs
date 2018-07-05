using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp
{
    interface ISort
    {
        void Sort(ref List<int> L);
    }

    class BubbleSort : ISort
    {
        public void Sort(ref List<int> L)
        {
            bool ok = false;
            while (!ok)
            {
                ok = true;
                for (var i = 0; i < L.Count - 1; ++i)
                    if (L[i] > L[i + 1])
                    {
                        int aux = L[i];
                        L[i] = L[i + 1];
                        L[i + 1] = aux;
                        ok = false;
                    }
            }
        }
    }

    class InjectionSort : ISort
    {
        public void Sort(ref List<int> L)
        {
            for (var i = 0; i < L.Count; ++i)
            {
                int j = i;
                while (j > 0 && L[j] < L[j - 1])
                {
                    int aux = L[j];
                    L[j] = L[j - 1];
                    L[j - 1] = aux;
                    j--;
                }
            }
        }
    }

    class Multime
    {
        ISort algorithm;
        List<int> L;
        public Multime(ISort algorithm,List<int> L)
        {
            this.algorithm = algorithm;
            this.L = L;
        }

        public void ChangeSortingAlgorithm(ISort algorithm)
        {
            this.algorithm = algorithm;
        }

        public void Sort()
        {
            algorithm.Sort(ref L);
        }

        public void Afis()
        {
            foreach (var i in L)
                Write(i.ToString() + " ");
            WriteLine();
        }
    }
   class Program
    {

        public static void Main()
        {
            Multime M = new Multime(new BubbleSort(), new List<int> { 2, 5, 1, 3, 4 });
            M.Afis();
            M.ChangeSortingAlgorithm(new InjectionSort());
            M.Sort();
            M.Afis();
        }
    }
}
