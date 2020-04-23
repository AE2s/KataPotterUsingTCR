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
            Book book=new Book();
            store.AddToBasket(book);
            Check.That(store.Bill()).IsEqualTo(8);
        }
    }
}
