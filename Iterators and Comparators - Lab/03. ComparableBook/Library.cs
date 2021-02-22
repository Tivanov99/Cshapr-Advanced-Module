using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public List<Book> Books { get; set; }
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            Books.Sort();
            return new LibraryIterator(this.Books);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currindex;
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            public Book Current => this.books[this.currindex];
            object IEnumerator.Current => Current;
            public void Dispose()
            {
            }
            public bool MoveNext() => ++this.currindex < this.books.Count();
            public void Reset()
            {
                currindex = -1;
            }
        }
    }
}

