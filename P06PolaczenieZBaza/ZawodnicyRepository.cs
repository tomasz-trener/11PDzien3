using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06PolaczenieZBaza
{
    internal class ZawodnicyRepository
    {
        public Zawodnik[] PobierzZawodnikow()
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();
             
            var wynik = 
                pzb.WykonajPolecenieSQL("select id_zawodnika, id_trenera,imie, nazwisko,kraj,data_ur,wzrost,waga from zawodnicy");

            List<Zawodnik> zawodnicy = new List<Zawodnik>();

            for (int i = 0; i < wynik.Length; i++)
            {
                Zawodnik z = new Zawodnik(wynik[i][2], wynik[i][3]);
                z.Id_zawodnika = Convert.ToInt32(wynik[i][0]);
                
                if(!string.IsNullOrWhiteSpace(wynik[i][1]))
                    z.Id_trenera = Convert.ToInt32(wynik[i][1]);
                
                z.Kraj = wynik[i][4];
                z.DataUrodzenia = Convert.ToDateTime(wynik[i][5]);
                z.Wzrost = Convert.ToInt32(wynik[i][6]);
                z.Waga = Convert.ToInt32(wynik[i][7]);
                zawodnicy.Add(z);
            }

            return zawodnicy.ToArray();
        }

    }
}
