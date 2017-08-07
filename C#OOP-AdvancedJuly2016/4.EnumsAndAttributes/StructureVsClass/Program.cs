using System;

namespace StructureVsClass
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // class is refferent type - when you invoke it in method it will change the refference that point to the heap , not copy the whole class in the stack
            var cat = new Cat();
            cat.Name = "Tom";
            ChangeCatName(cat);
            Console.WriteLine(cat.Name);


            // structures are not refferent type (primitive types) and when you invoke the method with struct it will make a copy of the same struct but with new values (for instance : int, date, long..... exception is string because it's class but it has its own implementation), copy-paste the whole struct in the stack, there is nothing to do in the heap!
            // also struct has always an empty constructor inside it !
            var dog = new Dog();
            dog.Name = "Gosho";
            ChangeDog(dog);
            Console.WriteLine(dog.Name);
        }

        public static void ChangeCatName(Cat cat)
        {
            cat.Name = "Pesho";
        }

        public static void ChangeDog(Dog dog)
        {
            dog.Name = "Ivan";
        }
    }

    public class Cat
    {
        public string Name { get; set; }
    }

    public struct Dog
    {
        public string Name { get; set; }
    }
}
