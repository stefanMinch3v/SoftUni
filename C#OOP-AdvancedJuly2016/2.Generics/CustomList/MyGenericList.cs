namespace CustomList
{
    using System;
    using System.Collections;
    using System.Text;

    public class MyGenericList<T> where T:IComparable<T>
    {
        //private List<T> collection;

        private const int InitialCapacity = 16;
        private T[] elements;
        private int count;

        public MyGenericList()
        {
            //this.collection = new List<T>();
            this.elements = new T[InitialCapacity];
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }     
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentException("Index is outside the bounds of the array.");
                }
                return this.elements[index];
            }
        }


        public void Add(T element)
        {
            if (this.count + 1 == this.elements.Length)
            {
                Resize();
            }
            this.elements[this.count] = element;
            Count++;
            
                    
            //this.collection?.Add(element);   
        }

        /// <summary>
        /// Works exactly like List, takes the original array, resize it (twice bigger) and copy it from the beggining.
        /// </summary>
        private void Resize()
        {
            int currentLenght = this.elements.Length;
            T[] newElements = new T[currentLenght * 2];
            Array.Copy(this.elements, newElements, currentLenght);
            this.elements = newElements;
        }

        public bool Contains(T element)
        {
            ValidateOperation();
            for (int i = 0; i < this.Count; i++)
            {
                if (elements[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        private void ValidateIndex(params int[] indices)
        {
            for (int i = 0; i < indices.Length; i++)
            {
                if (indices[i] >= this.Count || indices[i] < 0 )
                {
                    throw new ArgumentException("Index is outside the bounds of the collection");
                }
            }
        }

        public void Swap(int indexSource, int indexDestination)
        {
            ValidateOperation();
            ValidateIndex(indexSource, indexDestination);
            T temp = this.elements[indexSource];
            this.elements[indexSource] = this.elements[indexDestination];
            this.elements[indexDestination] = temp;
        }

        public T Remove(int index)
        {
            ValidateOperation();
            ValidateIndex(index);
            T element = this.elements[index];
            DecreseElementsCount();

            return element;
        }

        private void DecreseElementsCount()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            this.elements[this.Count - 1] = default(T);
            Count--;
        }


        /// <summary>
        /// Gets the number of elements that are greater than the given T element.
        /// </summary>
        /// <param name="element">
        /// Element to compare.
        /// </param>
        /// <returns>
        /// Number of elements.
        /// </returns>
        public int CountGreaterThan(T element)
        {
            int counter = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public T Max()
        {
            ValidateOperation();
            T maxElement = this.elements[0];
            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(maxElement) > 0)
                {
                    maxElement = this.elements[i];
                }
            }

            return maxElement;
        }

        public T Min()
        {
            ValidateOperation();
            T minElement = this.elements[0];
            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(minElement) < 0)
                {
                    minElement = this.elements[i];
                }
            }

            return minElement;
        }

        private void ValidateOperation()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot perform operation on empty sequence");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                sb.AppendLine(this.elements[i].ToString());
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Sort the collection in Ascending order
        /// </summary>
        public void Sort()
        {
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = 0; j < this.Count; j++)
                {
                    if (this.elements[j].CompareTo(this.elements[i]) > 0)
                    {
                        Swap(Array.IndexOf(this.elements, this.elements[j]),Array.IndexOf(this.elements,this.elements[i]));
                    }
                }  
            }

        }

        public void ForEach()
        {
            foreach (var element in this.elements)
            {
                if (element != null)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
