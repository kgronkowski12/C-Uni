using NUnit.Framework;
using IObserverNet40.Publisher;
using IObserverNet40.Subscriber;


namespace IObserverNet40Test
{
	[TestFixture]
	public class CurrentConditionsSubscriberTest
	{
		[Test]
		public void CurrentConditionsSubscriber_NotifyFirstChange_Temperature()
		{
            var wdp = new BankDataProvider();
			var ccs = new CurrentConditionsSubscriber(wdp);

			wdp.SetInflation(5);

			Assert.That(ccs.Data.Inflacja, Is.EqualTo(5).Within(0.001));
		}
	}
}
