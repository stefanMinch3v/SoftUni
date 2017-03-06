using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTitles
{
    class PersonalTitles
    {
        static void Main(string[] args)
        {
            Console.Write("Enter age: ");
            var age = float.Parse(Console.ReadLine());
            Console.Write("Enter sex(m or f): ");
            var sex = Console.ReadLine();
            if(sex == "m")
            {
                if(age < 16)
                {
                    Console.WriteLine("Master");
                }
                else
                {
                    Console.WriteLine("Mr.");
                }
            }

            if(sex == "f")
            {
                if(age < 16)
                {
                    Console.WriteLine("Miss");
                }
                else
                {
                    Console.WriteLine("Ms.");
                }
            }

            //if (age < 16)
            //{
            //    if (sex == "m") Console.WriteLine("Master");
            //    else if (sex == "f") Console.WriteLine("Miss");
            //}
            //else
            //{
            //    if (sex == "m") Console.WriteLine("Mr.");
            //    else if (sex == "f") Console.WriteLine("Ms.");
            //}
        }
    }
}
