using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericRealBox
{
   public class Startup
    {
        public static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                boxes.Add(new Box<string>(Console.ReadLine()));
            }

            Box<string> comparableBox = new Box<string>(Console.ReadLine());
            int countGreaterElements = CompareElements(boxes, comparableBox);
            Console.WriteLine(countGreaterElements);
        }

        static int CompareElements<T>(List<Box<T>> boxes, Box<T> comparableBox)
            where T:IComparable<T>
        {

            int counter = 0;
            //counter = boxes.Count(b => b.Element.CompareTo(comparableBox.Element) > 0); linq
            
            foreach (var box in boxes)
            {
                if (box.Element.CompareTo(comparableBox.Element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }

    public class Box<T> where T : IComparable<T>
    {
        private T element;

        public Box(T element)
        {
            this.element = element;
        }

        public Box() : this(default(T))
        {
        }

        public T Element
        {
            get
            {
                return this.element;
            }
            set
            {
                this.element = value;
            }
        }
    }
}
