using Xunit;
using NFluent;

namespace KataPotter.Tests
{
    public class PotterTest
    {
        [Fact]
        public void Given_an_empty_basket_should_return_0()
        {
            var store=new Store();
            Check.That(store.Bill()).IsEqualTo(0);
        }

        [Fact]
        public void Given_a_basket_with_one_book_should_return_8()
        {
            var store = new Store();
            Book book=new Book(BookTitle.First);
            store.AddToBasket(book,1);
            Check.That(store.Bill()).IsEqualTo(8);
        }

        [Fact]
        public void Given_a_basket_with_two_same_books_should_return_16()
        {
            var store = new Store();
            Book book = new Book(BookTitle.First);
            store.AddToBasket(book,2);
            Check.That(store.Bill()).IsEqualTo(16);
        }

        [Fact]
        public void Given_a_basket_with_two_different_books_should_return_15_2()
        {
            var store = new Store();
            var firstBook = new Book(BookTitle.First);
            var secondBook = new Book(BookTitle.Second);
            store.AddToBasket(firstBook, 1);
            store.AddToBasket(secondBook, 1);
            Check.That(store.Bill()).IsEqualTo(15.2f);
        }


    }
}
