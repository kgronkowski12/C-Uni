using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Handlarz;

public class Biurowy : Pracownik
{
    private int idBiurowy;
    private int intelekt;
    public override string ToString(Miejsce miejsce)
    {
        return string.Format("{0}, id biurowe {1}, intelekt {2}", base.ToString(miejsce), idBiurowy, intelekt);
    }
    public override int zwróćWartość()
    {
        return base.zwróćDoświadczenie() * intelekt;
    }
    public Biurowy(int id, string imie, string nazwisko, int wiek, int doswiadczenie, int lokacja, int idBiurowy,int intelekt) : base(id, imie, nazwisko, wiek, doswiadczenie, lokacja)
    {
        if (intelekt < 70)
            intelekt = 70;
        if (intelekt > 150)
            intelekt = 150;
        this.idBiurowy = idBiurowy;
        this.intelekt = intelekt;
    }
}
