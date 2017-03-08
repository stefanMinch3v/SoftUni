using System;

namespace StringAndObject
{
    public class StringAndObject
    {
        public static void Main(string[] args)
        {
            string word = "Hello";
            string word2 = "World";
            object word3 = new object();
            word3 = word + " " + word2;
            string word4 = (string)word3;
            Console.WriteLine(word3);
            
        }
    }
}
