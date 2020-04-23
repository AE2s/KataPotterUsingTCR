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

            if (_basket.Count == 1)
                return 8;

            var toto = _basket.GroupBy(x => x.Title);
            var condition = toto.Count() == 1;
            if (condition)
                return 8*_basket.Count;

            return (_basket.Count * 8) - (_basket.Count * 8 * TWO_BOOKS_DISCOUNT);
        }

        public void AddToBasket(Book book, int quantity)
        {
            for (int i = 0; i < quantity; i++)
                _basket.Add(book);
        }
    }
}