using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;
using System.Collections;

namespace ConsoleApp
{
    class MyList<T> where T : IEquatable<T>
    {

        private T[] arr;
        private int capacity;
        public int Count { get; private set; }
        public MyList()
        {
            arr = new T[5];
            capacity = 5;
        }
        public MyList(int capacity)
        {
            arr = new T[capacity];
            this.capacity = capacity;
        }
        private void CheckPosition(int position)
        {
            if (position < 0 || position >= Count)
                throw new IndexOutOfRangeException();
        }
        public void Add(T element)
        {
            if (capacity == Count)
            {
                capacity += 5;
                Array.Resize(ref arr, capacity);
            }
            Count++;
            arr[Count - 1] = element;
        }
        public void Delete(T element)
        {
            for (var i = 0; i < Count; ++i)
                if (element.Equals(arr[i]))
                {
                    for (var j = i + 1; j < Count; ++j)
                        arr[j - 1] = arr[j];
                    Count--;
                    break;
                }
        }
        public T this[int position]
        {
            get
            {
                CheckPosition(position);
                return arr[position];
            }
            set
            {
                CheckPosition(position);
                arr[position] = value;
            }
        }
        public T GetElementAt(int position)
        {
            return this[position];
        }
        public void ChangeElementAt(int position, T value)
        {
            this[position] = value;
        }
        public void Swap(int index1, int index2)
        {
            CheckPosition(index1);
            CheckPosition(index2);
            T aux = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = aux;
        }
    }
    class Program
    {
        static void Main()
        {
            MyList<String> L = new MyList<String>();
            L.Add("sd");
            L.Add("ds");
            L.Swap(0, 1);
            WriteLine(L[0]);
            WriteLine(L[1]);
        }
    }
}