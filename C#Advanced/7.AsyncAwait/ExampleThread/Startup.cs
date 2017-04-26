using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleThread
{
    public class Startup
    {
        const string url = "http://www.introprogramming.info/wp-content/uploads/2013/07/Books/CSharpEn/Fundamentals-of-Computer-Programming-with-CSharp-Nakov-eBook-v2013.pdf";
        public static void Main()
        {
            DownloadFileAsync(url, "book.pdf");
        }

        static async void DownloadFileAsync(string url, string fileName)
        {
            Console.WriteLine("Downloading...");

            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, fileName);
            }

            Console.WriteLine("Download successful.");
            Process.Start(fileName);
        }
    }
}
