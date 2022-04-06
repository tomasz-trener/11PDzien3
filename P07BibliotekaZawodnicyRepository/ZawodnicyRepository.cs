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

        // musilismy to mapownie zrobic recznie ale da sie automatycznie 
        private Zawodnik[] MapujDane(WynikSQL wynikSQL)
        {
            object[][] wynik = wynikSQL.Dane;

            List<Zawodnik> zawodnicy = new List<Zawodnik>();

            for (int i = 0; i < wynik.Length; i++)
            {
                Zawodnik z = new Zawodnik((string)wynik[i][2], (string)wynik[i][3]);
                z.Id_zawodnika = (int)wynik[i][0];

                if (wynik[i][1] != DBNull.Value)
                    z.Id_trenera = (int)wynik[i][1];

                if (wynik[i][4] != DBNull.Value)
                    z.Kraj = (string)wynik[i][4];
               
                z.DataUrodzenia = (DateTime)wynik[i][5];
               
                
                if (wynik[i][6] != DBNull.Value)
                    z.Wzrost = (int)wynik[i][6];
                if (wynik[i][7] != DBNull.Value)
                    z.Waga = (int)wynik[i][7];

                z.DynamiczneKolumny = wynik[i];
                z.DynamiczneNaglowkiKolumn = wynikSQL.Naglowki;

                zawodnicy.Add(z);
            }



            return zawodnicy.ToArray();
        }

        public Zawodnik[] PobierzZawodnikow()
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();
             
            var wynik = 
                pzb.WykonajPolecenieSQL("select * from zawodnicy");

            return MapujDane(wynik);
        }

        public Zawodnik[] PobierzZawodnikow(int idTrenera)
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();
            var wynik =
                pzb.WykonajPolecenieSQL($"select * from zawodnicy where id_trenera={idTrenera}");

            return MapujDane(wynik);
        }


        public Zawodnik[] PobierzZawodnikow(string imieNawiskoKraj, DateTime? dataOd, DateTime? dataDo, int? wzrost,
            int strona=1,int ile=5
            )
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();



            string szablon = "select * from zawodnicy  where 1 = 1";
            if (imieNawiskoKraj != null)
                szablon += $" and (imie like '%{imieNawiskoKraj}%' or nazwisko like '%{imieNawiskoKraj}%' or kraj like '%{imieNawiskoKraj}%')";
            if(dataOd != null)
                szablon += $" and '{dataOd}' >= data_ur ";
            if(dataDo != null)
                szablon += $" and '{dataDo}' <= data_ur ";
            if (wzrost != null)
                szablon += $" and wzrost<= {wzrost} ";

            szablon += $" order by id_zawodnika offset({ile*(strona-1) }) rows fetch next ({ile}) rows only";

            //string szablon = @"select * from zawodnicy
            //    where (imie = '{0}' or nazwisko = '{1}' or kraj = '{2}')
            //    and
            //       ('{3}' >= data_ur and '{4}' <= data_ur)
            //    and wzrost<= {5}";

            var wynik =
                pzb.WykonajPolecenieSQL(string.Format(szablon,imieNawiskoKraj,imieNawiskoKraj,imieNawiskoKraj,
                dataOd,dataDo,wzrost));

            return MapujDane(wynik);
        }

 



            public GrupaIdTrenera[] PobierzGrupyIdTrenera()
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();



            //string szablon = @"select id_trenera, max(kraj), format(max(data_ur), 'dd-MM-yyyy') 
            //                    from zawodnicy
            //                    group by id_trenera";
            string szablon = @"select id_trenera, max(kraj), max(data_ur) 
                                from zawodnicy
                                where id_trenera is not null
                                group by id_trenera";

            var wynik =
                pzb.WykonajPolecenieSQL(szablon);

            // transformacja do obiektów (teraz robimy to ręcznie ale da się to zrobić automatycznie)
            GrupaIdTrenera[] gt = new GrupaIdTrenera[wynik.Dane.Length];
            for (int i = 0; i < gt.Length; i++)
            {
                var g = new GrupaIdTrenera();
                if (wynik.Dane[i][0] == DBNull.Value)
                    g.Id = null;
                else
                    g.Id = (int)wynik.Dane[i][0];

                g.Kraj = (string)wynik.Dane[i][1];

                if (wynik.Dane[i][2] == DBNull.Value)
                    g.DataUr = null;
                else
                    g.DataUr = (DateTime)wynik.Dane[i][2];

                gt[i] = g;
            }
            return gt;
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
            int ileDodano = Convert.ToInt32(wynik.Dane[0][0]);
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
