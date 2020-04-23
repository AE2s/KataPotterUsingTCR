namespace KataPotter
{
    public class Book
    {
        private readonly BookTitle _bookTitle;

        public Book(BookTitle bookTitle)
        {
            _bookTitle = bookTitle;
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