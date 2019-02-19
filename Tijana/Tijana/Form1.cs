using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tijana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pozadina.Paint += new PaintEventHandler(Crtaj);
        }
        Inv inventory = new Inv();
        Player player;
        string map;
        int m = 40, n = 10;
        private void Form1_Load(object sender, EventArgs e)
        {
            Ucitaj();
            Otkucaj();
        }
        
        void Ucitaj()
        {
            player = new Player("Tijana", 50, 35, 15);
        }
        void Otkucaj()
        {
            for (int i = 0; i < n; i++)
             {
                 for (int j = 0; j < m; j++)
                 {
                     if (j == 0 || i == 0 || j == m - 1 || i == n - 1) map+="#";
                     else map+="+";
                 }
                 map+=@"
";
             }
            pozadina.Refresh();
            lblStatus.Text = player.Status();
            lblInv.Text = inventory.List();
        }
        public void Crtaj(object sender, PaintEventArgs e)
        {
            Graphics formGraphics = pozadina.CreateGraphics();
            string drawString = map;
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x = 0;
            float y = 0;
            StringFormat drawFormat = new StringFormat();
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }
    }
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
            string list= "Inv: ";
            int p = 0;
            for (int i = 0; i < 15; i++)
                if (items[i] != null) list += items[i] + " ";
            if (p == 0) list+="Prazno.";
            return list;
        }
    };

}
