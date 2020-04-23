using System;
using Xunit;
using NFluent;

namespace KataPotter.Tests
{
    public class PotterTest
    {
        [Fact]
        public void Test1()
        {
            Store store=new Store();
            Check.That(store.Bill()).IsEqualTo(0);
        }
    }

    public class Store
    {
        public float Bill()
        {
            return 0;
        }
    }
}
