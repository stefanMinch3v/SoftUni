using System;

static class VolumeCalculator
{
    public static string VolumeCube(double sideLength)
    {
        return $"{Math.Pow(sideLength, 3):F3}";
    }
    public static string VolumeCylinder(double radius, double height)
    {
        return $"{ (Math.PI*Math.Pow(radius, 2)) * height:F3}";
    }
    public static string VolumeTrianglePrism(double baseSide, double height, double length)
    {
        return $"{ (0.5 * (baseSide * height)) * length:F3}";
    }
}
