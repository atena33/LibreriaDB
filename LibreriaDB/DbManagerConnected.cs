using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LibreriaDB
{
    class DbManagerConnected : IDbManager


    {
        List<LibroCartaceo> c = new List<LibroCartaceo>();
        const string connectionString = @"Data Source= (localdb)\MSSQLLocalDB;" +
                                          "Initial Catalog = Libreria;" +
                                          "Integrated Security=true;";

        public void GetAllAudioBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from AudioLibro ";

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    
                    var id = reader["Id"];
                    var titolo = reader["Titolo"];
                    var autore = reader["Autore"];
                    var isAudio = reader["DurataMin"];

                   
                    Console.WriteLine($" Id : {id } Titolo: {titolo}, Autore: {autore} è un audiolibro");
                    
                 }
                connection.Close(); 
            }
        }

        public string GetAllPaperBooks()

        {
            string isbn = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from LibroCartaceo ";

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    var id = reader["Id"];
                    var titolo = reader["Titolo"];
                    var autore = reader["Autore"];
                    isbn = (string)reader["ISBN"];


                    Console.WriteLine($" Id: {id} Titolo: {titolo}, Autore: {autore} è un libro cartaceo");
                    
                 }
                connection.Close();
                return isbn;
            }
        }

        public void EditPaperBooks(int quantita, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update dbo.LibroCartaceo set Quantita = @Quantita where Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Quantita", quantita);


                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Il libro con Id {id} è stato modificato");
                connection.Close(); 

            }
        }

        public void EditAudioBooks(int durata, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
              
                command.CommandText = "update dbo.AudioLibro set DurataMin = @Durata where Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Durata", durata);


                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Il libro con Id {id} è stato modificato");
                connection.Close(); 

            }
        }

        public void GetAllPaperBooksByTitle(string titolo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
              
                command.CommandText = "select * from LibroCartaceo where Titolo = @Titolo";

                command.Parameters.AddWithValue("@Titolo", titolo);



                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    
                    var titolo1 = reader["Titolo"];
                    var autore = reader["Autore"];
                    Console.WriteLine($"  Titolo: {titolo}, Autore: {autore}");

                 }
                connection.Close();
            }
        }

        public void GetAllAudioBooksByTitle(string titolo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from AudioLibro where TitoloA = @Titolo";

                command.Parameters.AddWithValue("@Titolo", titolo);



                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                   
                    var titolo1 = reader["TitoloA"];
                    var autore = reader["Autore"];
                    var isbn = reader["ISBN"];
                    var numeroPagine = reader["NumeroPagine"];
                    var quantita = reader["Quantita"];
                        
                    Console.WriteLine($"  Titolo: {titolo1}, Autore: {autore}");

                 }
                connection.Close(); 
            }
        }

        public void InsertPapaerBook(string titolo, string autore, string isbn, int numeroPagine, int quantita)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "insert into dbo.Film values (@Titolo, @Autore, @Isbn, @NumeroPagine, @Quantita)";
                command.Parameters.AddWithValue("@Titolo", titolo);
                command.Parameters.AddWithValue("@DAutore", autore);
                command.Parameters.AddWithValue("@Isbn", isbn);
                command.Parameters.AddWithValue("@NumeroPagine", numeroPagine);
                command.Parameters.AddWithValue("@Quantita", quantita);



                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
 }

