using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        List<object> shapes = new List<object>();
        string input = Console.ReadLine();
        while(input != "End")
        {
            string[] commandLine = input.Split();
            string shape = commandLine[0];
            switch (shape)
            {
                case "Cube":
                    double sideLength = double.Parse(commandLine[1]);
                    Cube cube = new Cube(sideLength);
                    shapes.Add(cube);
                    Console.WriteLine(VolumeCalculator.VolumeCube(sideLength));
                    break;
                case "Cylinder":
                    double radius = double.Parse(commandLine[1]);
                    double height = double.Parse(commandLine[2]);
                    Cylinder cylinder = new Cylinder(radius, height);
                    shapes.Add(cylinder);
                    Console.WriteLine(VolumeCalculator.VolumeCylinder(radius, height));
                    break;
                case "TrianglePrism":
                    double baseSide = double.Parse(commandLine[1]);
                    double baseHeight = double.Parse(commandLine[2]);
                    double length = double.Parse(commandLine[3]);
                    TriangularPrism triangularPrism = new TriangularPrism(baseSide, baseHeight, length);
                    shapes.Add(triangularPrism);
                    Console.WriteLine(VolumeCalculator.VolumeTrianglePrism(baseSide, baseHeight, length));
                    break;
                default:
                    break;
            }
            input = Console.ReadLine();
        }
    }
}
