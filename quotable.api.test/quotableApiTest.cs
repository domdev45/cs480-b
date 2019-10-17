using NUnit.Framework;
using quotable.api.Controllers;
using quotable.core;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Get_Success()
        {
                var generator = new SimpleRandomQuoteProvider();
                var controller = new QuoteController();

                var actual = controller.Get(3);
                var expected = "ID 3" + " If life were predictable it would cease to be life, and be without flavor. " + " by Eleanor Roosevelt";

                Assert.AreEqual(actual, expected);
        }
        
    }
}