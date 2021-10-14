using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA211014
{
    class Jatekos
    {
        public int[] Tippek { get; set; }
        public string Nev { get; set; }

        public Jatekos(string r)
        {
            var t = r.Split(' ');
            Tippek = new int[t.Length - 1];
            for (int i = 0; i < t.Length - 1; i++)
            {
                Tippek[i] = int.Parse(t[i]);
            }
            Nev = t.Last();
        }

    }
}
