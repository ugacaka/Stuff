using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Minefield
{
    public class Minefield : Form
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public Minefield()
        {
            SuspendLayout();
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Minefield";
            KeyDown += new KeyEventHandler(minefield_KeyDown);
            ResumeLayout(false);
            InitializeFieldSize();
            CreateField();
        }
        static int x = 10 + 2, y = 10 + 2, pMine = 10, mine = Convert.ToInt32((x - 2) * (y - 2) * pMine / 100), _x, _y;
        bool[,] isMine = new bool[x, y];
        int velicina = 20, kraj = 0, trbrojmina,rek=0;
        bool[,] wasChecked = new bool[x, y];
        int[] checkX = { -1, 0, 1, -1, 1, -1, 0, 1 };
        int[] checkY = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[,] brojOm = new int[x, y];
        bool pocetak = true,gameover=false,klik=true;
        PictureBox[,] field = new PictureBox[x, y];
        Random r = new Random();
        void InitializeFieldSize()
        {
            ClientSize = new Size((velicina + 1) * (x - 1), (velicina + 1) * (y - 1));
        }
        void minefield_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R) Restart();
            if (e.KeyCode == Keys.N) New();
        }
        void CreateField()
        {
            trbrojmina = mine;
            Text = "Minefield: " + trbrojmina + "    | r - Restart | n - New |";
            for (int i = 1; i < x-1; i++)
                for (int j = 1; j < y-1; j++)
                {
                    field[i, j] = new PictureBox();
                    field[i, j].Location = new Point((velicina + 1) * i - 10, (velicina + 1) * j - 10);
                    field[i, j].Size = new Size(velicina, velicina);
                    field[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    field[i, j].BackColor = Color.Gray;
                    field[i, j].MouseDown += new MouseEventHandler(GenerateMines);
                    field[i, j].MouseDown += new MouseEventHandler(CheckField);
                    Controls.Add(field[i, j]);
                    isMine[i, j] = false;
                    wasChecked[i, j] = false;
                    brojOm[i, j] = 0;
                }
            for (int i = 0; i < y; i++)
            {
                wasChecked[0, i] = true;
                wasChecked[x - 1, i] = true;
                brojOm[0, i] = 11;
                brojOm[x - 1, i] = 11;
            }
            for (int i = 0; i < x; i++)
            {
                wasChecked[i, 0] = true;
                wasChecked[i, y - 1] = true;
                brojOm[i, 0] = 11;
                brojOm[i, y - 1] = 11;
            }
        }
        void GenerateMines(object sender, MouseEventArgs e)
        {
            if (pocetak)
            {
                pocetak = false;
                PictureBox Field = (PictureBox)sender;
                int index_x = ((Field.Location.X + 10) / (velicina + 1));
                int index_y = ((Field.Location.Y + 10) / (velicina + 1));
                for (int i = 1; i <= mine; i++)
                {
                    _x = r.Next(1, x - 1);
                    _y = r.Next(1, y - 1);
                    if (!isMine[_x, _y] && (_x != index_x || _y != index_y))
                    {
                        isMine[_x, _y] = true;
                        brojOm[_x, _y] = 9;
                    }
                    else i--;
                }
            }
        }
        void CheckField(object sender, MouseEventArgs e)
        {
            PictureBox Field = (PictureBox)sender;
            int index_x = ((Field.Location.X + 10) / (velicina + 1));
            int index_y = ((Field.Location.Y + 10) / (velicina + 1));
            if (e.Button == MouseButtons.Left)
            {
                if (brojOm[index_x, index_y] != 10)
                {
                    CheckOtherFields(index_x, index_y);
                    gameover = false;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (field[index_x, index_y].BackgroundImage == null && field[index_x, index_y].BackColor == Color.Gray)
                {
                    field[index_x, index_y].BackgroundImage = Properties.Resources.flag;
                    brojOm[index_x, index_y] = 10;
                    trbrojmina--;
                }
                else if (field[index_x, index_y].BackColor == Color.Gray)
                {
                    field[index_x, index_y].BackgroundImage = null;
                    brojOm[index_x, index_y] = 0;
                    trbrojmina++;
                }
                Text = "Rek:" + rek + "Minefield: " + trbrojmina + "    | r - Restart | n - New |";
            }
        }
        void CheckOtherFields(int index_x, int index_y)
        {
            if (!gameover)
            {
                int mines = 0;
                if (!wasChecked[index_x, index_y] && brojOm[index_x, index_y] != 10)
                {
                    rek++;
                    wasChecked[index_x, index_y] = true;
                    if (!isMine[index_x, index_y])
                    {
                        if (field[index_x, index_y].BackColor == Color.Gray)
                        {
                            field[index_x, index_y].BackColor = Color.White;
                            kraj++;
                        }
                        for (int i = 0; i < 8; i++) if (isMine[index_x + checkX[i], index_y + checkY[i]]) mines++;
                        switch (mines)
                        {
                            case 0:
                                for (int i = 0; i < 8; i++) CheckOtherFields(index_x + checkX[i], index_y + checkY[i]);
                                brojOm[index_x, index_y] = 0;
                                break;
                            case 1:
                                field[index_x, index_y].BackgroundImage = Properties.Resources.broj1;
                                brojOm[index_x, index_y] = 1;
                                break;
                            case 2:
                                field[index_x, index_y].BackgroundImage = Properties.Resources.broj2;
                                brojOm[index_x, index_y] = 2;
                                break;
                            case 3:
                                field[index_x, index_y].BackgroundImage = Properties.Resources.broj3;
                                brojOm[index_x, index_y] = 3;
                                break;
                            case 4:
                                field[index_x, index_y].BackgroundImage = Properties.Resources.broj4;
                                brojOm[index_x, index_y] = 4;
                                break;
                            case 5:
                                field[index_x, index_y].BackgroundImage = Properties.Resources.broj5;
                                brojOm[index_x, index_y] = 5;
                                break;
                            case 6:
                                field[index_x, index_y].BackgroundImage = Properties.Resources.broj6;
                                brojOm[index_x, index_y] = 6;
                                break;
                            case 7:
                                field[index_x, index_y].BackgroundImage = Properties.Resources.broj7;
                                brojOm[index_x, index_y] = 7;
                                break;
                            case 8:
                                field[index_x, index_y].BackgroundImage = Properties.Resources.broj8;
                                brojOm[index_x, index_y] = 8;
                                break;
                        }
                        if (kraj == (x - 2) * (y - 2) - mine) Win();
                    }
                    else
                    {
                        gameover = true;
                        GameOver(index_x, index_y);
                    }
                }
                else if (brojOm[index_x, index_y] > 0 && brojOm[index_x, index_y] < 10)
                {
                    int brojzastava = 0;
                    for (int i = 0; i < 8; i++) if (brojOm[index_x + checkX[i], index_y + checkY[i]] == 10) brojzastava++;
                    if (brojOm[index_x, index_y] <= brojzastava && klik)
                    {
                        klik = false;
                        for (int i = 0; i < 8; i++)
                        {

                            if (gameover) break;
                            if ((brojOm[index_x + checkX[i], index_y + checkY[i]] > 0 && brojOm[index_x + checkX[i], index_y + checkY[i]] < 9) || brojOm[index_x + checkX[i], index_y + checkY[i]] == 10) continue;
                            CheckOtherFields(index_x + checkX[i], index_y + checkY[i]);

                        }
                        klik = true;
                    }
                }
            }
        }
        void GameOver(int index_x, int index_y)
        {
            kraj = 0;
            for (int i = 1; i < x - 1; i++)
                for (int j = 1; j < y - 1; j++)
                    if (isMine[i, j])
                    {
                        field[i, j].BackgroundImage = Properties.Resources.bomb2;
                        field[i, j].BackColor = Color.White;
                    }
            field[index_x, index_y].BackgroundImage = Properties.Resources.bomb1;
            MessageBox.Show("Izgubio si!", "Poruka");
            Restart();
        }
        void Restart()
        {
            trbrojmina = mine;
            Text = "Minefield: " + trbrojmina + "    | r - Restart | n - New |";
            kraj = 0;
            for (int i = 1; i < x-1; i++)
                for (int j = 1; j < y-1; j++)
                {
                    field[i, j].BackColor = Color.Gray;
                    field[i, j].BackgroundImage = null;
                    isMine[i, j] = false;
                    wasChecked[i, j] = false;
                    brojOm[i, j] = 0;
                }
            pocetak = true;
        }
        void New()
        {
            gameover = false;
            kraj = 0;
            for (int i = 1; i < x-1; i++) for (int j = 1; j < y-1; j++) field[i, j].Dispose();
            Opcije opcije = new Opcije();
            if (opcije.ShowDialog() == DialogResult.OK)
            {
                x = opcije.x + 2;
                y = opcije.y + 2;
                pMine = opcije.pMine;
                mine = Convert.ToInt32((x - 2) * (y - 2) * pMine / 100);
            }
            opcije.Dispose();
            InitializeFieldSize();
            field = new PictureBox[x, y];
            wasChecked = new bool[x, y];
            isMine = new bool[x, y];
            brojOm = new int[x, y];
            CreateField();
            pocetak = true;
            gameover = false;
        }
        void Win()
        {
            kraj = 0;
            MessageBox.Show("Pobeda!", "Poruka");
            Restart();
        }
    }
    public class Opcije : Form
    {
        public Opcije()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbSirina = new TextBox();
            tbDuzina = new TextBox();
            tbMina = new TextBox();
            btOk = new Button();
            SuspendLayout();
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(33, 13);
            label1.Text = "Sirina";
            label2.AutoSize = true;
            label2.Location = new Point(12, 39);
            label2.Name = "label2";
            label2.Size = new Size(40, 13);
            label2.Text = "Duzina";
            label3.AutoSize = true;
            label3.Location = new Point(12, 69);
            label3.Name = "label3";
            label3.Size = new Size(76, 13);
            label3.Text = "Procenat Mina";
            tbSirina.Location = new Point(94, 6);
            tbSirina.Name = "tbSirina";
            tbSirina.Size = new Size(100, 20);
            tbSirina.TabIndex = 0;
            tbDuzina.Location = new Point(94, 36);
            tbDuzina.Name = "tbDuzina";
            tbDuzina.Size = new Size(100, 20);
            tbDuzina.TabIndex = 1;
            tbMina.Location = new Point(94, 66);
            tbMina.Name = "tbMina";
            tbMina.Size = new Size(100, 20);
            tbMina.TabIndex = 2;
            btOk.DialogResult = DialogResult.OK;
            btOk.Location = new Point(57, 108);
            btOk.Name = "btOk";
            btOk.Size = new Size(75, 23);
            btOk.Text = "OK";
            btOk.UseVisualStyleBackColor = true;
            btOk.Click += new EventHandler(btOk_Click);
            btOk.TabIndex = 3;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(215, 150);
            Controls.Add(btOk);
            Controls.Add(tbMina);
            Controls.Add(tbDuzina);
            Controls.Add(tbSirina);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Opcije";
            Text = "Opcije";
            ResumeLayout(false);
            PerformLayout();
        }
        public int x, y, pMine;
        private IContainer components = null;
        private Label label1,label2,label3;
        private TextBox tbSirina, tbDuzina, tbMina;
        private Button btOk;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void btOk_Click(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToInt32(tbSirina.Text);
                y = Convert.ToInt32(tbDuzina.Text);
                pMine = Convert.ToInt32(tbMina.Text);
            }
            catch
            {
                x = 10;
                y = 10;
                pMine = 10;
            }
        }
    }
}
