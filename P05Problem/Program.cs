using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05Problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection; //do komunikacji z baza
            SqlCommand sqlCommand;      // przechowuje polecenia SQL
            SqlDataReader reader;       //czyta wynik z bazy


            string connString =
               "Data Source=mssql4.webio.pl,2401;Initial Catalog=tomasz1_zawodnicy;User ID=tomasz1_zawodnicy;Password=Alxalx1!";

            connection = new SqlConnection(connString);
            sqlCommand = new SqlCommand("select *, format(data_ur,'dd-MM-yyyy') from zawodnicy", connection);
            connection.Open();
            reader = sqlCommand.ExecuteReader();        //wysyłanie polecenia SQL

            int liczbaKolumn = reader.FieldCount;

            StringBuilder sb = new StringBuilder();

            //using(StreamWriter streamWriter = File.AppendText(@"c:\dane\wynik.txt")) 
            //{
            //    while (reader.Read())
            //    {
            //        string wynik = "";
            //        for (int i = 0; i < liczbaKolumn; i++)
            //            //wynik+= Convert.ToString(reader.GetValue(i)) + " ";                
            //            sb.Append(Convert.ToString(reader.GetValue(i)) + " ");

            //        sb.Append("\n");
            //        //Console.WriteLine(wynik);

            //        streamWriter.WriteLine(sb.ToString());
            //    }

            //}

            using (StreamWriter streamWriter = new StreamWriter(@"c:\dane\wynik.txt", true, Encoding.UTF32, 1024))
            {
                while (reader.Read())
                {
                  //  string wynik = "";
                    for (int i = 0; i < liczbaKolumn; i++)
                        //wynik+= Convert.ToString(reader.GetValue(i)) + " ";                
                        sb.Append(Convert.ToString(reader.GetValue(i)) + " ");

                    sb.Append("\n");
                    //Console.WriteLine(wynik);

                    streamWriter.WriteLine(sb.ToString());
                }

            }


            connection.Close();
            Console.ReadKey();

            if (!Directory.Exists(@"c:\dane"))
                Directory.CreateDirectory(@"c:\dane"); //tworzy wszystkie podkatalogi, których nie ma

            File.AppendAllText(@"c:\dane\wynikZawodnicy.txt", sb.ToString());



        }
    }
}
