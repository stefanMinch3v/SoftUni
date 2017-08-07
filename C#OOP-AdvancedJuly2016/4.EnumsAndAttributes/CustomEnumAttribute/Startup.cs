namespace CustomEnumAttribute
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (input == "Rank")
            {
                var result = typeof(CardRank).GetCustomAttributes(false);
                Console.WriteLine(string.Join("", result));  
            }
            else if (input == "Suit")
            {
                var result = typeof(CardSuits).GetCustomAttributes(false);
                Console.WriteLine(string.Join("", result));
            }
            
        }
    }
}
