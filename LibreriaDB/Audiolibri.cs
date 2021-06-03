using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDB
{
    class Audiolibri : Libreria
    {
        public int DurataMin { get; set; }

        public Audiolibri(string titolo, string autore, string isbn, int durataMin)
            : base (titolo, autore, isbn)
        {
            DurataMin = durataMin;
        }

    }
}
