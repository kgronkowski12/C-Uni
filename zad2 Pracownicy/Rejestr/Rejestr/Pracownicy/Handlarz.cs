using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Handlarz : Pracownik
{
    public enum Skuteczność
    {
        Niska,
        Średnia,
        Wysoka
    }

    private int prowizja;
    private Skuteczność skuteczność;

    public Handlarz(int id, string imie, string nazwisko, int wiek, int doswiadczenie, int lokacja, int prowizja, Skuteczność skuteczność) : base(id, imie, nazwisko, wiek, doswiadczenie, lokacja)
    {
        this.prowizja = prowizja;
        this.skuteczność = skuteczność;
    }
    public override int zwróćWartość()
    {
        return base.zwróćDoświadczenie() * ((int)skuteczność*30+60);
    }

    public override string ToString(Miejsce miejsce)
    {
        return string.Format("{0}, prowizja = {1}%, skuteczność {2}", base.ToString(miejsce),prowizja,skuteczność);
    }
}
