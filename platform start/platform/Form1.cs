using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace platform
{
    public partial class platform : Form
    {
        public platform()
        {
            InitializeComponent();
        }
        bool levo,desno,unebu=false, uskoku = false;
        bool[] pre = new bool[prepreka];
        int sila, visinaskoka = 14;
        static int prepreka = 5;
        PictureBox ja = new PictureBox();
        PictureBox[] p = new PictureBox[prepreka];
        private void platform_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) levo = false;
            
            if (e.KeyCode == Keys.Right) desno = false;
            
        }

        PictureBox Pb(PictureBox s, int pocX, int pocY, int kvaX, int kvaY)
        {
            Point pocetak = new Point(pocX, pocY);
            Size kvadrat = new Size(kvaX, kvaY);
            s.Size = kvadrat;
            s.Location = pocetak;
            s.BackColor = Color.DarkGray;
            s.Visible = true;
            s.Enabled = true;
            this.Controls.Add(s);
            return s;
        }

        public void Platform_Load(object sender, EventArgs e)
        {

            for(int i = 0; i < prepreka; i++)
            {
                p[i] = new PictureBox();
                Pb(p[i], 80+i*150, 295, 40, 10);
                p[i].BackColor = Color.Red;
            }
            
            Pb(ja,0,370,15,30);

            
            pozadina.SendToBack();
        }

        private void platform_KeyDown(object sender, KeyEventArgs e)
        {
            if (uskoku != true)
               if (e.KeyCode == Keys.Space)
                {
                    uskoku = true;
                    sila = visinaskoka;
                }
            if (e.KeyCode == Keys.Left) levo = true;
            if (e.KeyCode == Keys.Right) desno = true;
        }

        public void Vreme_Tick(object sender, EventArgs e)
        {
            
            if (levo) ja.Left -= 5;
            if (desno) ja.Left += 5;
            if (uskoku == true)
            {
                if (ja.Top - sila > pozadina.Height - ja.Height)
                    ja.Top = pozadina.Height - ja.Height;
                else
                {
                    ja.Top -= sila;
                    sila -= 1;
                }
            }
            else if (ja.Top < pozadina.Height - ja.Height&&unebu==true) ja.Top += 10;

            for(int i = 0; i < prepreka; i++)
            {
                if (ja.Bottom == p[i].Top && ja.Left + 15 >= p[i].Left && ja.Right - 15 <= p[i].Right) { uskoku = false; unebu = false; pre[i] = true; }
                else pre[i] = false;
                if (pre[1] == false && pre[0] == false && pre[2] == false && pre[3] == false && pre[4] == false)  unebu = true; 
                }
            
            if (ja.Top == pozadina.Height - ja.Height)
            {
                uskoku = false;
                unebu = false;
            }

            
        }
    }
}
