using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_Kinda
{
    public partial class pozadina : Form
    {
        public pozadina()
        {
            InitializeComponent();
            for (int x = 0; x < velicinaPoljaX-1; x++)
                for (int y = 0; y < velicinaPoljaY-1; y++)
                    polje[x, y] = new Point(x * velicinaB, y * velicinaB);
            snake[0] = new PictureBox();
            snake[0].Location = new Point(22*velicinaB,15*velicinaB);
            snake[0].Size = velicinaBloka;
            snake[0].BackColor = Color.Green;
            Controls.Add(snake[0]);
            Hrana();
        }
        static int velicinaB = 10;
        static int velicinaPoljaX = Convert.ToInt32(800 / velicinaB);
        static int velicinaPoljaY = Convert.ToInt32(450 / velicinaB);
        Size velicinaBloka = new Size(velicinaB, velicinaB);
        PictureBox hrana = new PictureBox();
        PictureBox[] snake = new PictureBox[(velicinaPoljaX - 1)*(velicinaPoljaY - 1)];
        int trenutnotelo = 1;
        Point[,] polje = new Point[velicinaPoljaX - 1, velicinaPoljaY - 1];
        Random r = new Random();
        bool gore = false, levo = false, desno = false, dole = false, prviput = false;
        void Hrana()
        {
            hrana = new PictureBox();
            hrana.Location = polje[r.Next(0, velicinaPoljaX-1), r.Next(0, velicinaPoljaY-1)];
            hrana.Size = velicinaBloka;
            hrana.BackColor = Color.Red;
            Controls.Add(hrana);
        }

        void Snake()
        {
            snake[trenutnotelo] = new PictureBox();
            snake[trenutnotelo].Location = snake[trenutnotelo - 1].Location;
            snake[trenutnotelo].Size = velicinaBloka;
            snake[trenutnotelo].BackColor = Color.Green;
            Controls.Add(snake[trenutnotelo]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (prviput)
            {
                for (int i = trenutnotelo - 1; i >= 1; i--)
                    snake[i].Location = snake[i - 1].Location;
            }
            if (levo) snake[0].Left -= velicinaB;
            if (desno) snake[0].Left += velicinaB;
            if (gore) snake[0].Top -= velicinaB;
            if (dole) snake[0].Top += velicinaB;
            if (snake[0].Bounds == hrana.Bounds)
            {
                hrana.Dispose();
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
