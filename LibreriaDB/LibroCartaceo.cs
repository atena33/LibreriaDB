using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDB
{
    class LibroCartaceo : Libreria
    {
        List<LibroCartaceo> lc = new List<LibroCartaceo>();

        public int NumeroPagine { get; set; }
        public int Quantita { get; set; }

        private int CalcolaQuantita(string isbn)
        {
            foreach (var item in lc)
            {
                if (item.Isbn == isbn )
                {
                   return item.Quantita += 1;

                }
                
             }

            return Quantita;
        }

        public LibroCartaceo(string titolo, string autore, string isbn, int numeroPagine, int quantita)
            : base (titolo, autore, isbn)
        {
            NumeroPagine = numeroPagine;
            Quantita = CalcolaQuantita(isbn);
        }

        
    }
}
