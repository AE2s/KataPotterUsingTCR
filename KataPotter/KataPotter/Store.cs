using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class Store
    {
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
            return 16;
        }

        public void AddToBasket(Book book, int quantity)
        {
            for (int i = 0; i < quantity; i++)
                _basket.Add(book);
        }
    }
}