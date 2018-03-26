namespace CameraBazaar.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToPrice(this decimal value)
        {
            return $"${value.ToString("F2")}";
        }

        public static string ToLightMetering(this string value)
        {
            if (value == "CenterWeighted")
            {
                return "Center-Weighted";
            }

            return value;
        }
    }
}
