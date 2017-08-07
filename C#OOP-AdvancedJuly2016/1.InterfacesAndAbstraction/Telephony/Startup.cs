using System;

namespace Telephony
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(new char[] {' '});
            string[] websites = Console.ReadLine().Split(new char[] {' '});

            Smartphone phone = new Smartphone("Xperia");

            foreach (var num in phoneNumbers)
            {
                phone.Calling(num);
            }
            foreach (var web in websites)
            {
                phone.BrowsingWWW(web);
            }
        }
    }
}
