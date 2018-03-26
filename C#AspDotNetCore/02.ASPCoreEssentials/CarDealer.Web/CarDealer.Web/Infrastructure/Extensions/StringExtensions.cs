namespace CarDealer.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        private const string NumberFormat = "F2";

        public static string ToPrice(this decimal decimalText)
            => $"${decimalText.ToString(NumberFormat)}";

        public static string ToPrice(this double doubleText)
            => $"${doubleText.ToString(NumberFormat)}";


        public static string ToPercentage(this double doubleText)
            => $"{doubleText.ToString(NumberFormat)}%";

        public static string ToPercentage(this int integerText)
            => $"{integerText.ToString(NumberFormat)}%";
    }
}
