using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02SlowoStatic
{
    internal class Program
    {
        public static Czlowiek Metoda()
        {
            Czlowiek c = new Czlowiek();
            return c;
        }


        static void Main(string[] args)
        {




            Czlowiek c1 = new Czlowiek();
            c1.Imie = "Jan";
            // c1.Nazwisko = "Kowalski";


            Czlowiek c3 = Metoda();


            Czlowiek c2 = new Czlowiek();
            c2.Imie = "Adam";
            // c2.Nazwisko = "Nowak";

            // dostep do tego elemtu
            // poprzez całą klasę bo jest static 
            Czlowiek.Nazwisko = "Kowalski";


            c2.PodajNazwisko();

            Czlowiek c4 = Czlowiek.StworzDomyslnegoCzlowieka;

            DateTime dt = DateTime.Now;


            // ParametryDomyslneBazyDanych p = new ParametryDomyslneBazyDanych();
            // string s = p.ConnectionString;

            string s =
                ParametryDomyslneBazyDanych.ConnectionString;

        }
    }
}
