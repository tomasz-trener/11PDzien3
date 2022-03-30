using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09KonwersjaARzutowanie
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int a = 1;

            string b = Convert.ToString(a);


            //  Console.WriteLine(a);
            // Console.WriteLine(b); 

            object c = a; // niejawne rzutowanie 

            // konwersja to jest przerabianie z a do b 
            // rzutowanie to jest traktowanie a jako b lub b jako a 

            int d1 = (int)c; // teraz muszę rzutować jawnie 

            int d2 = Convert.ToInt32(c);

            int e = Convert.ToInt32(1);


            object a2 = "2"; // rzutowanie niejawne 
            int c2 = Convert.ToInt32((string)a2); // rzutowanie jawne 


        }
    }
}
