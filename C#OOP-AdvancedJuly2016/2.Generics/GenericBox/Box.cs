using System;
using System.Collections.Generic;

namespace GenericBox
{
    public class Box<T>
    {
        private List<T> collection;

        public Box()
        {
            this.collection = new List<T>();
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentException("Null is not allowed here!");
            }
            this.collection.Add(element);
        }

        public List<T> GetCollection => this.collection;

        public T this[int index]
        {
            get
            {
                return this.collection[index];
            }
            set
            {
                this.collection[index] = value;
            }
        }

        public override string ToString()
        {
            return typeof(T).FullName;
        }

        public void SwapIndexes(int firstIndex, int secondIndex)
        {
            var a = collection[secondIndex];
            var b = collection[firstIndex];
            collection[firstIndex] = a;
            collection[secondIndex] = b;
        }

        public int CompareTo(List<T> list, double item)
        {
            int counter = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (item.CompareTo(list[i]) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public int CompareTo(List<T> list, string item)
        {
            int counter = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (item.CompareTo(list[i]) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
