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
        private const int MAX_BOOK = 5;
        private readonly Dictionary<BookTitle, int> _basket;
        public Store()
        {
            _basket = new Dictionary<BookTitle, int>();
        }
        public double Bill()
        {
            double initialPrice = 0;
            return Math.Round(PriceWithReduction(initialPrice), 2);
        }

        private double PriceWithReduction(double initialPrice)
        {
            if (_basket.Count == 0)
                return initialPrice;

            return OptimizeReduction() switch
            {
                1 => (initialPrice + PriceWithReduction(ApplyReduction(ONE_BOOK_DISCOUNT, 1))),
                2 => (initialPrice + PriceWithReduction(ApplyReduction(TWO_BOOKS_DISCOUNT, 2))),
                3 => (initialPrice + PriceWithReduction(ApplyReduction(THREE_BOOKS_DISCOUNT, 3))),
                4 => (initialPrice + PriceWithReduction(ApplyReduction(FOUR_BOOKS_DISCOUNT, 4))),
                _ => (initialPrice + PriceWithReduction(ApplyReduction(FIVE_BOOKS_DISCOUNT, 5)))
            };
        }

        private double ApplyReduction(float reduction, int quantityToTreat)
        {
            double result = quantityToTreat * BOOK_PRICE * reduction;
            ClearBasket(quantityToTreat);
            return result;
        }

        private void ClearBasket(int quantityToTreat)
        {
            var quantityTreated = 0;
            foreach (BookTitle book in Enum.GetValues(typeof(BookTitle)))
            {
                if (!_basket.ContainsKey(book) || quantityTreated == quantityToTreat) continue;

                _basket[book]--;
                quantityTreated++;
                if (_basket[book] == 0)
                    _basket.Remove(book);
            }
        }

        public void AddToBasket(Book book, int quantity)
        {
            if (_basket.ContainsKey(book.Title))
                _basket[book.Title] += quantity;
            else
                _basket.Add(book.Title, quantity);
        }

        private int OptimizeReduction()
        {
            switch (_basket.Count)
            {
                case MAX_BOOK when _basket.Values.Count(x => x > 1) >= 4:
                    return MAX_BOOK;
                case MAX_BOOK when _basket.Values.Count(x => x > 1) >= 2:
                    return 4;
                default:
                    return _basket.Count;
            }
        }
    }
}