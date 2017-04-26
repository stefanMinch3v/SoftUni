using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    public class Startup
    {
        public static void Main()
        {
            var crawler = new WebCrawler();

            for (int i = 5; i <= 10; i++)
            {
                crawler.AddPendingUrl("https://softuni.bg/forum?page=" + i);
            }
            var task = crawler.RunAsync("https://softuni.bg/");
            while (true)
            {
                var command = Console.ReadLine();
            }
        }
    }
}
