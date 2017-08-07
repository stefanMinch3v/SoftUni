namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            List<Person> humans = new List<Person>();
            var input = Console.ReadLine();
            while (input != "END")
            {
                var commandLine = input.Split();
                string name = commandLine[0];
                int age = int.Parse(commandLine[1]);
                string town = commandLine[2];

                Person person = new Person(name, age, town);
                humans.Add(person);

                input = Console.ReadLine();
            }

            int searchCommand = int.Parse(Console.ReadLine());
            int result = 0;
            int equals = 0;
            int different = 0;
            var currentPerson = humans[searchCommand - 1];

            for (int i = 0; i < humans.Count; i++)
            {
                var comparer = new PersonComparator();
                result = comparer.Compare(currentPerson, humans[i]);
                if (result == 0)
                {
                    equals++;
                }
                else
                {
                    different++;
                }
            }

            if (equals < 2)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equals} {different} {humans.Count}");
            }
             
        }
    }
}
