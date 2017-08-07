using System;
using System.Collections.Generic;

namespace ExcerciseBook
{
    public class Startup
    {
        public static void Main()
        {
            var books = new BookCollection();

            books.Add(new Book { Title = "Pesho" });
            books.Add(new Book { Title = "Gosho" });
            books.Add(new Book { Title = "Mitko" });
            books.Add(new Book { Title = "Rado" });
            books.Add(new Book { Title = "Penka" });



            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }

            foreach (var num in GetSome())
            {
                Console.WriteLine(num);
            }

            //behind the foreach
            //var enumerator = new BookCollection.BookEnumerator(new List<Book>());

            //enumerator.Reset();

            //while (enumerator.MoveNext())
            //{
            //    System.Console.WriteLine(enumerator.Current.Title);
            //}

            var firstSet = new SortedSet<Book>(); // use the default IComparable which is working directly on the class that you have already created in book

            var someSet = new SortedSet<Book>(new BookComparer()); // use the BookComparer from below which is working outside the class
        }

        public static IEnumerable<int> GetSome()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return 1;
                
            }
        }

        public class BookComparer : IComparer<Book> // create your own comparer !
        {
            public int Compare(Book x, Book y)
            {
                return x.Title.CompareTo(y.Title);
            }
        }

    }
}
