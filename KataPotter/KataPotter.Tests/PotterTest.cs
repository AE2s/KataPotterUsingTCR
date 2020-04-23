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
    }
}
