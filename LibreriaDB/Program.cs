using System;

namespace LibreriaDB
{
    class Program
    {
        static void Main(string[] args)
        {
            DbManagerConnected db = new DbManagerConnected();
            // Il proprietario può vedere tutti i libri stampando titolo, autore e se è o no audiolibro
            // vedere tutta la lista di libri cartacei
            // vedere tutta la lista di audiolibri
            // Modificare la quantità di libri cartacei in magazzino
            // Modificare la durata in minuti di un audiolibro
            // Se inserisce un titolo gli viene mostrato sia il libro cartaceo che l'audiolibro
            // Se inserisce un nuovo libro cartaceo o audiolibro, 
            //     prima di inserirlo verificare che non sia già presente tramite codice ISBN)

            do
            {
                Console.WriteLine("Fai la tua scelta");
                Console.WriteLine("1. Stampa tutti i libri");
                Console.WriteLine("2. Vedi la lista dei libri cartacei");
                Console.WriteLine("3. Vedi la lista degli audiolibri");
                Console.WriteLine("4. Modifica la quantità di libri cartacei");
                Console.WriteLine("5. Modifica la durata di un audiolibro");
                Console.WriteLine("6. Cerca libro per titolo");
                Console.WriteLine("7. Inserisci un nuovo libro");
                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        db.GetAllAudioBooks();
                        db.GetAllPaperBooks();
                        break;
                    case "2":
                        db.GetAllPaperBooks();
                        break;
                    case "3":
                        db.GetAllAudioBooks();
                        break;
                    case "4":
                        db.GetAllPaperBooks();
                        Console.WriteLine("Inserisci l'id del libro che vuoi modificare");
                        var id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserisci la nuova quantità");
                        var quantita = int.Parse(Console.ReadLine());
                        db.EditPaperBooks(quantita , id);
                        break;
                    case "5":
                        db.GetAllAudioBooks();
                        Console.WriteLine("Inserisci l'id del libro che vuoi modificare");
                        var idA = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserisci la nuova durata");
                        var durata = int.Parse(Console.ReadLine());
                        db.EditAudioBooks(durata, idA);
                        break;
                    case "6":
                        Console.WriteLine("Inserisci un titolo");
                        var titolo = Console.ReadLine();
                        db.GetAllPaperBooksByTitle(titolo);
                        db.GetAllAudioBooksByTitle(titolo);
                        break;
                    case "7":
                        Console.WriteLine("Inserisci isbn del libro che vuoi inserire");
                        var isbn = Console.ReadLine();
                        if (isbn == db.GetAllPaperBooks())
                        {
                            Console.WriteLine("Libro già esistente. Modifica la quantità");
                        }
                        else
                        {
                            Console.WriteLine("Inserisci titolo");
                            var titolo1 = Console.ReadLine();
                            Console.WriteLine("Inserisci Autore");
                            var autore1 = Console.ReadLine();
                            Console.WriteLine("Inserisci numero pagine");
                            var numPag = int.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci quantità");
                            var quantita1 = int.Parse(Console.ReadLine());
                            db.InsertPapaerBook(titolo1, autore1, isbn, numPag, quantita1);
                        }

                        break;
                    default:
                        break;
                }
            } while (true);

        }
    }
}
