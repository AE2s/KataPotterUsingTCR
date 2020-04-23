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
        private readonly Dictionary<int, float> discounts;

        public Store()
        {
            _basket = new Dictionary<BookTitle, int>();
            discounts = new Dictionary<int, float>
            {
                {1, ONE_BOOK_DISCOUNT },
                {2, TWO_BOOKS_DISCOUNT },
                {3, THREE_BOOKS_DISCOUNT },
                {4, FOUR_BOOKS_DISCOUNT },
                {5, FIVE_BOOKS_DISCOUNT }
            };
        }
        public double Bill()
        {
            const double initialPrice = 0;
            return Math.Round(PriceWithReduction(initialPrice), 2);
        }

        private double PriceWithReduction(double initialPrice)
        {
            if (_basket.Count == 0)
                return initialPrice;

            var index = OptimizeReduction();
            var reduction = ApplyReduction(discounts[index], index);
            return initialPrice + PriceWithReduction(reduction);
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
            var _basketCopy = _basket;
            var listBasket = _basketCopy.ToList();

            while (quantityTreated != quantityToTreat)
            {
                var elementToRemove = listBasket.ElementAt(quantityTreated);
                _basketCopy.Remove(elementToRemove.Key);
                if (elementToRemove.Value > 1)
                    _basketCopy.Add(elementToRemove.Key, elementToRemove.Value - 1);
                quantityTreated++;
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
            return _basket.Count switch
            {
                MAX_BOOK when _basket.Values.Count(x => x > 1) >= 4 => MAX_BOOK,
                MAX_BOOK when _basket.Values.Count(x => x > 1) >= 2 => 4,
                _ => _basket.Count
            };
        }
    }
}