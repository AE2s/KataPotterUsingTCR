using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class Store
    {
        private const float TWO_BOOKS_DISCOUNT = 0.95f;
        private const float THREE_BOOKS_DISCOUNT = 0.90f;
        private const float FOUR_BOOKS_DISCOUNT = 0.80f;
        private const float FIVE_BOOKS_DISCOUNT = 0.75f;
        private const int BOOK_PRICE = 8;
        private readonly Dictionary<Book,int> _basket;
        public Store()
        {
            _basket = new Dictionary<Book, int>();
        }
        public double Bill()
        {
            if (!_basket.Any())
                return 0;

            if (HaveOnlyOneTypeOfBook())
                return BOOK_PRICE * _basket.Values.Sum();

            return PriceWithReduction();
        }

        private double PriceWithReduction()
        {
            switch (_basket.Count)
            {
                case 2:
                    return ApplyReduction(TWO_BOOKS_DISCOUNT);
                case 3:
                    return ApplyReduction(THREE_BOOKS_DISCOUNT);
                case 4:
                    return ApplyReduction(FOUR_BOOKS_DISCOUNT);
                default:
                    return ApplyReduction(FIVE_BOOKS_DISCOUNT);
            }
        }

        private double ApplyReduction(float reduction)
        {
            return Math.Round(_basket.Values.Sum() * BOOK_PRICE * reduction, 2);
        }

        private bool HaveOnlyOneTypeOfBook() => _basket.Count == 1;

        public void AddToBasket(Book book, int quantity)
        {
            if(_basket.ContainsKey(book))
                _basket[book]+=quantity;
            else
                _basket.Add(book, quantity);
            
        }
    }
}