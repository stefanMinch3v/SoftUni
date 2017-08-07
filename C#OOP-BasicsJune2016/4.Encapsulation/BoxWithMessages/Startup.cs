using System;
using System.Linq;
using System.Reflection;

public class Startup
{
    public static void Main()
    {
        try
        {

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Type boxType = typeof(BoxClass);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            BoxClass box = new BoxClass(length, width, height);
            Console.WriteLine(box.GetSurfaceArea());
            Console.WriteLine(box.GetLateralSurfaceArea());
            Console.WriteLine(box.GetVolume());
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
        
    }
}