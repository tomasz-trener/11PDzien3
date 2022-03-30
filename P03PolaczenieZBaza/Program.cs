using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03PolaczenieZBaza 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection; // do komunikacja z baza 
            SqlCommand sqlCommand; // przechowuje polecenia SQL
            SqlDataReader reader;  // czyta wynik z bazy 

            string connString = 
                "Data Source=mssql4.webio.pl,2401;Initial Catalog=tomasz1_zawodnicy;User ID=tomasz1_zawodnicy;Password=Alxalx1!";
            connection = new SqlConnection(connString);
            sqlCommand = new SqlCommand("select * from zawodnicy", connection);
            connection.Open();
            reader = sqlCommand.ExecuteReader(); // wysłanie polecenia SQL

            reader.Read();
            string wynik = (string)reader.GetValue(2);
            Console.WriteLine(wynik);

            connection.Close();
            Console.ReadKey();

        }
    }
}
