using System;

namespace Demo
{
    class LiveDemo
    {
        static void Main()
        {
            Console.Write("Enter some seconds ->");
            int number = int.Parse(Console.ReadLine());
            int mins = number / 60;
            int seconds = number % 60;
            //Console.WriteLine("{0}:{1}",mins,seconds);
            Console.WriteLine(mins + ":" + seconds);
        }
    }
}
