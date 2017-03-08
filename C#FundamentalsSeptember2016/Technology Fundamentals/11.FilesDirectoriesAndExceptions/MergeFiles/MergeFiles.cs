using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeFiles
{
    class MergeFiles
    {
        static void Main(string[] args)
        {
            string[] firstNumbers = File.ReadAllText("FileOne.txt").Split(new char[] { '\r'});
            string[] secondNumbers = File.ReadAllText("FileTwo.txt").Split(new char[] { '\r'});
            List<int> result = new List<int>();
            foreach (var item in firstNumbers)
            {
                result.Add(int.Parse(item));
            }
            foreach (var item in secondNumbers)
            {
                result.Add(int.Parse(item));
            }

            var finalResult = result.OrderBy(n => n).ToList();
            var final = string.Join(" ", finalResult);
            string[] finaFinal = final.Split().ToArray();
            File.AppendAllLines("result.txt", finaFinal);
        }
    }
}
