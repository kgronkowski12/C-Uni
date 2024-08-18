using IObserverNet40;
using IObserverNet40.Subscriber;

namespace Testor
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var c = new CurrentConditionsSubscriber();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}