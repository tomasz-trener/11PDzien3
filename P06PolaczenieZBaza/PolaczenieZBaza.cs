using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06PolaczenieZBaza
{
    internal class PolaczenieZBaza
    {
        string connString;

        public PolaczenieZBaza()
        {
            connString = "Data Source=mssql4.webio.pl,2401;Initial Catalog=tomasz1_zawodnicy;User ID=tomasz1_zawodnicy;Password=Alxalx1!";
        }

        public PolaczenieZBaza(string connString)
        {
            this.connString = connString;   
        }

        public string[][] WykonajPolecenieSQL(string sql)
        {
            SqlConnection connection; //do komunikacji z baza
            SqlCommand sqlCommand;      // przechowuje polecenia SQL
            SqlDataReader reader;       //czyta wynik z bazy


            connection = new SqlConnection(connString);
            sqlCommand = new SqlCommand(sql, connection);
            connection.Open();
            reader = sqlCommand.ExecuteReader();        //wysyłanie polecenia SQL

            int liczbaKolumn = reader.FieldCount;

            
            List<string[]> wynik = new List<string[]>();

            while (reader.Read())
            {
                string[] komorki = new string[liczbaKolumn];
                wynik.Add(komorki);

                for (int i = 0; i < liczbaKolumn; i++)
                    komorki[i] = Convert.ToString(reader.GetValue(i));
            }

            connection.Close();
            return wynik.ToArray();
        }


    }
}
