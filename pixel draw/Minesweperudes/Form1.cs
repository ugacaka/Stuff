using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweperudes
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            InitializeComponent();

        }
        
        public int row_size = 10;
        public int column_size = 10;
        public static int width = 30;
        public int height= 30;
        private Form2 frm;
        public void PictureboxMaker()
        {
            PictureBox[][] Picture = new PictureBox[row_size][];
            for (int i = 0; i < row_size; i++)
            {
                Picture[i] = new PictureBox[column_size];
            }
            for (int i = 0; i < column_size; i++)
            {
                for (int j = 0; j < row_size; j++)
                {
                    Picture[j][i] = new PictureBox();
                    Picture[j][i].Size = new Size(width, height);
                    Picture[j][i].Location = new Point(1 + i * (width + 1 ), 1 + j * (height + 1 ));
                    Picture[j][i].BackColor = Color.DarkGray;
                    Picture[j][i].Visible = true;
                    Picture[j][i].Enabled = true;
                    Controls.Add(Picture[j][i]);
                    Picture[j][i].MouseDown += new MouseEventHandler(Picture_MouseDown);
                }
            }
            Size = new Size(17 + width * column_size + column_size, 40 + height * row_size + row_size);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            frm = new Form2(this);
            frm.Show();
            
        }
        private void Picture_MouseDown(object sender, EventArgs e)
        {
            PictureBox PictureBox = sender as PictureBox;
            if (PictureBox.BackColor == Color.DarkGray)
                PictureBox.BackColor = Color.Blue;
            else PictureBox.BackColor = Color.DarkGray;
        }
    }
    public partial class Form2 : Form
    {

        public Form1 parent;
        public Form2(Form1 p)
        {
            parent = p;
            InitializeComponent();

        }
        public int Sirina, Duzina, Redovi, Kolone;
        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Sirina = Convert.ToInt32(tbSirina.Text);
                Duzina = Convert.ToInt32(tbDuzina.Text);
                Redovi = Convert.ToInt32(tbRedovi.Text);
                Kolone = Convert.ToInt32(tbKolone.Text);
                parent.row_size = Kolone;
                parent.column_size = Redovi;
                parent.width = Sirina;
                parent.height = Duzina;
                parent.PictureboxMaker();
                Close();
            }
            catch (NullReferenceException) {  MessageBox.Show("fdss", "sdfasdf"); }
         }
    }
}
