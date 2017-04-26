using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DownloadManager
{
    public static class DownloadManager
    {
        public static void Main()
        {

        }

        public static void Download(string fileUrl)
        {
            WebClient webClient = new WebClient();

            try
            {
                Console.WriteLine("Downloading");

                string nameOfFile = ExtractNameOfFile(fileUrl);
                string pathToDownload = "File/" + nameOfFile;

                webClient.DownloadFile(fileUrl, pathToDownload);

                Console.WriteLine("Download completed");
            }
            catch (WebException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static string ExtractNameOfFile(string fileUrl)
        {
            int indexOfLastBackSlash = fileUrl.LastIndexOf("/");

            if (indexOfLastBackSlash != -1)
            {

            }
            else
            {
                throw new WebException();
            }

            return fileUrl.Substring(indexOfLastBackSlash + 1);
        }

        public static void DownloadAsync(string fileUrl)
        {
            Task.Run(() => Download(fileUrl));
        }

        private static void TryDownloadRequestedFileAsync(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                DownloadManager.DownloadAsync(url);
            }
            else
            {
                Console.WriteLine("Invalid command {0}", input);
            }
        }

        private static void TryDownloadRequestedFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                DownloadManager.Download(url);
            }
            else
            {
                Console.WriteLine("Invalid command {0}", input);
            }
        }
    }
}
