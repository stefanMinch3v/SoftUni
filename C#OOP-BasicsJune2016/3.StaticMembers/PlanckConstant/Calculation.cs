static class Calculation
{
    public const double planck = 6.62606896e-34;
    public const double pi = 3.14159;

    public static double ReducePlanck()
    {
        return planck / (2 * pi);
    }
}
