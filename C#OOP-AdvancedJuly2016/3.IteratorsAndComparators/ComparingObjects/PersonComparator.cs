using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class PersonComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Name.CompareTo(y.Name);
            if (result == 0)
            {
                result = x.Age.CompareTo(y.Age);
                if (result == 0)
                {
                    result = x.Town.CompareTo(y.Town);
                }
            }

            return result;
        }
    }
}
