namespace ExcerciseBook
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BookCollection : IEnumerable//<Book>
    {
        private readonly List<Book> books;

        public BookCollection()
        {
            this.books = new List<Book>();
        }

        public void Add(Book book)
        {
            this.books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            //return new BookEnumerator(this.books);
            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        public class BookEnumerator : IEnumerator<Book>
        {
            private int currentIndex;
            private readonly List<Book> books;

            public BookEnumerator(List<Book> books)
            {
                this.Reset();
                this.books = books;
            }

            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            //public bool MoveNext() => ++this.currentIndex < this.books.Count; // use => every time when the code is on 1 line 

            public bool MoveNext()
            {
                this.currentIndex += 2;

                if (this.currentIndex >= this.books.Count)
                {
                    return false;
                }

                return true;
            }

            public void Reset() => this.currentIndex = -2;
        }
    }
}
