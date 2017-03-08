using System;

namespace BooleanVariable
{
    public class BooleanVariable
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            bool isTrue = Convert.ToBoolean(name);
            Console.WriteLine(isTrue ? "Yes" : "No");
           
        }
    }
}
