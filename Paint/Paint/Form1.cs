using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool start = false, mis = false;
        Color boja = Color.Red;
        void Crtaj(object boja)
        {
            Pen olovka = new Pen((Color)boja);
            Graphics g = pozadina.CreateGraphics();
            Point pocetak = new Point(0, 0);
            Invoke(new Action(() => pocetak = pozadina.PointToClient(Cursor.Position)));
            Point kraj = pocetak;
            do
            {
                kraj = pocetak;
                Invoke(new Action(() => pocetak = pozadina.PointToClient(Cursor.Position)));
                g.DrawLine(olovka, pocetak, kraj);
            }
            while (mis);
        }
        
        private void pozadina_MouseDown(object sender, MouseEventArgs e)
        {
            mis = true;
            ThreadPool.QueueUserWorkItem(Crtaj,boja);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B) boja = Color.Blue;
            if (e.KeyCode == Keys.R) boja = Color.Red;
            if (e.KeyCode == Keys.G) boja = Color.Green;
            if (e.KeyCode == Keys.Y) boja = Color.Yellow;
            if (e.KeyCode == Keys.C) boja = Color.Cyan;
            if (e.KeyCode == Keys.M) boja = Color.Magenta;
        }

        private void pozadina_MouseUp(object sender, MouseEventArgs e)
        {
            mis = false;
        }
    }
}
