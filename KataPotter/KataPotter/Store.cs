using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class Store
    {
        private const float TWO_BOOKS_DISCOUNT = 0.95f;
        private const float THREE_BOOKS_DISCOUNT = 0.90f;
        private const int BOOK_PRICE = 8;
        private readonly List<Book> _basket;
        public Store()
        {
            _basket = new List<Book>();
        }
        public double Bill()
        {
            if (!_basket.Any())
                return 0;

            if (_basket.GroupBy(x => x.Title).Count() == 1)
                return BOOK_PRICE * _basket.Count;
            if (_basket.GroupBy(x => x.Title).Count() == 2)
                return Math.Round(_basket.Count * BOOK_PRICE * TWO_BOOKS_DISCOUNT,2);

            return Math.Round(_basket.Count * BOOK_PRICE * THREE_BOOKS_DISCOUNT,2);
        }

        public void AddToBasket(Book book, int quantity)
        {
            for (int i = 0; i < quantity; i++)
                _basket.Add(book);
        }
    }
}