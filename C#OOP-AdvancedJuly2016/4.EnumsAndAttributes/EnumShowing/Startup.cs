using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumShowing
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var values = Enum.GetValues(typeof(Color)).OfType<Color>().ToList();
            foreach (var val in values)
            {
                Console.WriteLine(val);
            }


            //Enum.Parse();
            Console.WriteLine("////////");

            var newValues = EnumExtensions.ToStringValues<Color>();
            foreach (var val in newValues)
            {
                Console.WriteLine(val);
            }
        }
    }

    public enum Color
    {
        Red,
        Green,
        Blue
    }


    /// <summary>
    /// works only with Enum types otherwise throw an exception
    /// </summary>
    public static class EnumExtensions
    {
        public static IEnumerable<string> ToStringValues<TEnum>()
            where TEnum  : struct, IComparable, IFormattable, IConvertible
        {
            var typeOfTEnum = typeof(TEnum);

            if (!typeOfTEnum.IsEnum)
            {
                throw new Exception("The given input is not in the correct format (Enum) !");
            }
            return Enum.GetValues(typeOfTEnum).OfType<TEnum>().Select(c => c.ToString());
        }
    }
}
