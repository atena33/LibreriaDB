using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDB
{
    abstract class Libreria
    {
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string Isbn { get; set; }

        public Libreria(string titolo, string autore, string isbn)
        {
            Titolo = titolo;
            Autore = autore;
            Isbn = isbn;
        }
    }
}
