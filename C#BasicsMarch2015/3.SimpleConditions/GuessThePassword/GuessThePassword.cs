﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThePassword
{
    class GuessThePassword
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the password: ");
            var pass = Console.ReadLine();
            if(pass == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password !");
            }
        }
    }
}
