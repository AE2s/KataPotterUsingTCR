using System;

namespace KataPotter
{
    public class Book : IEquatable<Book>
    {
        public BookTitle Title { get; }

        public Book(BookTitle bookTitle)
        {
            Title = bookTitle;
        }


        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Title == other.Title;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Book) obj);
        }

        public override int GetHashCode()
        {
            return (int) Title;
        }
    }

    public enum BookTitle
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth
    }
}