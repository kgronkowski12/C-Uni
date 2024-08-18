using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Fizyczny : Pracownik
{
    private int silaFizyczna;
    public override string ToString(Miejsce miejsce)
    {
        return string.Format("{0}, siła fizyczna {1}", base.ToString(miejsce), silaFizyczna);
    }
    public override int zwróćWartość()
    {
        return base.zwróćDoświadczenie()*silaFizyczna/base.zwróćWiek();
    }
    public Fizyczny(int id, string imie, string nazwisko, int wiek, int doswiadczenie, int lokacja,int silaFizyczna) : base(id,imie,nazwisko,wiek,doswiadczenie, lokacja)
    {
        if (silaFizyczna < 0)
            silaFizyczna = 0;
        if (silaFizyczna > 100)
            silaFizyczna = 100;
        this.silaFizyczna = silaFizyczna;
    }
}
