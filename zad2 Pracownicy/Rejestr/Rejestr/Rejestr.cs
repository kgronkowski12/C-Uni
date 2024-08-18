using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register;

public class Rejestr
{
    private readonly Dictionary<int, Pracownik> rejestr = new Dictionary<int, Pracownik>();
    private Lokalizacja lokalizacja = new Lokalizacja();
    public nextID _nextID = new nextID();
    public Sort sorter = new Sort();
    public Dictionary<int, Pracownik> zwróćRejestr()
    {
        return rejestr;
    }
    public Lokalizacja zwróćLokalizacje()
    {
        return lokalizacja;
    }
    public void Dodaj(Pracownik p)
    {
        if (rejestr.ContainsKey(p.getId()))
        {
            throw new InvalidOperationException();
        }
        rejestr[p.getId()] = p;
    }

    public void Usuń(int id)
    {
        if (!rejestr.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }
        rejestr.Remove(id);
    }
    public void wyświetlSort()
    {
        List<Pracownik> allItems = rejestr.Values.ToList();
        allItems = sorter.TripleSort(allItems);

        foreach (Pracownik p in allItems)
        {
            Console.WriteLine(p.ToString(lokalizacja.zwróćMiejsce(p.zwróćLokalizacja())));
        }
    }

    public void wyświetlMiasto(string miasto)
    {
        foreach (KeyValuePair<int, Pracownik> p in rejestr)
        {
            Miejsce lok = lokalizacja.zwróćMiejsce(p.Value.zwróćLokalizacja());
            if (lok.miasto==miasto)
                Console.WriteLine(p.Value.ToString(lokalizacja.zwróćMiejsce(p.Value.zwróćLokalizacja())));
        }
    }

    public void wyświetlWartość()
    {
        foreach (KeyValuePair<int, Pracownik> p in rejestr)
        {
            Console.WriteLine(p.Value.ToString(lokalizacja.zwróćMiejsce(p.Value.zwróćLokalizacja()))+", Wartość : "+p.Value.zwróćWartość());
        }
    }
}
