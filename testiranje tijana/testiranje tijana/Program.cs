using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testiranje_tijana
{
    class Player
    {
        public string name;
        public int food;
        public int water;
        public int hp;
        public Player(string n, int f, int w, int h)
        {
            name = n;
            food = f;
            water = w;
            hp = h;
        }
        public string Status()
        {
            return "HP: " + hp + " Hrana: " + food + " Voda: " + water;
        }

    }
    class Inv
    {
        public int space;
        public string[] items;
        public Inv()
        {
            space = 15;
            items = new string[15];
        }
        public string List()
        {
            string list = "Inv: ";
            int p = 0;
            for (int i = 0; i < 15; i++)
                if (items[i] != null) list += items[i] + " ";
            if (p == 0) list += "Prazno.";
            return list;
        }
    };
    class Program
    {
        static Inv inventory = new Inv();
        static Player player;
        static string map;
        static int m = 40, n = 10;
        static void Main(string[] args)
        {
            Ucitaj();
            Otkucaj();
            Console.ReadLine();
        }
        static void Ucitaj()
        {
            player = new Player("Tijana", 50, 35, 15);
        }
        static void Otkucaj()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == 0 || i == 0 || j == m - 1 || i == n - 1) map += "#";
                    else map += "+";
                }
                map += @"
";
            }
            Console.WriteLine(map);
            Console.WriteLine(player.Status());
            Console.WriteLine(inventory.List());
        }
    }
}
