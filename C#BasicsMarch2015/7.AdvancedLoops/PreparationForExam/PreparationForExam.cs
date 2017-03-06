using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparationForExam
{
    class PreparationForExam
    {
        static void Main(string[] args)
        {
            Console.Write("Weidth is: ");
            var w = double.Parse(Console.ReadLine());
            Console.Write("Height is : ");
            var h = double.Parse(Console.ReadLine());
            double sumW = 0;
            double sumH = 0;
            double result = 0;
            if (3 <= h && h <= w && w <= 100)
            {
                sumW = w * 100 ;
                sumH = h * 100 - 100;
                sumW = Math.Round(sumW / 120);
                sumH = Math.Round(sumH / 70);
                result = sumH * sumW - 3;
            }
            Console.WriteLine("The numbers of seats are : {0}",result);
        }
    }
}
