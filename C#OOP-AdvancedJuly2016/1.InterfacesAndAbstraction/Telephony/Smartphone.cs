using System;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone(string model)
        {
            this.Model = model;
        }

        public string Model { get;}

        public void BrowsingWWW(string website)
        {
            foreach (var web in website)
            {
                if (char.IsDigit(web))
                {
                    Console.WriteLine("Invalid URL!");
                    return;
                }
            }
            Console.WriteLine($"Browsing: {website}!");
        }

        public void Calling(string phoneNumber)
        {
            foreach (var phone in phoneNumber)
            {
                if (!char.IsDigit(phone))
                {
                    Console.WriteLine("Invalid number");
                    return;
                }
            }
            Console.WriteLine($"Calling... {phoneNumber}");
        }
    }
}
