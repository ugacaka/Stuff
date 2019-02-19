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

namespace Picross_Maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateField();
        }
        static int duzina = 25, sirina = 25;
        Button sacuvaj, obrisi, obrisisve;
        TextBox slika;
        PictureBox[,] polje = new PictureBox[sirina, duzina];
        bool[,] crno = new bool[duzina, sirina];
        Color bela = Color.White, crna = Color.Black;
        string imeslike = "";
        void CreateField()
        {
            for (int i = 0; i < duzina; i++)
                for (int j = 0; j < sirina; j++)
                {
                    polje[i, j] = new PictureBox { Location = new Point(21 * i + 10, 21 * j + 10), Size = new Size(20, 20), BackColor = bela };
                    polje[i, j].MouseDown += new MouseEventHandler(Oboji);
                    Controls.Add(polje[i, j]);
                }
            sacuvaj = new Button { Text = "Sacuvaj", Location = new Point(polje[duzina - 1, sirina - 1].Location.X + 38, polje[0, 0].Location.Y), BackColor = bela };
            sacuvaj.Click += new EventHandler(Sacuvaj);
            Controls.Add(sacuvaj);
            obrisi = new Button { Text = "Obrisi", Location = new Point(polje[duzina - 1, sirina - 1].Location.X + 38, polje[0, 0].Location.Y + 75), BackColor = bela };
            obrisi.Click += new EventHandler(Obrisi);
            Controls.Add(obrisi);
            obrisisve = new Button { Text = "Obrisi sve", Location = new Point(polje[duzina - 1, sirina - 1].Location.X + 38, polje[0, 0].Location.Y + 200), BackColor = bela };
            obrisisve.Click += new EventHandler(Obrisisve);
            Controls.Add(obrisisve);
            slika = new TextBox { Size = new Size(obrisi.Size.Width, obrisi.Size.Height), Location = new Point(polje[duzina - 1, sirina - 1].Location.X + 38, polje[0, 0].Location.Y + 50) };
            Controls.Add(slika);
        }
        void Oboji(object sender, MouseEventArgs e)
        {
            PictureBox field = (PictureBox)sender;
            if (field.BackColor == bela) field.BackColor = crna;
            else field.BackColor = bela;
        }
        void Sacuvaj(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:/PicrossSaves/");
            for (int i = 0; i < duzina; i++)
                for (int j = 0; j < sirina; j++)
                    if (polje[i, j].BackColor == crna) crno[i, j] = true;
                    else crno[i, j] = false;
            imeslike = slika.Text.ToString();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create("C:/PicrossSaves/" + imeslike + ".picross");
            bf.Serialize(file, crno);
            file.Close();
            imeslike = "";
        }
        void Obrisi(object sender, EventArgs e)
        {
            imeslike = slika.Text.ToString();
            if (File.Exists("C:/PicrossSaves/" + imeslike + ".picross")) File.Delete("C:/PicrossSaves/" + imeslike + ".picross");
            Obrisisve(sender, e);
        }
        void Obrisisve(object sender, EventArgs e)
        {
            imeslike = "";
            for (int i = 0; i < duzina; i++)
                for (int j = 0; j < sirina; j++)
                    polje[i, j].BackColor = bela;
        }
    }
}
