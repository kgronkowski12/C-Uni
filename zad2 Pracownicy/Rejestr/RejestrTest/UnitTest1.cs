using System.Runtime.InteropServices;

namespace RegisterTest
{
    public class Tests
    {
        private Rejestr rejestr;
        [SetUp]
        public void Setup()
        {
            rejestr = new Rejestr();
        }
        [Test]
        public void TestDzia³a()
        {
            Assert.Pass();
        }
        [Test]
        public void RejestrIstnieje()
        {
            Assert.That(rejestr, Is.Not.Null);
        }
        [Test]
        public void UsuñPusty()
        {
            Assert.Throws<InvalidOperationException>(() => rejestr.Usuñ(0));
        }
        [Test]
        public void DuplikatID()
        {
            Fizyczny fiz1 = new Fizyczny(rejestr._nextID.next(), "Kamil", "Górski", 21, 2, 0, 77);
            Fizyczny fiz2 = new Fizyczny(1, "Ala", "Ba³ajewicz", 25, 2, 1, 70);
            rejestr.Dodaj(fiz1);
            Assert.Throws<InvalidOperationException>(() => rejestr.Dodaj(fiz2));
        }
        [Test]
        public void LokacjaPozaZakres()
        {
            Fizyczny fiz1 = new Fizyczny(rejestr._nextID.next(), "Kamil", "Górski", 21, 2, 0, 77);
            rejestr.Dodaj(fiz1);
            Assert.Throws<InvalidOperationException>(() => rejestr.wyœwietlWartoœæ());
        }
        [Test]
        public void LokacjaEdycja()
        {
            rejestr.zwróæLokalizacje().dodaj("D³uga", 7, 2, "Gdañsk");
            rejestr.zwróæLokalizacje().edytuj(0, "Inna", 1, 1, "NieGdañsk");
            Assert.Pass();
        }
        [Test]
        public void LokacjaUsuñ()
        {
            rejestr.zwróæLokalizacje().dodaj("D³uga", 7, 2, "Gdañsk");
            rejestr.zwróæLokalizacje().dodaj("Kolorowa", 18, 3, "Wroc³aw");
            rejestr.zwróæLokalizacje().dodaj("Zawi³a", 12, 1, "Warszawa");
            rejestr.zwróæLokalizacje().usuñ(1);
            Assert.Pass();
        }
        [Test]
        public void TestDodawanieRó¿nych()
        {
            rejestr.zwróæLokalizacje().dodaj("D³uga", 7, 2, "Gdañsk");
            rejestr.zwróæLokalizacje().dodaj("Kolorowa", 18, 3, "Wroc³aw");
            rejestr.zwróæLokalizacje().dodaj("Zawi³a", 12, 1, "Warszawa");
            Fizyczny fiz1 = new Fizyczny(rejestr._nextID.next(), "Kamil", "Górski", 21, 2, 0, 77);
            Biurowy bi1 = new Biurowy(rejestr._nextID.next(), "B³a¿ej", "Wiœniewski", 41, 6, 1, rejestr._nextID.nextBiurowy(), 14);
            Handlarz h1 = new Handlarz(rejestr._nextID.next(), "Wieœniak", "Cebulak", 18, 0, 1, 14, Handlarz.Skutecznoœæ.Niska);
            rejestr.Dodaj(fiz1);
            rejestr.Dodaj(bi1);
            rejestr.Dodaj(h1);
            rejestr.wyœwietlMiasto("Gdañsk");
            Assert.Pass();
        }
        [Test]
        public void TestWartoœæ1()
        {
            Handlarz h1 = new Handlarz(rejestr._nextID.next(), "Wieœniak", "Cebulak", 18, 0, 1, 14, Handlarz.Skutecznoœæ.Niska);
            int result = h1.zwróæWartoœæ();
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void TestWartoœæ2()
        {
            Fizyczny h1 = new Fizyczny(rejestr._nextID.next(), "Kamil", "Górski", 21, 2, 0, 77);
            int result = h1.zwróæWartoœæ();
            Assert.That(result, Is.EqualTo(7));
        }
        [Test]
        public void TestWartoœæ3()
        {
            Biurowy h1 = new Biurowy(rejestr._nextID.next(), "Nowy", "Goœciu", 60, 30, 2, rejestr._nextID.nextBiurowy(), 99);
            int result = h1.zwróæWartoœæ();
            Assert.That(result, Is.EqualTo(2970));
        }
    }
}