namespace LiveExercises
{
    using System.Linq;
    using System;

    public class Startup
    {
        public static void Main()
        {
            var entity = new SoftUniContext();
            var myCat = new Cat();
            myCat.Name = "Petar";
            myCat.Age = 115;
            Console.WriteLine($"{myCat.Name} -- {myCat.Age}");
            
        }
    }
}
