using CollectionHierarchy.Collections;
using System;

namespace CollectionHierarchy
{
   public class Startup
    {
       public static void Main()
        {
            string[] elementsToAdd = Console.ReadLine().Split();
            int countRemoveElements = int.Parse(Console.ReadLine());
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var element in elementsToAdd)
            {
                Console.Write(addCollection.Add(element) + " ");
            }
            Console.WriteLine();
            foreach (var element in elementsToAdd)
            {
                Console.Write(addRemoveCollection.Add(element) + " ");
            }
            Console.WriteLine();
            foreach (var element in elementsToAdd)
            {
                Console.Write(myList.Add(element) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < countRemoveElements; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < countRemoveElements; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
            Console.WriteLine();
        }
    }
}
