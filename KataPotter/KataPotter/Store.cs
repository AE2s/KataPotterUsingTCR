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
            if(!_basket.Any())
                return 0;

            return 8;
        }

        public void AddToBasket(Book book)
        {
            _basket.Add(book);
        }
    }
}