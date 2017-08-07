using System;

namespace AttributeShowing
{
    [Serializable, Author]
    public class Startup
    {
        public static void Main()
        {
            var attributes = typeof(Startup).GetCustomAttributes(false);

            foreach (var attr in attributes)
            {
                if (attr is SerializableAttribute)
                {
                    Console.WriteLine("It is serializable");
                }
                else if (attr is AuthorAttribute)
                {
                    Console.WriteLine("author attribute");
                }
            }

            Console.WriteLine("////");//line for the next example 


            //if you have [Flags] attribute "var value" can keep all of the values like a collection otherwise it will save only the last one - in our case "Write"
            var value = Permissions.Read | Permissions.Write;
            if (value.HasFlag(Permissions.Read))
            {
                Console.WriteLine("Readddddddddd");
            }
        }
    }

    [Flags]
    public enum Permissions
    {
        Write,
        Read,
        Test
    }
}
