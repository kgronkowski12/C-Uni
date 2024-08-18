using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Miejsce
{
    public string ulica;
    public int numerBudynku;
    public int numerLokalu;
    public string miasto;

    public Miejsce(string ulica, int numerBudynku,int numerLokalu, string miasto)
    {
        this.ulica = ulica;
        this.numerBudynku = numerBudynku;
        this.numerLokalu = numerLokalu;
        this.miasto = miasto;
    }
}
