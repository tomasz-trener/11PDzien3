using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02SlowoStatic
{
    internal class Czlowiek
    {
        public string Imie { get; set; }
        public static string Nazwisko;


        public static Czlowiek StworzDomyslnegoCzlowieka
        {
            get
            {
                return new Czlowiek()
                {
                    Imie = "Jan super man",
                   // Nazwisko = "Super Man"
                };
            }
        }

        // jak NIE jest static 
        // to ten element (właściowośc, pole lub metoda)
        // są częścią instancji klasy 

        // jak JEST static 
        // to ten element jest częścią całej klasy 

         
        public void PodajNazwisko()
        {
            string s = Nazwisko;
            Console.WriteLine(s);
        }




        public static void PodajImie()
        {
           // string s = Imie
        }

    }
}
