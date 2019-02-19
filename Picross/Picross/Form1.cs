using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
namespace Picross
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateField();
        }
        static int duzina = 25, sirina = 25;
        Button ucitaj;
        TextBox slika;
        PictureBox[,] polje = new PictureBox[sirina, duzina];
        Label[] linijaD = new Label[25];
        Label[] linijaS = new Label[25];
        bool[,] crno = new bool[sirina, duzina];
        Color bela = Color.White, crna = Color.Black, siva = Color.LightGray;
        bool start = false;
        string imeslike = "";
        void CreateField()
        {
            for (int i = 0; i < sirina; i++)
                for (int j = 0; j < duzina; j++)
                {
                    polje[i, j] = new PictureBox { Location = new Point(21 * i + 10, 21 * j + 10), Size = new Size(20, 20), BackColor = bela };
                    polje[i, j].MouseDown += new MouseEventHandler(Proveri);
                    Controls.Add(polje[i, j]);
                }
            ucitaj = new Button { Text = "Ucitaj", Location = new Point(polje[sirina - 1, duzina - 1].Location.X + 25, polje[sirina - 1, duzina - 1].Location.Y + 50), BackColor = bela };
            ucitaj.Click += new EventHandler(Ucitaj);
            Controls.Add(ucitaj);
            slika = new TextBox { Size = new Size(ucitaj.Size.Width, ucitaj.Size.Height), Location = new Point(polje[sirina - 1, duzina - 1].Location.X + 25, polje[sirina - 1, duzina - 1].Location.Y + 25) };
            Controls.Add(slika);
        }
        void Proveri(object sender, MouseEventArgs e)
        {
            if (start)
            {
                PictureBox field = (PictureBox)sender;
                int index_x = (field.Location.X - 10) / 21, index_y = (field.Location.Y - 10) / 21;
                if (e.Button == MouseButtons.Left)
                {
                    if (field.BackColor == bela)
                        if (crno[index_x, index_y]) field.BackColor = crna;
                        else { field.BackColor = siva; field.BackgroundImage = Properties.Resources.crvenix; }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (field.BackColor == bela)
                        if (!crno[index_x, index_y]) { field.BackColor = siva; field.BackgroundImage = Properties.Resources.crnix; }
                        else { field.BackColor = crna; field.BackgroundImage = Properties.Resources.crvenix; }
                } 
            }
        }
        void Ucitaj(object sender,EventArgs e)
        {
            for (int i = 0; i < sirina; i++) for (int j = 0; j < duzina; j++) { polje[i, j].BackColor = bela; polje[i,j].BackgroundImage = null; if (start) { linijaD[j].Text = ""; linijaS[j].Text = ""; } }
            imeslike = slika.Text.ToString();
            Name = imeslike;
            if (File.Exists("C:/PicrossSaves/" + imeslike + ".picross"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open("C:/PicrossSaves/" + imeslike + ".picross", FileMode.Open);
                crno = (bool[,])bf.Deserialize(file);
                file.Close();
            }
            int brojkvadrata = 0;
            string linijakvadrata="";

            for (int j = 0; j < duzina; j++)
            {
                brojkvadrata = 0;
                linijakvadrata = "";
                for (int i = 0; i < sirina; i++)
                {
                    if (crno[i, j]) brojkvadrata++;
                    else
                    {
                        if (brojkvadrata != 0) linijakvadrata += brojkvadrata + " ";
                        brojkvadrata = 0;
                    }
                    if(i==24&&brojkvadrata>0) linijakvadrata += brojkvadrata;
                }
                linijaD[j] = new Label { Location = new Point(polje[sirina - 1, j].Location.X + 25, polje[sirina - 1, j].Location.Y + 2), Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0), Text = linijakvadrata, AutoSize = true };
                Controls.Add(linijaD[j]);
            }
            for (int i = 0; i < sirina; i++)
            {
                brojkvadrata = 0;
                linijakvadrata = "";
                for (int j = 0; j < duzina; j++)
                {
                    if (crno[i, j]) brojkvadrata++;
                    else
                    {
                        if (brojkvadrata != 0) linijakvadrata += brojkvadrata + " ";
                        brojkvadrata = 0;
                    }
                    if (j == 24 && brojkvadrata > 0) linijakvadrata += brojkvadrata;
                }
                linijaS[i] = new Label { Location = new Point(polje[i, duzina - 1].Location.X + 2, polje[i, duzina - 1].Location.Y + 25), Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0), Text = linijakvadrata, MaximumSize = new Size(19, 190), AutoSize = true };
                Controls.Add(linijaS[i]);
            }
            slika.Text = "";
            imeslike = "";
            start = true;
        }
    }
}
