using System;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Collections
{
    public class AddCollection : Collection, IAddable
    {
        public int Add(string element)
        {
            base.Elements.Add(element);
            return Elements.Count - 1;
        }
    }
}
