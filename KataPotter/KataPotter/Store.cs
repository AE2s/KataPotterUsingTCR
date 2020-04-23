using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class Store
    {
        private const float TWO_BOOKS_DISCOUNT = 0.05f;
        private const int BOOK_PRICE = 8;
        private readonly List<Book> _basket;
        public Store()
        {
            _basket = new List<Book>();
        }
        public float Bill()
        {
            if (!_basket.Any())
                return 0;

            if (_basket.GroupBy(x => x.Title).Count() == 1)
                return BOOK_PRICE * _basket.Count;

            return _basket.Count * BOOK_PRICE - _basket.Count * BOOK_PRICE * TWO_BOOKS_DISCOUNT;
        }

        public void AddToBasket(Book book, int quantity)
        {
            for (int i = 0; i < quantity; i++)
                _basket.Add(book);
        }
    }
}