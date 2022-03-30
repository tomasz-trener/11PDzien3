using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06PolaczenieZBaza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("wersja 1: dane wczytujemy do tablicy tablic");
            PolaczenieZBaza pzb = new PolaczenieZBaza("Data Source=mssql4.webio.pl,2401;Initial Catalog=tomasz1_zawodnicy;User ID=tomasz1_zawodnicy;Password=Alxalx1!");

            var wynik =
                pzb.WykonajPolecenieSQL("select kraj, avg(wzrost) from zawodnicy group by kraj");

            Console.WriteLine("kraj\tavg(wzrost)");
            foreach (var w in wynik)
                Console.WriteLine(String.Join("\t",w));

           
            
            
            Console.WriteLine("wersja 2: Test klasy Zawodnicy repository)");


            ZawodnicyRepository z= new ZawodnicyRepository();
            var zaw= z.PobierzZawodnikow();

            foreach (var zw in zaw)
                Console.WriteLine(zw.PrzedstawSie2());



            Console.ReadKey();
        }
    }
}
