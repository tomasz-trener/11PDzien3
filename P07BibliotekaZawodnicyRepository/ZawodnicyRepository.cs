using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07BibliotekaZawodnicyRepository
{
    // CRUD - Create Read Update Delete
    public class ZawodnicyRepository
    {
        public Zawodnik[] PobierzZawodnikow()
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();
             
            var wynik = 
                pzb.WykonajPolecenieSQL("select id_zawodnika, id_trenera,imie, nazwisko,kraj,data_ur,wzrost,waga from zawodnicy");

            List<Zawodnik> zawodnicy = new List<Zawodnik>();

            for (int i = 0; i < wynik.Length; i++)
            {
                Zawodnik z = new Zawodnik((string)wynik[i][2], (string)wynik[i][3]);
                z.Id_zawodnika = (int)wynik[i][0];
                
                if(wynik[i][1] != DBNull.Value)
                    z.Id_trenera = (int)wynik[i][1];
                
                z.Kraj = (string)wynik[i][4];
                z.DataUrodzenia = (DateTime)wynik[i][5];
                z.Wzrost = (int)wynik[i][6];
                z.Waga = (int)wynik[i][7];
                zawodnicy.Add(z);
            }
            return zawodnicy.ToArray();
        }

        public int DodajZawodnika(Zawodnik z)
        {
            string szablonInsert = @"insert into zawodnicy 
                    (id_trenera,imie, nazwisko,kraj,data_ur,wzrost,waga) 
                    values 
                    ({0},'{1}','{2}','{3}','{4}',{5},{6})
                    SELECT @@IDENTITY";

            string sql = string.Format(
                szablonInsert,
                z.Id_trenera, z.Imie, z.Nazwisko, z.Kraj, z.DataUrodzenia, z.Wzrost, z.Waga);

            PolaczenieZBaza pzb = new PolaczenieZBaza();
            var wynik= pzb.WykonajPolecenieSQL(sql);
            int ileDodano = Convert.ToInt32(wynik[0][0]);
            return ileDodano;
        }


        // w tym momencie to jest niepotrzebne 
        // bo mamy bardziej uniwersalna metode
        public void UsunZawodnika(int id)
        {
            string szablon = "delete zawodnicy where id_zawodnika={0}";

            string sql = string.Format(szablon, id);

            PolaczenieZBaza pzb = new PolaczenieZBaza();
            pzb.WykonajPolecenieSQL(sql);
        }

        public void UsunZawodnikow(params int[] id)
        {
            string szablon = "delete zawodnicy where id_zawodnika in ({0})";

            string sql = string.Format(szablon, string.Join(",", id));

            PolaczenieZBaza pzb = new PolaczenieZBaza();
            pzb.WykonajPolecenieSQL(sql);
        }

        public void Edytuj(params Zawodnik[] zawodnicy)
        {
            string szablon = @"update zawodnicy 
                    set imie = '{0}', nazwisko = '{1}', kraj = '{2}'
                    , data_ur = '{3}', wzrost = {4}, waga = {5}
                    where id_zawodnika = {6} ";

            string sql = "";

            foreach (var z in zawodnicy)
                sql += string.Format(szablon, z.Imie, z.Nazwisko, z.Kraj, z.DataUrodzenia, z.Wzrost, z.Waga,z.Id_zawodnika);

            PolaczenieZBaza pzb = new PolaczenieZBaza();
            pzb.WykonajPolecenieSQL(sql);
        }

    }
}
