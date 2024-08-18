using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Lokalizacja
{
    private List<Miejsce> lokalizacje = new List<Miejsce>();
    public void dodaj(string ulica, int numerBudynku, int numerLokalu, string miasto)
    {
        Miejsce miejsce = new Miejsce(ulica, numerBudynku, numerLokalu, miasto);
        lokalizacje.Add(miejsce);
    }
    public void edytuj(int id, string ulica, int numerBudynku, int numerLokalu, string miasto)
    {
        Miejsce miejsce = new Miejsce(ulica, numerBudynku, numerLokalu, miasto);
        if (id <= lokalizacje.Count - 1)
        {
            lokalizacje[id] = miejsce;
        }
        else
        {
            Console.WriteLine("ID z poza zakresu Lokacji!");
            throw new InvalidOperationException();
        }
    }

    public void usuń(int id)
    {
        if (id <= lokalizacje.Count - 1)
        {
            lokalizacje.RemoveAt(id);
        }
        else
        {
            Console.WriteLine("ID z poza zakresu Lokacji!");
            throw new InvalidOperationException();
        }
    }

    public Miejsce zwróćMiejsce(int id)
    {
        if (id <= lokalizacje.Count - 1)
        {
            return lokalizacje[id];
        }
        else
        {
            Console.WriteLine("ID z poza zakresu Lokacji!");
            throw new InvalidOperationException();
        }
    }

    public List<Miejsce> zwróćLokalizacje()
    {
        return lokalizacje;
    }
}
