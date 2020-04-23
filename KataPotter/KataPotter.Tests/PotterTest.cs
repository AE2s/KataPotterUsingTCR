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
            Check.That(store.Bill()).IsEqualTo(15.20);
        }

        [Fact]
        public void Given_a_basket_with_3_different_books_should_return_21_6()
        {
            var store = new Store();
            var firstBook = new Book(BookTitle.First);
            var secondBook = new Book(BookTitle.Second);
            var thirdBook = new Book(BookTitle.Third);
            store.AddToBasket(firstBook, 1);
            store.AddToBasket(secondBook, 1);
            store.AddToBasket(thirdBook, 1);
            Check.That(store.Bill()).IsEqualTo(21.60);
        }

        [Fact]
        public void Given_a_basket_with_4_different_books_should_return_25_6()
        {
            var store = new Store();
            var firstBook = new Book(BookTitle.First);
            var secondBook = new Book(BookTitle.Second);
            var thirdBook = new Book(BookTitle.Third);
            var fourthBook = new Book(BookTitle.Fourth);
            store.AddToBasket(firstBook, 1);
            store.AddToBasket(secondBook, 1);
            store.AddToBasket(thirdBook, 1);
            store.AddToBasket(fourthBook, 1);
            Check.That(store.Bill()).IsEqualTo(25.60);
        }

        [Fact]
        public void Given_a_basket_with_5_different_books_should_return_30()
        {
            var store = new Store();
            var firstBook = new Book(BookTitle.First);
            var secondBook = new Book(BookTitle.Second);
            var thirdBook = new Book(BookTitle.Third);
            var fourthBook = new Book(BookTitle.Fourth);
            var fifthBook = new Book(BookTitle.Fifth);
            store.AddToBasket(firstBook, 1);
            store.AddToBasket(secondBook, 1);
            store.AddToBasket(thirdBook, 1);
            store.AddToBasket(fourthBook, 1);
            store.AddToBasket(fifthBook, 1);
            Check.That(store.Bill()).IsEqualTo(30);
        }

        [Fact]
        public void Given_a_basket_with_2_same_and_one_different_books_should_return_23_2()
        {
            var store = new Store();
            var firstBook = new Book(BookTitle.First);
            var secondBook = new Book(BookTitle.Second);
            store.AddToBasket(firstBook, 2);
            store.AddToBasket(secondBook, 1);
            Check.That(store.Bill()).IsEqualTo(23.20);
        }

        [Fact]
        public void Given_a_basket_with_several_books_should_return_51_2()
        {
            var store = new Store();
            var firstBook = new Book(BookTitle.First);
            var secondBook = new Book(BookTitle.Second);
            var thirdBook = new Book(BookTitle.Third);
            var fourthBook = new Book(BookTitle.Fourth);
            var fifthBook = new Book(BookTitle.Fifth);
            store.AddToBasket(firstBook, 2);
            store.AddToBasket(secondBook, 2);
            store.AddToBasket(thirdBook, 2);
            store.AddToBasket(fourthBook, 1);
            store.AddToBasket(fifthBook, 1);
            Check.That(store.Bill()).IsEqualTo(51.20);
        }

        [Fact]
        public void Given_a_basket_with_several_books_should_return_30_4()
        {
            var store = new Store();
            var firstBook = new Book(BookTitle.First);
            var secondBook = new Book(BookTitle.Second);
            store.AddToBasket(firstBook, 2);
            store.AddToBasket(secondBook, 2);
            Check.That(store.Bill()).IsEqualTo(2 * (8 * 2 * 0.95));
        }

        [Fact]
        public void Given_a_basket_with_several_books_should_return_40_8()
        {
            var store = new Store();
            var firstBook = new Book(BookTitle.First);
            var secondBook = new Book(BookTitle.Second);
            var thirdBook = new Book(BookTitle.Third);
            var fourthBook = new Book(BookTitle.Fourth);
            store.AddToBasket(firstBook, 2);
            store.AddToBasket(secondBook, 1);
            store.AddToBasket(thirdBook, 2);
            store.AddToBasket(fourthBook, 1);
            Check.That(store.Bill()).IsEqualTo((8 * 4 * 0.8) + (8 * 2 * 0.95));
        }

        [Fact]
        public void Given_a_basket_with_several_books_should_return_38()
        {
            var store = new Store();
            var firstBook = new Book(BookTitle.First);
            var secondBook = new Book(BookTitle.Second);
            var thirdBook = new Book(BookTitle.Third);
            var fourthBook = new Book(BookTitle.Fourth);
            var fifthBook = new Book(BookTitle.Fifth);
            store.AddToBasket(firstBook, 1);
            store.AddToBasket(secondBook, 2);
            store.AddToBasket(thirdBook, 1);
            store.AddToBasket(fourthBook, 1);
            store.AddToBasket(fifthBook, 1);
            Check.That(store.Bill()).IsEqualTo(8 + (8 * 5 * 0.75));
        }

        [Fact]
        public void Given_a_basket_with_several_books_should_return_141_2()
        {
            var store = new Store();
            var firstBook = new Book(BookTitle.First);
            var secondBook = new Book(BookTitle.Second);
            var thirdBook = new Book(BookTitle.Third);
            var fourthBook = new Book(BookTitle.Fourth);
            var fifthBook = new Book(BookTitle.Fifth);
            store.AddToBasket(firstBook, 5);
            store.AddToBasket(secondBook, 5);
            store.AddToBasket(thirdBook, 4);
            store.AddToBasket(fourthBook, 5);
            store.AddToBasket(fifthBook, 4);
            Check.That(store.Bill()).IsEqualTo(3 * (8 * 5 * 0.75) + 2 * (8 * 4 * 0.8));
        }
    }
}
