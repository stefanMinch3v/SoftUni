using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebCrawler
{
    class HtmlParser
    {
        const string ImgTagPattern = @"<img.*?src=""(.*?)"".*?>";

        public static List<string> ParseImgTags(string html)
        {
            MatchCollection match = Regex.Matches(html, ImgTagPattern);

            return match
                        .Cast<Match>()
                        .Select(m => m.Groups[1].Value)
                        .ToList();
        }
    }
}
