using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    /// <summary>
    /// Sort the person first by name's length and then by the first letter of name case-insensitive. 
    /// </summary>
    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result =  x.Name.Length.CompareTo(y.Name.Length);
            if (result == 0)
            {
                string xFirstChar = x.Name[0].ToString();
                string yFirstChar = y.Name[0].ToString();
                result = string.Compare(xFirstChar, yFirstChar, true);
            }

            return result;
        }
    }
}
