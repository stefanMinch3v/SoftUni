using System;

public static class Dates
{
    public static double CalculateDays(string date1, string date2)
    {
        DateTime parseDate1 = DateTime.Parse(date1);
        DateTime parseDate2 = DateTime.Parse(date2);
        double result = Math.Abs((parseDate1 - parseDate2).TotalDays);
        return result;
    }
}
