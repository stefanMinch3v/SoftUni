namespace IteratorExercise
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ListIterator
    {
        private List<string> collection;
        private int internalIndex;

        public ListIterator(IEnumerable<string> collection)
        {
            this.Elements = collection.ToList();
            this.internalIndex = 0;
        }

        public ListIterator()
        {
        }

        public int CurrentIndex => this.internalIndex;

        public List<string> Elements
        {
            get
            {
                return this.collection;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null is not accepted!");
                }

                this.collection = value;
            }
        }

        public bool Move()
        {
            if (this.internalIndex + 1 < this.collection.Count)
            {
                this.internalIndex++;
                return true;
            }

            return false;

        }

        public bool HasNext()
        {
            if (this.internalIndex + 1< this.collection.Count)
            {
                return true;
            }

            return false;        
        }

        public string Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation!");
            }

            return this.collection[this.internalIndex];      
        }
    }
}
