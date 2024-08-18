using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Sort
{
    public List<Pracownik> TripleSort(List<Pracownik> pracownicy)
    {
        return pracownicy
            .OrderByDescending(e => e.zwróćDoświadczenie()).
            ThenBy(e => e.zwróćWiek()).
            ThenBy(e => e.zwróćNazwisko()).
            ToList();
    }
}

