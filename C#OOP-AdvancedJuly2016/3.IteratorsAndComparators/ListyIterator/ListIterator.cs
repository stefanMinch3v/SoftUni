namespace ListyIteratorSolution
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListIterator<T> : IEnumerable<T>, IEnumerator<T>
    {
        private readonly List<T> myList;
        private int currentElement;

        public ListIterator()
        {
            this.myList = new List<T>();
            Reset();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //for (int i = 0; i < myList.Count; i++) // Easy to manipulate and put whatever you want conditions on it
            //{
            //     yield return myList[i];
            //}
            return this.myList.GetEnumerator(); // the default foreach 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.myList.GetEnumerator();
        }
        public T Current
        {
            get
            {
                if (myList.Count == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }
                return this.myList[currentElement];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (myList.Count == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }
                return this.myList[currentElement];
            }
        }

        public bool MoveNext()
        {
            if (HasNext())
            {
                if (currentElement >= myList.Count)
                {
                    throw new ArgumentException("Invalid Operation!");
                }
                currentElement++;
                return true;
            }

            return false;
        }

        public void AddRange(T[] elements)
        {
            myList.AddRange(elements);
        }

        public bool HasNext()
        {
            for (int i = currentElement; i < myList.Count - 1; i++)
            {
                if (myList[i + 1] != null)
                {
                    return true;
                }
            }
            return false;
        }


        public void Dispose()
        {
        }

        public void Reset()
        {
            this.currentElement = 0;
        }

    }
}
