using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06PolaczenieZBaza
{
    public class Zawodnik
    {
        public int Id_zawodnika;
        public int Id_trenera;
        public string Imie;
        private string nazwisko;
        public string Kraj;
        public DateTime DataUrodzenia; 
        public int Wzrost;
        public int Waga;

        //public void PrzedstawSie1()
        //{
        //    string wynik = $"Nazywam sie {Imie} {Nazwisko} i pochodze z {Kraj}";
        //    Console.WriteLine(wynik);
        //}

        public Zawodnik(string imie, string nazwisko)
        {
            Imie = imie;
            this.nazwisko = nazwisko;
        }

        public string PrzedstawSie2()
        {
          //  string nazwisko ="x";

            string wynik = $"Nazywam sie {Imie} {this.nazwisko} i pochodze z {Kraj}";
            return wynik;
        }





    }
}
