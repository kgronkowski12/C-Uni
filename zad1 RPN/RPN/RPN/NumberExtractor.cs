using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN;

public class NumberExtractor
{
    private int DecimalExtraction(string s)
    {
        if(Int32.TryParse(s, out _))
        {
            return Int32.Parse(s);
        }
        throw new InvalidOperationException();
    }
    private int BinaryExtraction(string s)
    {
        if (Int32.TryParse(s, out _))
        {
            return Convert.ToInt32(s, 2);
        }
        throw new InvalidOperationException();
    }
    private int HexExtraction(string s)
    {
        foreach(char x in s)
        {
            if (!char.IsAsciiHexDigit(x))
            {
                throw new InvalidOperationException();
            }
        }
        return Convert.ToInt32(s, 16);
    }

    public int GetNumber(string s)
    {
        char numberType = s[0];
        s = s.Substring(1);
        if (numberType == 'B')
        {
            return BinaryExtraction(s);
        }
        else if (numberType == 'D'){
            return DecimalExtraction(s);
        }
        else if (numberType == '#')
        {
            return HexExtraction(s);
        }
        throw new InvalidOperationException();
    }
}
