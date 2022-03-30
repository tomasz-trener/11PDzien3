using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07BibliotekaZawodnicyRepository
{
    internal class PolaczenieZBaza
    {
        string connString;

        public PolaczenieZBaza()
        {
            connString = "***";
        }

        public PolaczenieZBaza(string connString)
        {
            this.connString = connString;   
        }

        public object[][] WykonajPolecenieSQL(string sql)
        {
            SqlConnection connection; //do komunikacji z baza
            SqlCommand sqlCommand;      // przechowuje polecenia SQL
            SqlDataReader reader;       //czyta wynik z bazy


            connection = new SqlConnection(connString);
            sqlCommand = new SqlCommand(sql, connection);
            connection.Open();
            reader = sqlCommand.ExecuteReader();        //wysyłanie polecenia SQL

            int liczbaKolumn = reader.FieldCount;

            
            List<object[]> wynik = new List<object[]>();

            while (reader.Read())
            {
                object[] komorki = new object[liczbaKolumn];
                wynik.Add(komorki);

                for (int i = 0; i < liczbaKolumn; i++)
                    komorki[i] = reader.GetValue(i);
            }

            connection.Close();
            return wynik.ToArray();
        }


    }
}
