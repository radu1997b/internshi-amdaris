using System;
using System.Collections.Generic;
using static System.Console;
using System.Collections;

namespace ConsoleApp
{
    class MyList<T> : ICollection<T>, IEnumerable<T> where T : IEquatable<T>
    {

        private T[] arr;
        private int capacity;
        public int Count { get; private set; }
        public bool IsReadOnly { get; }
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
        public void Clear()
        {
            arr = new T[5];
            capacity = 5;
            Count = 0;
        }
        public bool Contains(T element)
        {
            for (var i = 0; i < Count; ++i)
                if (element.Equals(arr[i]))
                    return true;
            return false;
        }
        public void CopyTo(T[] array, int position)
        {
            for (int i = 0; i < Count; ++i, ++position)
            {
                array[position] = arr[i];
            }
        }
        public bool Remove(T element)
        {
            for (var i = 0; i < Count; ++i)
                if (element.Equals(arr[i]))
                {
                    for (var j = i + 1; j < Count; ++j)
                        arr[j - 1] = arr[j];
                    Count--;
                    return true;
                }
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnum<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListEnum<T>(this);
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
        private class ListEnum<T> : IEnumerator<T> where T:IEquatable<T>
        {
            private MyList<T> L;
            private int currentIndex = -1;
            public ListEnum(MyList<T> L)
            {
                this.L = L;
            }
            public bool MoveNext()
            {
                currentIndex++;
                return (currentIndex < L.Count);
            }
            public void Reset()
            {
                currentIndex = -1;
            }
            public object Current
            {
                get
                {
                    if (currentIndex < 0 || currentIndex >= L.Count)
                        throw new InvalidOperationException();
                    return L[currentIndex];
                }
            }
            T IEnumerator<T>.Current
            {
                get
                {
                    if (currentIndex < 0 || currentIndex >= L.Count)
                        throw new InvalidOperationException();
                    return L[currentIndex];
                }
            }
            void IDisposable.Dispose()
            {
                
            }
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
            L.Add("asdsad");
            L.Add("sdfdsf");
            foreach (var i in L)
                WriteLine(i);
        }
    }
}