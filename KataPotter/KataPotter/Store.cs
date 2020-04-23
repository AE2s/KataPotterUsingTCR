using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class Store
    {
        private const float ONE_BOOK_DISCOUNT = 1f;
        private const float TWO_BOOKS_DISCOUNT = 0.95f;
        private const float THREE_BOOKS_DISCOUNT = 0.90f;
        private const float FOUR_BOOKS_DISCOUNT = 0.80f;
        private const float FIVE_BOOKS_DISCOUNT = 0.75f;
        private const int BOOK_PRICE = 8;
        private readonly Dictionary<BookTitle,int> _basket;
        public Store()
        {
            _basket = new Dictionary<BookTitle, int>();
        }
        public double Bill()
        {
            if (!_basket.Any())
                return 0;

            if (hadSameBook())
                return BOOK_PRICE * QuantitySum();

            
            double finalPrice = 0;
            return Math.Round(PriceWithReduction(finalPrice),2);
        }

        private double PriceWithReduction(double finalPrince)
        {
            if (_basket.Count == 0)
                return finalPrince;

            switch (OptimizeReduction())
            {
                case 1:
                    return finalPrince + PriceWithReduction(ApplyReduction(ONE_BOOK_DISCOUNT,1));
                case 2:
                    return finalPrince + PriceWithReduction(ApplyReduction(TWO_BOOKS_DISCOUNT,2));
                case 3:
                    return finalPrince + PriceWithReduction(ApplyReduction(THREE_BOOKS_DISCOUNT,3));
                case 4:
                    return finalPrince + PriceWithReduction(ApplyReduction(FOUR_BOOKS_DISCOUNT,4));
                default:
                    return finalPrince + PriceWithReduction(ApplyReduction(FIVE_BOOKS_DISCOUNT,5));
            }
        }

        private double ApplyReduction(float reduction,int count)
        {
            var countElement = count;
            double result = count * BOOK_PRICE * reduction;
            foreach (BookTitle book in Enum.GetValues(typeof(BookTitle)))
            {
                if (_basket.ContainsKey(book) && countElement > 0)
                {
                    _basket[book]--;
                    countElement--;
                    if (_basket[book] == 0)
                        _basket.Remove(book);
                }

            }

            return result;
        }

        private bool hadSameBook() => _basket.Count == 1;

        private int QuantitySum() => _basket.Values.Sum();

        public void AddToBasket(Book book, int quantity)
        {
            if (_basket.ContainsKey(book.Title))
                _basket[book.Title] += quantity;
            else
                _basket.Add(book.Title, quantity);

        }

        private int OptimizeReduction()
        {
            if (_basket.Count == 5 && _basket.Values.Count(x => x > 1) >= 3 )
                return 4;
            return _basket.Count;

        }
    }
}