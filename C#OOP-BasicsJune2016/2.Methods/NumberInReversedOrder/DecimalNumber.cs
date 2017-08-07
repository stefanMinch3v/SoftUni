using System;

public class DecimalNumber
{
    public string ReversedNumber(string number)
    {
        var parseToChar = number.ToCharArray();
        Array.Reverse(parseToChar);
        return string.Join("",parseToChar);
    }   
}
