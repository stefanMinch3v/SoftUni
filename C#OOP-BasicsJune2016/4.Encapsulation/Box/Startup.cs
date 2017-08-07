using System;
using System.Linq;
using System.Reflection;

public class Startup
{
    public static void Main()
    {
        Type boxType = typeof(BoxClass);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        BoxClass box = new BoxClass(length, width, height);
        Console.WriteLine(box.SurfaceArea(length, width, height));
        Console.WriteLine(box.LateralSurfaceArea(length, width, height));
        Console.WriteLine(box.Volume(length, width, height));
    }
}