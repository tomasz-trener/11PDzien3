using P07BibliotekaZawodnicyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08ZadanieZawodnicy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();

            ////testowanie update
            //Zawodnik[] zawodnicy = new Zawodnik[2]
            //{
            //    new Zawodnik(){ Id_zawodnika=19,Imie="xx", DataUrodzenia = DateTime.Now},
            //    new Zawodnik(){ Id_zawodnika=20,Imie="yy", DataUrodzenia = DateTime.Now},
            //};
            //zr.Edytuj(zawodnicy);

            // testowanie usuwania
            //zr.UsunZawodnikow(18,19,20,22);
            // lub 
            //zr.UsunZawodnikow(new int[] { 18, 19, 20, 22 });

            // testowanie dodwania 
            // Zawodnik z = new Zawodnik("Adam", "Kowalski");
            // z.DataUrodzenia = DateTime.Now;
            // int a= zr.DodajZawodnika(z);
            //Console.WriteLine($"Dodano rekord o id ={a}");

            var zaw= zr.PobierzZawodnikow().Where(x=>x.Kraj == "POL").ToArray();

            foreach (var zw in zaw)
                Console.WriteLine(zw.PrzedstawSie2());

           




            Console.ReadKey();
        }
    }
}
