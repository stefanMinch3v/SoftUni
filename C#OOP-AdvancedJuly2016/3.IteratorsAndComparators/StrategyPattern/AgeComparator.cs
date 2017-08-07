using System.Collections.Generic;

namespace StrategyPattern
{
    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y) =>  x.Age.CompareTo(y.Age);  
    }
}
