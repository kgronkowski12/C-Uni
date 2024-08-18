using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class nextID
{
    private int id;
    private int biurowyID;

    public int next()
    {
        id += 1;
        return id;
    }
    public int nextBiurowy()
    {
        biurowyID += 1;
        return biurowyID;
    }
}
