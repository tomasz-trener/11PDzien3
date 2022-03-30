using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01Wlasciwosci
{
    internal class Czlowiek
    {

        // pola, właściwości, metody, konstruktory 

        public Czlowiek()
        {
            nazwisko = "nowak";
        }

        public string Imie;
        
        private string nazwisko; //-> Kowalski

        /// <summary>
        /// Ustawienie Nazwiska jako właściwość
        /// </summary>
        public string Nazwisko
        {
            get
            {
                return nazwisko.ToUpper();
            }
            set
            {
                nazwisko = value.Substring(0, 1).ToUpper() +
                     value.Substring(1).ToLower();
            }
        }

        private int wzrost;

        public int Wzrost
        {
            get { return wzrost; }
            set { wzrost = value; }
        }

        //private int waga;
        //public int Waga
        //{
        //    get { return waga; }
        //    set { waga = value; }
        //}
        public int Waga { get; set; } // Właściwość
         
        public int Waga2; // Pole
        // czym się różnicy w praktyce? 
        // w tym konkretnym przypadku niczym się nie różni 

        // uwaga generalna przy projektowaniu klas
        // jak udstostępniamy na zewnatrz klasy 
        // pole (public) to lepiej żeby to była właściwość
        // a nie pole 


        // jak radzą sobie programisci innych jezyków gdy 
        // ich język nie pozwalana na tworzenie 
        // właściwości 

        //public void UstawNazwisko(string n)
        //{
        //    nazwisko = n.Substring(0, 1).ToUpper() +
        //        n.Substring(1).ToLower();
        //}

        //public string PodajNazwisko() 
        //{
        //    return nazwisko.ToUpper();
        //}


    }
}
