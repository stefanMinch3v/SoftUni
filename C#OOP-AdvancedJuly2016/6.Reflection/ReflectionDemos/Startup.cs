namespace ReflectionDemos
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Startup
    {
        public static void Main()
        {
            var obj = new object();
            Type typeOfObj = obj.GetType();

            Type typeOfCat = new Cat().GetType();
            //or
            var typeOfCat2 = typeof(Cat);
            var typeOfAnimal = typeof(Cat).BaseType;
            var typeOfAllInterfaces = typeOfAnimal.GetInterfaces();

            //var typesInCurrentAssembly = Assembly.GetEntryAssembly().GetTypes().Where(t => t.IsInterface);
            //foreach (var type in typesInCurrentAssembly)
            //{
            //    Console.WriteLine(type.Name);
            //}

            //Console.WriteLine(typeOfCat.Name);
            // Console.WriteLine(typeOfCat.FullName);

            //Console.WriteLine(typeOfAnimal.Name);

            //foreach (var interf in typeOfAllInterfaces)
            //{
            //    Console.WriteLine(interf.Name);
            //}

            //foreach (var prop in typeOfCat.GetProperties())
            //{
            //    Console.WriteLine($"{prop.Name} -> {prop.PropertyType.Name}");
            //}


            //works only if the Cat class has an empty constructor otherwise it won't work
            var cat = (Cat)Activator.CreateInstance(typeof(Cat));
            //it is equal to 
            var anotherCat = new Cat();

            //with constructor (string name for example)
            var cat2 = (Cat)Activator.CreateInstance(typeof(Cat), "Pesho");

            //native way
            var cat3 = CreateInstance<Cat>();

            //fields GetFields(BindingFlags...) to get all the static,private or public fields

            var constructor = typeof(Cat).GetConstructor(new[] { typeof(string) });
            var createCat = constructor.Invoke(new[] { "Ivan" });
        }

        public static T CreateInstance<T>()
            where T : class, new()
        {
            return new T();
        }
    }
}
