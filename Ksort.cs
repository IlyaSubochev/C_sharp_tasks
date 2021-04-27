using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortSpace
{
    public class Ksort
    {
        public string[] items;

        public Ksort()
        {
            items = new string[800];
        }

        public int Index(string s)
        {
            if (s == null || s.Length != 3 || Char.GetNumericValue(s[1]) == -1 || Char.GetNumericValue(s[2]) == -1 || s[0] < 97 || s[0] > 104) 
                return -1;
            return (int)(((s[0] - 97) * 100) + (Char.GetNumericValue(s[1]) * 10) + Char.GetNumericValue(s[2]));
        }

        public bool Add(string s)
        {
            int index = Index(s);
            if (index != -1)
            {
                items[index] = s;
                return true;
            }
            return false;
        }
    }
}
