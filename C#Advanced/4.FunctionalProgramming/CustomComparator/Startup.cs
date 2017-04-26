﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Array.Sort(numbers, new MyComparer());
        Console.WriteLine(string.Join(" ", numbers));
    }
}

public class MyComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if ((x % 2 == 0) && (y % 2 != 0))
        {
            return -1;
        }
        else if ((x % 2 != 0) && (y % 2 == 0))
        {
            return 1;
        }
        else
        {
            //retrun x.CompareTo(y);
            if (x > y)
            {
                return 1;
            }
            else if (y > x)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
