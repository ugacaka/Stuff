using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Kinda_v2._0
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
            g = pozadina.CreateGraphics();
            pozadina.BackColor = DefaultBackColor;
            for (int x = 0; x < velicinaPoljaX - 1; x++)
                for (int y = 0; y < velicinaPoljaY - 1; y++)
                    polje[x, y] = new Point(x * velicinaB, y * velicinaB);
        }
        static int velicinaB = 10;
        static int velicinaPoljaX = Convert.ToInt32(800 / velicinaB);
        static int velicinaPoljaY = Convert.ToInt32(450 / velicinaB);
        Graphics g;
        Rectangle[] zmija = new Rectangle[(velicinaPoljaX - 1) * (velicinaPoljaY - 1)];
        Rectangle hrana = new Rectangle();
        Pen zelena = new Pen(Color.Green);
        Pen crvena = new Pen(Color.Red);
        Pen def = new Pen(DefaultBackColor);
        Size velicinaBloka = new Size(velicinaB, velicinaB);
        int trenutnotelo = 1;
        Point[,] polje = new Point[velicinaPoljaX - 1, velicinaPoljaY - 1];
        Random r = new Random();
        bool gore = false, levo = false, desno = false, dole = false, prviput = false;
        void NacrtajKvadrat(Pen pen, Rectangle rectangle)
        {
            SolidBrush cetka = new SolidBrush(pen.Color);
            g.FillRectangle(cetka, rectangle);
            cetka.Dispose();
            
        }
        void ObrisiKvadrat(Rectangle rectangle)
        {
            SolidBrush cetka = new SolidBrush(DefaultBackColor);
            g.FillRectangle(cetka, rectangle);
            cetka.Dispose();
        }
        void Hrana()
        {
            hrana.Size = velicinaBloka;
            hrana.Location = polje[r.Next(0, velicinaPoljaX - 1), r.Next(0, velicinaPoljaY - 1)];
            NacrtajKvadrat(crvena, hrana);
        }

        void Snake()
        {
            zmija[trenutnotelo].Size = velicinaBloka;
            zmija[trenutnotelo].Location = zmija[trenutnotelo - 1].Location;
            NacrtajKvadrat(zelena, zmija[trenutnotelo]);
        }
        int x = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (x == 1)
            {
                zmija[0].Size = velicinaBloka;
                zmija[0].Location = new Point(2 * velicinaB, 2 * velicinaB);
                NacrtajKvadrat(zelena, zmija[0]);
                Hrana();
                x = 0;
            }
            NacrtajKvadrat(crvena, hrana);
            if (prviput)
            {
                for (int i = trenutnotelo - 1; i >= 1; i--)
                {
                    if (i == trenutnotelo - 1) ObrisiKvadrat(zmija[i]);
                    zmija[i].Location = zmija[i - 1].Location;
                    NacrtajKvadrat(zelena, zmija[i]);
                }
            }
            if (levo)
            {
                if (!prviput) ObrisiKvadrat(zmija[0]);
                zmija[0].X -= velicinaB;
                NacrtajKvadrat(zelena, zmija[0]);

            }
            if (desno)
            {
                if (!prviput) ObrisiKvadrat(zmija[0]);
                zmija[0].X += velicinaB;
                NacrtajKvadrat(zelena, zmija[0]);
            }
            if (gore)
            {
                if (!prviput) ObrisiKvadrat(zmija[0]);
                zmija[0].Y -= velicinaB;
                NacrtajKvadrat(zelena, zmija[0]);
            }
            if (dole)
            {
                if (!prviput) ObrisiKvadrat(zmija[0]);
                zmija[0].Y += velicinaB;
                NacrtajKvadrat(zelena, zmija[0]);
            }
            if (zmija[0].IntersectsWith(hrana))
            {
                Snake();
                Hrana();
                prviput = true;
                trenutnotelo++;
            }
        }

        private void pozadina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) if (!desno)
                {
                    levo = true;
                    desno = false;
                    gore = false;
                    dole = false;
                }
            if (e.KeyCode == Keys.Right) if (!levo)
                {
                    desno = true;
                    levo = false;
                    gore = false;
                    dole = false;
                }
            if (e.KeyCode == Keys.Up) if (!dole)
                {
                    gore = true;
                    levo = false;
                    desno = false;
                    dole = false;
                }
            if (e.KeyCode == Keys.Down) if (!gore)
                {
                    dole = true;
                    levo = false;
                    desno = false;
                    gore = false;
                }
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }
    }
}
