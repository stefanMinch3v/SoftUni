using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    class WebCrawler
    {
        private int workerCount = Environment.ProcessorCount;
        private Task[] workerTasks { get; set; }
        private Queue<string> pendingUrls { get; set; }
        private string host { get; set; }
        private HashSet<string> downloadedImages { get; set; }

        public WebCrawler()
        {
            downloadedImages = new HashSet<string>();
            pendingUrls = new Queue<string>();
        }

        public void AddPendingUrl(string url)
        {
            pendingUrls.Enqueue(url);
        }

        public void Run(string host)
        {
            if (!Directory.Exists("Files"))
            {
                Directory.CreateDirectory("Files");
            }
            this.host = host;
            workerTasks = new Task[workerCount];
            for (int i = 0; i < workerCount; i++)
            {
                var task = new Task( () => RunWorker() ); // can be without () => ()
                //var task = Task.Factory.StartNew(() => RunWorker(), TaskCreationOptions.LongRunning);
                workerTasks[i] = task;
                task.Start();
            }

            Task.WaitAll(workerTasks);
        }

        public async Task RunAsync(string host)
        {
            await Task.Run( () => Run(host));
            Console.WriteLine("Running complete");
        }

        void RunWorker()
        {
            while(pendingUrls.Count > 0)
            {
                string url = string.Empty;
                lock (pendingUrls)
                {
                    if (pendingUrls.Count == 0)
                    {
                        break;
                    }
                    url = pendingUrls.Dequeue();

                }

                using (var webClient = new WebClient())
                {
                    //download html
                    var html = webClient.DownloadString(url);
                    Console.WriteLine("{0} downloading {1}", Task.CurrentId, url);
                    //parse img tags
                    var relativeImgUrls = HtmlParser.ParseImgTags(html);
                    //download images
                    foreach (var relativeImageUrl in relativeImgUrls)
                    {
                        if (downloadedImages.Contains(relativeImageUrl))
                        {
                            continue;
                        }
                        else
                        {
                            string imageUrl = host + relativeImageUrl;
                            int lastBackSlash = relativeImageUrl.LastIndexOf("/");
                            string imageName = relativeImageUrl.Substring(lastBackSlash + 1);

                            using (var downloader = new WebClient())
                            {
                                downloader.DownloadFile(imageUrl, "Files/" + imageName + ".jpeg");
                                //string[] contentType = downloader.ResponseHeaders["Content-Type"].Split('/');
                                //string imageExtension = contentType[1];
                            }
                            downloadedImages.Add(relativeImageUrl);
                        }
                    }
                }
            }
        }
    }
}
