using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
                "***";
            connection = new SqlConnection(connString);
            sqlCommand = new SqlCommand("select * from zawodnicy", connection);
            connection.Open();
            reader = sqlCommand.ExecuteReader(); // wysłanie polecenia SQL

            int liczbaKolumn = reader.FieldCount;

            StringBuilder sb = new StringBuilder();

            while (reader.Read())
            {
                //string wynik = "";
                for (int i = 0; i < liczbaKolumn; i++)
                    sb.Append(Convert.ToString(reader.GetValue(i)) + ";");

                sb.Append("\n");
                //Console.WriteLine(wynik);
            }

            connection.Close();
            Console.ReadKey();

            if (!Directory.Exists(@"c:\dane"))
                Directory.CreateDirectory(@"c:\dane");

            File.WriteAllText(@"c:\dane\wynikZawodnicy.txt", sb.ToString());
        }
    }
}
