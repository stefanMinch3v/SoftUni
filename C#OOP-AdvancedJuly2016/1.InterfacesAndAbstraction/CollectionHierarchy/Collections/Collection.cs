using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Collections
{
    public abstract class Collection
    {
        const int MaxCapacity = 100;
        private List<string> elements;

        protected Collection()
        {
            this.elements = new List<string>(MaxCapacity);
        }

        public List<string> Elements
        {
            get
            {
                return this.elements;
            }
        }

    }
}
