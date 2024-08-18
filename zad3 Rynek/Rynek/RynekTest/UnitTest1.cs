using Rynek;

namespace RynekTest
{
    public class Tests
    {
        Ryneksy reks;
        [SetUp]
        public void Setup()
        {
            Ryneksy reks = new Ryneksy();
        }

        [Test]
        public void TestTest()
        {
            Assert.Pass();
        }
        [Test]
        public void TestPodaz()
        {
            Sprzedawca s = reks.returnSprz();
            int cena1 = s.oferta[0].Price;
            for (int x = 0; x < 5; x++)
            {
                reks.nextTurn();
            }
            int cena2 = s.oferta[0].Price;
            if (cena1 > cena2){
                Assert.Pass();
            }
        }
    }
}