using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class Startup
    {
        public static void Main()
        {
            SortedSet<Person> byName = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> byAge = new SortedSet<Person>(new AgeComparator());

            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var personDetails = Console.ReadLine().Split();
                var person = new Person(personDetails[0], int.Parse(personDetails[1]));
                byName.Add(person);
                byAge.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine, byName));
            Console.WriteLine(string.Join(Environment.NewLine, byAge));
        }
    }
}
