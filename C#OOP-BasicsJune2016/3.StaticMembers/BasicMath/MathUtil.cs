static class MathUtil
{
    public static string Sum(double number, double number2)
    {
        return $"{number + number2:F2}";
    }
    public static string Multiply(double number, double number2)
    {
        return $"{number * number2:F2}";
    }
    public static string Percentage(double number, double number2)
    {
        return $"{(number * number2) / 100:F2}";
    }
    public static string Divide(double number, double number2)
    {
        return $"{number / number2:F2}";
    }
    public static string Subtract(double number, double number2)
    {
        return $"{number - number2:F2}";
    }
}
