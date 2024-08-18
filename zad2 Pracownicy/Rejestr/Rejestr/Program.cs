using System.Runtime.InteropServices;

namespace Register;

class Program
{
    static void Main(string[] args)
    {
        Rejestr rejestr = new Rejestr();
        rejestr.zwróćLokalizacje().dodaj("Długa", 7, 2, "Gdańsk");
        rejestr.zwróćLokalizacje().dodaj("Kolorowa", 18, 3, "Wrocław");
        rejestr.zwróćLokalizacje().dodaj("Zawiła", 12, 1, "Warszawa");
        Fizyczny fiz1 = new Fizyczny(rejestr._nextID.next(), "Kamil", "Górski", 21, 2, 0, 77);
        Fizyczny fiz2 = new Fizyczny(rejestr._nextID.next(), "Ala", "Bałajewicz", 25, 2, 1, 70);
        Fizyczny fiz3 = new Fizyczny(rejestr._nextID.next(), "Usunięty", "Spadówa", 31, 15, 0, 100);
        Biurowy bi1 = new Biurowy(rejestr._nextID.next(), "Błażej", "Wiśniewski", 41, 6, 1, rejestr._nextID.nextBiurowy(), 14);
        Biurowy bi2 = new Biurowy(rejestr._nextID.next(), "Nowy", "Gościu", 60, 30, 2, rejestr._nextID.nextBiurowy(), 99);
        Biurowy bi3 = new Biurowy(rejestr._nextID.next(), "Tomasz", "Polatek", 33, 7, 2, rejestr._nextID.nextBiurowy(), 1);
        Handlarz h1 = new Handlarz(rejestr._nextID.next(), "Wieśniak", "Cebulak", 18, 0, 1, 14, Handlarz.Skuteczność.Niska);
        Handlarz h2 = new Handlarz(rejestr._nextID.next(), "Adam", "Mickiewicz", 25, 3, 0, 30, Handlarz.Skuteczność.Wysoka);

        rejestr.Dodaj(fiz1);
        rejestr.Dodaj(fiz2);
        rejestr.Dodaj(fiz3);
        rejestr.Dodaj(bi1);
        rejestr.Dodaj(bi2);
        rejestr.Dodaj(bi3);
        rejestr.Dodaj(h1);
        rejestr.Dodaj(h2);
        rejestr.Usuń(3);

        Console.WriteLine("Wyświetlanie z sortowaniem (dośw malejąco, wiek rosnąco i po nazwisku)\n");
        rejestr.wyświetlSort();
        Console.WriteLine("\n---\nWyświetlanie wszystkich pracowników z Gdańska\n");
        rejestr.wyświetlMiasto("Gdańsk");
        Console.WriteLine("\n---\nWyświetlanie wszystkich pracowników z ich wartością\n");
        rejestr.wyświetlWartość();
    }
}