using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteHall
{
    class Program
    {
        static Random r = new Random();
        static double procenatpobedaprve, procenatpobedadruge;
        static int prva,brojpobedaPrve;
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int x=1;
            do
            { 
                MonteHall();
                procenatpobedaprve = brojpobedaPrve * 100 / x ;
                procenatpobedadruge = 100 - procenatpobedaprve;
                x++;
                Console.WriteLine("Ostavis:"+procenatpobedaprve+"%, "+ "Promenis:" + procenatpobedadruge + "%");
            }
            while (x<=n);
            Console.ReadLine();
        }
        static void MonteHall()
        {
            prva = r.Next(0,3);
            if (prva == 0) brojpobedaPrve++;
        }
    }
}
