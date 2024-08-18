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
        public void TestDzia�a()
        {
            Assert.Pass();
        }
        [Test]
        public void RejestrIstnieje()
        {
            Assert.That(rejestr, Is.Not.Null);
        }
        [Test]
        public void Usu�Pusty()
        {
            Assert.Throws<InvalidOperationException>(() => rejestr.Usu�(0));
        }
        [Test]
        public void DuplikatID()
        {
            Fizyczny fiz1 = new Fizyczny(rejestr._nextID.next(), "Kamil", "G�rski", 21, 2, 0, 77);
            Fizyczny fiz2 = new Fizyczny(1, "Ala", "Ba�ajewicz", 25, 2, 1, 70);
            rejestr.Dodaj(fiz1);
            Assert.Throws<InvalidOperationException>(() => rejestr.Dodaj(fiz2));
        }
        [Test]
        public void LokacjaPozaZakres()
        {
            Fizyczny fiz1 = new Fizyczny(rejestr._nextID.next(), "Kamil", "G�rski", 21, 2, 0, 77);
            rejestr.Dodaj(fiz1);
            Assert.Throws<InvalidOperationException>(() => rejestr.wy�wietlWarto��());
        }
        [Test]
        public void LokacjaEdycja()
        {
            rejestr.zwr��Lokalizacje().dodaj("D�uga", 7, 2, "Gda�sk");
            rejestr.zwr��Lokalizacje().edytuj(0, "Inna", 1, 1, "NieGda�sk");
            Assert.Pass();
        }
        [Test]
        public void LokacjaUsu�()
        {
            rejestr.zwr��Lokalizacje().dodaj("D�uga", 7, 2, "Gda�sk");
            rejestr.zwr��Lokalizacje().dodaj("Kolorowa", 18, 3, "Wroc�aw");
            rejestr.zwr��Lokalizacje().dodaj("Zawi�a", 12, 1, "Warszawa");
            rejestr.zwr��Lokalizacje().usu�(1);
            Assert.Pass();
        }
        [Test]
        public void TestDodawanieR�nych()
        {
            rejestr.zwr��Lokalizacje().dodaj("D�uga", 7, 2, "Gda�sk");
            rejestr.zwr��Lokalizacje().dodaj("Kolorowa", 18, 3, "Wroc�aw");
            rejestr.zwr��Lokalizacje().dodaj("Zawi�a", 12, 1, "Warszawa");
            Fizyczny fiz1 = new Fizyczny(rejestr._nextID.next(), "Kamil", "G�rski", 21, 2, 0, 77);
            Biurowy bi1 = new Biurowy(rejestr._nextID.next(), "B�a�ej", "Wi�niewski", 41, 6, 1, rejestr._nextID.nextBiurowy(), 14);
            Handlarz h1 = new Handlarz(rejestr._nextID.next(), "Wie�niak", "Cebulak", 18, 0, 1, 14, Handlarz.Skuteczno��.Niska);
            rejestr.Dodaj(fiz1);
            rejestr.Dodaj(bi1);
            rejestr.Dodaj(h1);
            rejestr.wy�wietlMiasto("Gda�sk");
            Assert.Pass();
        }
        [Test]
        public void TestWarto��1()
        {
            Handlarz h1 = new Handlarz(rejestr._nextID.next(), "Wie�niak", "Cebulak", 18, 0, 1, 14, Handlarz.Skuteczno��.Niska);
            int result = h1.zwr��Warto��();
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void TestWarto��2()
        {
            Fizyczny h1 = new Fizyczny(rejestr._nextID.next(), "Kamil", "G�rski", 21, 2, 0, 77);
            int result = h1.zwr��Warto��();
            Assert.That(result, Is.EqualTo(7));
        }
        [Test]
        public void TestWarto��3()
        {
            Biurowy h1 = new Biurowy(rejestr._nextID.next(), "Nowy", "Go�ciu", 60, 30, 2, rejestr._nextID.nextBiurowy(), 99);
            int result = h1.zwr��Warto��();
            Assert.That(result, Is.EqualTo(2970));
        }
    }
}