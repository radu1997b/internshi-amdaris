using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp
{

    public enum SortingAlgorithm { BubbleSort, InjectionSort };
    public class Multime
    {

        private List<int> L;
        private SortingAlgorithm algorithm;
        public Multime(SortingAlgorithm algorithm,List<int> L)
        {
            this.algorithm = algorithm;
            this.L = L;
        }
        private void BubbleSortAlgorithm()
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
        private void InjectionSortAlgorithm()
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
        public void Sort()
        {
            switch (algorithm)
            {
                case SortingAlgorithm.BubbleSort:
                    BubbleSortAlgorithm();
                    break;
                case SortingAlgorithm.InjectionSort:
                    InjectionSortAlgorithm();
                    break;
            }
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
            Multime M = new Multime(SortingAlgorithm.BubbleSort, new List<int> { 2, 5, 4, 6, 10, 9, 3 });
            M.Sort();
            M.Afis();
        }
    }
}
