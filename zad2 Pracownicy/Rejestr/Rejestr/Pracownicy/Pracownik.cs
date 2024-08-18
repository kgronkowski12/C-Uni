using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Pracownik
{
    private int id;
    private string imie;
    private string nazwisko;
    private int wiek;
    private int doswiadczenie;
    private int lokacja;

    public int getId()
    {
        return id;
    }
    public int zwróćLokalizacja()
    {
        return lokacja;
    }
    public int zwróćDoświadczenie()
    {
        return doswiadczenie;
    }
    public int zwróćWiek()
    {
        return wiek;
    }

    public string zwróćNazwisko()
    {
        return nazwisko;
    }
    public Pracownik(int id, string imie, string nazwisko, int wiek, int doswiadczenie, int lokacja)
    {
        this.id = id;
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.wiek = wiek;
        this.doswiadczenie = doswiadczenie;
        this.lokacja = lokacja;
    }
    public virtual string ToString(Miejsce miejsce)
    {
        return string.Format("id: {0}, {1} {2}, {3} lat, {4} lat doświadczenia, lokacja: {5} {6}/{7}, {8}", id,imie,nazwisko,wiek,doswiadczenie,miejsce.ulica,miejsce.numerBudynku,miejsce.numerLokalu,miejsce.miasto);
    }
    public abstract int zwróćWartość();
}
