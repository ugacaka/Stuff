using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random r = new Random();
        Panel pozadina = new Panel();
        PictureBox[,] polje = new PictureBox[20,10];
        int x,y,shape,rotacija;
        bool pada = false;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                
                switch (shape)
                {
                    case 1://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 2, y + 1].BackColor = Color.Aqua;
                                if (y > 0 && polje[x, y - 1].BackColor == Color.Aqua && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua) y--;
                                polje[x, y].BackColor = Color.Red;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 2, y].BackColor = Color.Red;
                                polje[x + 2, y + 1].BackColor = Color.Red;
                                break;
                            case 2:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x + 2, y - 1].BackColor = Color.Aqua;
                                if (y > 1 && polje[x + 1, y - 2].BackColor == Color.Aqua && polje[x + 2, y - 2].BackColor == Color.Aqua) y--;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 1, y + 1].BackColor = Color.Red;
                                polje[x + 1, y - 1].BackColor = Color.Red;
                                polje[x + 2, y - 1].BackColor = Color.Red;
                                break;
                            case 3:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                if (y > 1 && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua && polje[x, y - 2].BackColor == Color.Aqua) y--;
                                polje[x, y].BackColor = Color.Red;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 2, y].BackColor = Color.Red;
                                polje[x, y - 1].BackColor = Color.Red;
                                break;
                            case 4:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                if (y > 1 && polje[x, y].BackColor == Color.Aqua && polje[x + 1, y - 2].BackColor == Color.Aqua) y--;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 1, y + 1].BackColor = Color.Red;
                                polje[x + 1, y - 1].BackColor = Color.Red;
                                polje[x, y + 1].BackColor = Color.Red;
                                break;
                        }
                        break;
                    case 2://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (y > 1 && polje[x, y - 1].BackColor == Color.Aqua && polje[x + 1, y - 2].BackColor == Color.Aqua) y--;
                                polje[x, y].BackColor = Color.Blue;
                                polje[x, y + 1].BackColor = Color.Blue;
                                polje[x + 1, y].BackColor = Color.Blue;
                                polje[x + 1, y - 1].BackColor = Color.Blue;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x - 1, y - 1].BackColor = Color.Aqua;
                                if (y > 1 && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x, y - 2].BackColor == Color.Aqua && polje[x - 1, y - 2].BackColor == Color.Aqua) y--;
                                polje[x, y].BackColor = Color.Blue;
                                polje[x + 1, y].BackColor = Color.Blue;
                                polje[x, y - 1].BackColor = Color.Blue;
                                polje[x - 1, y - 1].BackColor = Color.Blue;
                                break;
                        }
                        break;
                    case 3://done
                        polje[x, y].BackColor = Color.Aqua;
                        polje[x, y + 1].BackColor = Color.Aqua;
                        polje[x + 1, y].BackColor = Color.Aqua;
                        polje[x + 1, y + 1].BackColor = Color.Aqua;
                        if (y > 0 && polje[x, y - 1].BackColor == Color.Aqua && polje[x + 1, y - 1].BackColor == Color.Aqua) y--;
                        polje[x, y].BackColor = Color.Yellow;
                        polje[x, y + 1].BackColor = Color.Yellow;
                        polje[x + 1, y].BackColor = Color.Yellow;
                        polje[x + 1, y + 1].BackColor = Color.Yellow;
                        break;
                    case 4://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 3, y].BackColor = Color.Aqua;
                                if (y > 0 && polje[x, y - 1].BackColor == Color.Aqua && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua && polje[x + 3, y - 1].BackColor == Color.Aqua) y--;
                                polje[x, y].BackColor = Color.Green;
                                polje[x + 1, y].BackColor = Color.Green;
                                polje[x + 2, y].BackColor = Color.Green;
                                polje[x + 3, y].BackColor = Color.Green;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x, y - 2].BackColor = Color.Aqua;
                                if (y > 2 && polje[x, y - 3].BackColor == Color.Aqua) y--;
                                polje[x, y].BackColor = Color.Green;
                                polje[x, y + 1].BackColor = Color.Green;
                                polje[x, y - 1].BackColor = Color.Green;
                                polje[x, y - 2].BackColor = Color.Green;
                                break;
                        }
                        break;
                    case 5://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 2, y - 1].BackColor = Color.Aqua;
                                if (y > 1 && polje[x, y - 1].BackColor == Color.Aqua && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x + 2, y - 2].BackColor == Color.Aqua) y--;
                                polje[x, y].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 2, y].BackColor = Color.Pink;
                                polje[x + 2, y - 1].BackColor = Color.Pink;
                                break;
                            case 2:
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (y > 1 && polje[x, y - 2].BackColor == Color.Aqua && polje[x + 1, y - 2].BackColor == Color.Aqua) y--;
                                polje[x, y - 1].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 1, y + 1].BackColor = Color.Pink;
                                polje[x + 1, y - 1].BackColor = Color.Pink;
                                break;
                            case 3:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                if (y > 0 && polje[x, y - 1].BackColor == Color.Aqua && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua) y--;
                                polje[x, y].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 2, y].BackColor = Color.Pink;
                                polje[x, y + 1].BackColor = Color.Pink;
                                break;
                            case 4:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x + 2, y + 1].BackColor = Color.Aqua;
                                if (y > 1 && polje[x + 1, y - 2].BackColor == Color.Aqua && polje[x + 2, y].BackColor == Color.Aqua) y--;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 1, y + 1].BackColor = Color.Pink;
                                polje[x + 1, y - 1].BackColor = Color.Pink;
                                polje[x + 2, y + 1].BackColor = Color.Pink;
                                break;
                        }
                        break;
                    case 6://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                if (y > 1 && polje[x, y - 2].BackColor == Color.Aqua && polje[x + 1, y - 1].BackColor == Color.Aqua) y--;
                                polje[x, y].BackColor = Color.Black;
                                polje[x, y - 1].BackColor = Color.Black;
                                polje[x + 1, y].BackColor = Color.Black;
                                polje[x + 1, y + 1].BackColor = Color.Black;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x - 1, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (y > 1 && polje[x - 1, y - 1].BackColor == Color.Aqua && polje[x, y - 2].BackColor == Color.Aqua && polje[x + 1, y - 2].BackColor == Color.Aqua) y--;
                                polje[x, y].BackColor = Color.Black;
                                polje[x - 1, y].BackColor = Color.Black;
                                polje[x, y - 1].BackColor = Color.Black;
                                polje[x + 1, y - 1].BackColor = Color.Black;
                                break;
                        }
                        break;
                }//done
            }
            if (e.KeyCode == Keys.Right)
            {
                switch (shape)
                {
                    case 1://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 2, y + 1].BackColor = Color.Aqua;
                                if (y < 8 && polje[x, y + 1].BackColor == Color.Aqua && polje[x + 1, y + 1].BackColor == Color.Aqua && polje[x + 2, y + 2].BackColor == Color.Aqua) y++;
                                polje[x, y].BackColor = Color.Red;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 2, y].BackColor = Color.Red;
                                polje[x + 2, y + 1].BackColor = Color.Red;
                                break;
                            case 2:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x + 2, y - 1].BackColor = Color.Aqua;
                                if (y < 8 && polje[x + 1, y + 2].BackColor == Color.Aqua && polje[x + 2, y].BackColor == Color.Aqua) y++;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 1, y + 1].BackColor = Color.Red;
                                polje[x + 1, y - 1].BackColor = Color.Red;
                                polje[x + 2, y - 1].BackColor = Color.Red;
                                break;
                            case 3:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                if (y < 9 && polje[x, y + 1].BackColor == Color.Aqua && polje[x + 1, y + 1].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua) y++;
                                polje[x, y].BackColor = Color.Red;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 2, y].BackColor = Color.Red;
                                polje[x, y - 1].BackColor = Color.Red;
                                break;
                            case 4:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                if (y < 8 && polje[x, y + 2].BackColor == Color.Aqua && polje[x + 1, y + 2].BackColor == Color.Aqua) y++;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 1, y + 1].BackColor = Color.Red;
                                polje[x + 1, y - 1].BackColor = Color.Red;
                                polje[x, y + 1].BackColor = Color.Red;
                                break;
                        }
                        break;
                    case 2://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (y < 8 && polje[x, y + 2].BackColor == Color.Aqua && polje[x + 1, y + 1].BackColor == Color.Aqua) y++;
                                polje[x, y].BackColor = Color.Blue;
                                polje[x, y + 1].BackColor = Color.Blue;
                                polje[x + 1, y].BackColor = Color.Blue;
                                polje[x + 1, y - 1].BackColor = Color.Blue;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x - 1, y - 1].BackColor = Color.Aqua;
                                if (y < 9 && polje[x, y + 1].BackColor == Color.Aqua && polje[x + 1, y + 1].BackColor == Color.Aqua && polje[x - 1, y].BackColor == Color.Aqua) y++;
                                polje[x, y].BackColor = Color.Blue;
                                polje[x + 1, y].BackColor = Color.Blue;
                                polje[x, y - 1].BackColor = Color.Blue;
                                polje[x - 1, y - 1].BackColor = Color.Blue;
                                break;
                        }
                        break;
                    case 3://done
                        polje[x, y].BackColor = Color.Aqua;
                        polje[x, y + 1].BackColor = Color.Aqua;
                        polje[x + 1, y].BackColor = Color.Aqua;
                        polje[x + 1, y + 1].BackColor = Color.Aqua;
                        if (y < 8 && polje[x, y + 2].BackColor == Color.Aqua && polje[x + 1, y + 2].BackColor == Color.Aqua) y++;
                        polje[x, y].BackColor = Color.Yellow;
                        polje[x, y + 1].BackColor = Color.Yellow;
                        polje[x + 1, y].BackColor = Color.Yellow;
                        polje[x + 1, y + 1].BackColor = Color.Yellow;
                        break;
                    case 4://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 3, y].BackColor = Color.Aqua;
                                if (y < 9  && polje[x, y + 1].BackColor == Color.Aqua && polje[x + 1, y + 1].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua && polje[x + 3, y + 1].BackColor == Color.Aqua) y++;
                                polje[x, y].BackColor = Color.Green;
                                polje[x + 1, y].BackColor = Color.Green;
                                polje[x + 2, y].BackColor = Color.Green;
                                polje[x + 3, y].BackColor = Color.Green;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x, y - 2].BackColor = Color.Aqua;
                                if (y < 8 && polje[x, y + 2].BackColor == Color.Aqua) y++;
                                polje[x, y].BackColor = Color.Green;
                                polje[x, y + 1].BackColor = Color.Green;
                                polje[x, y - 1].BackColor = Color.Green;
                                polje[x, y - 2].BackColor = Color.Green;
                                break;
                        }
                        break;
                    case 5://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 2, y - 1].BackColor = Color.Aqua;
                                if (y < 9 && polje[x, y + 1].BackColor == Color.Aqua && polje[x + 1, y + 1].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua) y++;
                                polje[x, y].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 2, y].BackColor = Color.Pink;
                                polje[x + 2, y - 1].BackColor = Color.Pink;
                                break;
                            case 2:
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (y < 8 && polje[x, y].BackColor == Color.Aqua && polje[x + 1, y + 2].BackColor == Color.Aqua) y++;
                                polje[x, y - 1].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 1, y + 1].BackColor = Color.Pink;
                                polje[x + 1, y - 1].BackColor = Color.Pink;
                                break;
                            case 3:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                if (y < 8 && polje[x + 1, y + 1].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua && polje[x, y + 2].BackColor == Color.Aqua) y++;
                                polje[x, y].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 2, y].BackColor = Color.Pink;
                                polje[x, y + 1].BackColor = Color.Pink;
                                break;
                            case 4:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x + 2, y + 1].BackColor = Color.Aqua;
                                if (y < 8 && polje[x + 1, y + 2].BackColor == Color.Aqua && polje[x + 2, y + 2].BackColor == Color.Aqua) y++;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 1, y + 1].BackColor = Color.Pink;
                                polje[x + 1, y - 1].BackColor = Color.Pink;
                                polje[x + 2, y + 1].BackColor = Color.Pink;
                                break;
                        }
                        break;
                    case 6://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                if (y < 8 && polje[x, y + 1].BackColor == Color.Aqua && polje[x + 1, y + 2].BackColor == Color.Aqua) y++;
                                polje[x, y].BackColor = Color.Black;
                                polje[x, y - 1].BackColor = Color.Black;
                                polje[x + 1, y].BackColor = Color.Black;
                                polje[x + 1, y + 1].BackColor = Color.Black;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x - 1, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (y < 9 && polje[x, y + 1].BackColor == Color.Aqua && polje[x - 1, y + 1].BackColor == Color.Aqua && polje[x + 1, y].BackColor == Color.Aqua) y++;
                                polje[x, y].BackColor = Color.Black;
                                polje[x - 1, y].BackColor = Color.Black;
                                polje[x, y - 1].BackColor = Color.Black;
                                polje[x + 1, y - 1].BackColor = Color.Black;
                                break;
                        }
                        break;
                }//done
            }
            if (e.KeyCode == Keys.Down)
            {

                switch (shape)
                {
                    case 1://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 2, y + 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 3, y].BackColor == Color.Aqua && polje[x + 3, y + 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Red;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 2, y].BackColor = Color.Red;
                                polje[x + 2, y + 1].BackColor = Color.Red;
                                break;
                            case 2:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x + 2, y - 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua && polje[x + 3, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 1, y + 1].BackColor = Color.Red;
                                polje[x + 1, y - 1].BackColor = Color.Red;
                                polje[x + 2, y - 1].BackColor = Color.Red;
                                break;
                            case 3:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x + 3, y].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Red;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 2, y].BackColor = Color.Red;
                                polje[x, y - 1].BackColor = Color.Red;
                                break;
                            case 4:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 1, y + 1].BackColor = Color.Red;
                                polje[x + 1, y - 1].BackColor = Color.Red;
                                polje[x, y + 1].BackColor = Color.Red;
                                break;
                        }
                        break;
                    case 2://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 1, y + 1].BackColor == Color.Aqua && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Blue;
                                polje[x, y + 1].BackColor = Color.Blue;
                                polje[x + 1, y].BackColor = Color.Blue;
                                polje[x + 1, y - 1].BackColor = Color.Blue;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x - 1, y - 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 1, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Blue;
                                polje[x + 1, y].BackColor = Color.Blue;
                                polje[x, y - 1].BackColor = Color.Blue;
                                polje[x - 1, y - 1].BackColor = Color.Blue;
                                break;
                        }
                        break;
                    case 3://done
                        polje[x, y].BackColor = Color.Aqua;
                        polje[x, y + 1].BackColor = Color.Aqua;
                        polje[x + 1, y].BackColor = Color.Aqua;
                        polje[x + 1, y + 1].BackColor = Color.Aqua;
                        if (x < 18 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua) x++; else pada = false;
                        polje[x, y].BackColor = Color.Yellow;
                        polje[x, y + 1].BackColor = Color.Yellow;
                        polje[x + 1, y].BackColor = Color.Yellow;
                        polje[x + 1, y + 1].BackColor = Color.Yellow;
                        break;
                    case 4://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 3, y].BackColor = Color.Aqua;
                                if (x < 16 && polje[x + 4, y].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Green;
                                polje[x + 1, y].BackColor = Color.Green;
                                polje[x + 2, y].BackColor = Color.Green;
                                polje[x + 3, y].BackColor = Color.Green;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x, y - 2].BackColor = Color.Aqua;
                                if (x < 19 && polje[x + 1, y].BackColor == Color.Aqua && polje[x + 1, y + 1].BackColor == Color.Aqua && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x + 1, y - 2].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Green;
                                polje[x, y + 1].BackColor = Color.Green;
                                polje[x, y - 1].BackColor = Color.Green;
                                polje[x, y - 2].BackColor = Color.Green;
                                break;
                        }
                        break;
                    case 5://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 2, y - 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 3, y].BackColor == Color.Aqua && polje[x + 3, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 2, y].BackColor = Color.Pink;
                                polje[x + 2, y - 1].BackColor = Color.Pink;
                                break;
                            case 2:
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y - 1].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 1, y + 1].BackColor = Color.Pink;
                                polje[x + 1, y - 1].BackColor = Color.Pink;
                                break;
                            case 3:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 3, y].BackColor == Color.Aqua && polje[x + 1, y + 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 2, y].BackColor = Color.Pink;
                                polje[x, y + 1].BackColor = Color.Pink;
                                break;
                            case 4:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x + 2, y + 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua && polje[x + 3, y + 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 1, y + 1].BackColor = Color.Pink;
                                polje[x + 1, y - 1].BackColor = Color.Pink;
                                polje[x + 2, y + 1].BackColor = Color.Pink;
                                break;
                        }
                        break;
                    case 6://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Black;
                                polje[x, y - 1].BackColor = Color.Black;
                                polje[x + 1, y].BackColor = Color.Black;
                                polje[x + 1, y + 1].BackColor = Color.Black;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x - 1, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 1, y].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Black;
                                polje[x - 1, y].BackColor = Color.Black;
                                polje[x, y - 1].BackColor = Color.Black;
                                polje[x + 1, y - 1].BackColor = Color.Black;
                                break;
                        }
                        break;
                }//done
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                
                switch (shape)
                {
                    case 1://done L
                        switch (rotacija)
                        {
                            case 1:
                                //brisanje rotacije 1
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 2, y + 1].BackColor = Color.Aqua;
                                //rotacija 2
                                if (y == 0) y = 1;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 1, y + 1].BackColor = Color.Red;
                                polje[x + 1, y - 1].BackColor = Color.Red;
                                polje[x + 2, y - 1].BackColor = Color.Red;
                                rotacija = 2;
                                break;
                            case 2:
                                //brisanje rotacije 2
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x + 2, y - 1].BackColor = Color.Aqua;
                                //rotacija 3
                                polje[x, y].BackColor = Color.Red;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 2, y].BackColor = Color.Red;
                                polje[x, y - 1].BackColor = Color.Red;
                                rotacija = 3;
                                break;
                            case 3:
                                //brisanje rotacije 3
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                //rotacija 4
                                if (y == 9) y = 8;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 1, y + 1].BackColor = Color.Red;
                                polje[x + 1, y - 1].BackColor = Color.Red;
                                polje[x, y + 1].BackColor = Color.Red;
                                rotacija = 4;
                                break;
                            case 4:
                                //brisanje rotacije 4
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                //rotacija 1
                                polje[x, y].BackColor = Color.Red;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 2, y].BackColor = Color.Red;
                                polje[x + 2, y + 1].BackColor = Color.Red;
                                rotacija = 1;
                                break;
                        }
                        break;
                    case 2://done stepenice desno
                        switch (rotacija)
                        {
                            case 1:
                                //brisanje rotacije 1
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                //rotacija 2
                                polje[x, y].BackColor = Color.Blue;
                                polje[x + 1, y].BackColor = Color.Blue;
                                polje[x, y - 1].BackColor = Color.Blue;
                                polje[x - 1, y - 1].BackColor = Color.Blue;
                                rotacija = 2;
                                break;
                            case 2:
                                //brisanje rotacije 2
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x - 1, y - 1].BackColor = Color.Aqua;
                                //rotacija 1
                                if (y == 9) y = 8;
                                polje[x, y].BackColor = Color.Blue;
                                polje[x, y + 1].BackColor = Color.Blue;
                                polje[x + 1, y].BackColor = Color.Blue;
                                polje[x + 1, y - 1].BackColor = Color.Blue;
                                rotacija = 1;
                                break;
                        }
                        break;
                    case 3://done kvadrat
                        break;
                    case 4://done stap
                        switch (rotacija)
                        {
                            case 1:
                                //brisanje rotacije 1
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 3, y].BackColor = Color.Aqua;
                                //rotacija 2
                                if (y == 0) y = 2;
                                if (y == 9) y = 8;
                                polje[x, y].BackColor = Color.Green;
                                polje[x, y + 1].BackColor = Color.Green;
                                polje[x, y - 1].BackColor = Color.Green;
                                polje[x, y - 2].BackColor = Color.Green;
                                rotacija = 2;
                                break;
                            case 2:
                                //brisanje rotacije 2
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x, y - 2].BackColor = Color.Aqua;
                                //rotacija 1
                                polje[x, y].BackColor = Color.Green;
                                polje[x + 1, y].BackColor = Color.Green;
                                polje[x + 2, y].BackColor = Color.Green;
                                polje[x + 3, y].BackColor = Color.Green;
                                rotacija = 1;
                                break;
                        }
                        break;
                    case 5://done G
                        switch (rotacija)
                        {
                            case 1:
                                //brisanje rotacije 1
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 2, y - 1].BackColor = Color.Aqua;
                                //rotacija 2
                                if (y == 9) y = 8;
                                polje[x, y - 1].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 1, y + 1].BackColor = Color.Pink;
                                polje[x + 1, y - 1].BackColor = Color.Pink;
                                rotacija = 2;
                                break;
                            case 2:
                                //brisanje rotacije 2
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                //rotacija 3
                                polje[x, y].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 2, y].BackColor = Color.Pink;
                                polje[x, y + 1].BackColor = Color.Pink;
                                rotacija = 3;
                                break;
                            case 3:
                                //brisanje rotacije 3
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                //rotacija 4
                                if (y == 0) y = 1;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 1, y + 1].BackColor = Color.Pink;
                                polje[x + 1, y - 1].BackColor = Color.Pink;
                                polje[x + 2, y + 1].BackColor = Color.Pink;
                                rotacija = 4;
                                break;
                            case 4:
                                //brisanje rotacije 4
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x + 2, y + 1].BackColor = Color.Aqua;
                                //rotacija 1
                                polje[x, y].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 2, y].BackColor = Color.Pink;
                                polje[x + 2, y - 1].BackColor = Color.Pink;
                                rotacija = 1;
                                break;
                        }
                        break;
                    case 6://done stepenice levo
                        switch (rotacija)
                        {
                            case 1:
                                //brisanje rotacije 1
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                //rotacija 2
                                polje[x, y].BackColor = Color.Black;
                                polje[x - 1, y].BackColor = Color.Black;
                                polje[x, y - 1].BackColor = Color.Black;
                                polje[x + 1, y - 1].BackColor = Color.Black;
                                rotacija = 2;
                                break;
                            case 2:
                                //brisanje rotacije 2
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x - 1, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                //rotacija 1
                                if (y == 9) y = 8;
                                polje[x, y].BackColor = Color.Black;
                                polje[x, y - 1].BackColor = Color.Black;
                                polje[x + 1, y].BackColor = Color.Black;
                                polje[x + 1, y + 1].BackColor = Color.Black;
                                rotacija = 1;
                                break;
                        }
                        break;
                }//ima nesto
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pozadina.Size = new Size(300,600);
            pozadina.BackColor = Color.Aqua;
            pozadina.Location = new Point(30,15);
            for(int i = 0; i < 20; i++)
                for(int j = 0; j < 10; j++)
                {
                    polje[i, j] = new PictureBox
                    {
                        Size = new Size(30, 30),
                        Location = new Point(pozadina.Location.X + j * 30, pozadina.Location.Y + i * 30),
                        BackColor = pozadina.BackColor
                    };
                    Controls.Add(polje[i, j]);
                }

            Controls.Add(pozadina);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!pada)
            {
                int granica=0,brojredovaslozenih = 0;
                for(int i = 0; i < 20; i++)
                {
                    if(polje[i, 0].BackColor != Color.Aqua && polje[i, 1].BackColor != Color.Aqua && polje[i, 2].BackColor != Color.Aqua && polje[i, 3].BackColor != Color.Aqua && polje[i, 4].BackColor != Color.Aqua && polje[i, 5].BackColor != Color.Aqua && polje[i, 6].BackColor != Color.Aqua && polje[i, 7].BackColor != Color.Aqua && polje[i, 8].BackColor != Color.Aqua && polje[i, 9].BackColor != Color.Aqua)
                    {
                        polje[i, 0].BackColor = Color.Aqua;
                        polje[i, 1].BackColor = Color.Aqua;
                        polje[i, 2].BackColor = Color.Aqua;
                        polje[i, 3].BackColor = Color.Aqua;
                        polje[i, 4].BackColor = Color.Aqua;
                        polje[i, 5].BackColor = Color.Aqua;
                        polje[i, 6].BackColor = Color.Aqua;
                        polje[i, 7].BackColor = Color.Aqua;
                        polje[i, 8].BackColor = Color.Aqua;
                        polje[i, 9].BackColor = Color.Aqua;
                        brojredovaslozenih++;
                        granica = i;
                    }
                }
                if (brojredovaslozenih > 0)
                {
                    for(int i = granica-brojredovaslozenih; i >= 0; i--)
                    {
                        for(int j = 0; j < 10; j++)
                        {
                            polje[i + brojredovaslozenih, j].BackColor = polje[i, j].BackColor;
                        }
                    }
                }
                rotacija = 1;
                x = 0;
                shape = r.Next(1,7);
                y = r.Next(0, 10);
                switch (shape)
                {
                    case 1:
                        if (y == 9) y = 8;
                        polje[x, y].BackColor = Color.Red;
                        polje[x+1, y].BackColor = Color.Red;
                        polje[x+2, y].BackColor = Color.Red;
                        polje[x+2, y+1].BackColor = Color.Red;
                        break;
                    case 2:
                        if (y == 9) y = 8;
                        if (y == 0) y = 1;
                        polje[x, y].BackColor = Color.Blue;
                        polje[x, y+1].BackColor = Color.Blue;
                        polje[x+1, y].BackColor = Color.Blue;
                        polje[x+1, y-1].BackColor = Color.Blue;
                        break;
                    case 3:
                        if (y == 9) y = 8;
                        if (y == 0) y = 1;
                        polje[x, y].BackColor = Color.Yellow;
                        polje[x, y+1].BackColor = Color.Yellow;
                        polje[x+1, y].BackColor = Color.Yellow;
                        polje[x+1, y+1].BackColor = Color.Yellow;
                        break;
                    case 4:
                        polje[x, y].BackColor = Color.Green;
                        polje[x+1, y].BackColor = Color.Green;
                        polje[x+2, y].BackColor = Color.Green;
                        polje[x+3, y].BackColor = Color.Green;
                        break;
                    case 5:
                        if (y == 0) y = 1;
                        polje[x, y].BackColor = Color.Pink;
                        polje[x+1, y].BackColor = Color.Pink;
                        polje[x+2, y].BackColor = Color.Pink;
                        polje[x+2, y-1].BackColor = Color.Pink;
                        break;
                    case 6:
                        if (y == 9) y = 8;
                        if (y == 0) y = 1;
                        polje[x, y].BackColor = Color.Black;
                        polje[x, y-1].BackColor = Color.Black;
                        polje[x+1, y].BackColor = Color.Black;
                        polje[x+1, y+1].BackColor = Color.Black;
                        break;
                }
                pada = true;
            }
            if (pada)
            {
                
                switch (shape)
                {
                    case 1://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 2, y + 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 3, y].BackColor == Color.Aqua && polje[x + 3, y + 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Red;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 2, y].BackColor = Color.Red;
                                polje[x + 2, y + 1].BackColor = Color.Red;
                                break;
                            case 2:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x + 2, y - 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua && polje[x + 3, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 1, y + 1].BackColor = Color.Red;
                                polje[x + 1, y - 1].BackColor = Color.Red;
                                polje[x + 2, y - 1].BackColor = Color.Red;
                                break;
                            case 3:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x + 3, y].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Red;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 2, y].BackColor = Color.Red;
                                polje[x, y - 1].BackColor = Color.Red;
                                break;
                            case 4:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x + 1, y].BackColor = Color.Red;
                                polje[x + 1, y + 1].BackColor = Color.Red;
                                polje[x + 1, y - 1].BackColor = Color.Red;
                                polje[x, y + 1].BackColor = Color.Red;
                                break;
                        }
                        break;
                    case 2://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 1, y + 1].BackColor == Color.Aqua && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Blue;
                                polje[x, y + 1].BackColor = Color.Blue;
                                polje[x + 1, y].BackColor = Color.Blue;
                                polje[x + 1, y - 1].BackColor = Color.Blue;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x - 1, y - 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 1, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Blue;
                                polje[x + 1, y].BackColor = Color.Blue;
                                polje[x, y - 1].BackColor = Color.Blue;
                                polje[x - 1, y - 1].BackColor = Color.Blue;
                                break;
                        }
                        break;
                    case 3://done
                        polje[x, y].BackColor = Color.Aqua;
                        polje[x, y + 1].BackColor = Color.Aqua;
                        polje[x + 1, y].BackColor = Color.Aqua;
                        polje[x + 1, y + 1].BackColor = Color.Aqua;
                        if (x < 18 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua) x++; else pada = false;
                        polje[x, y].BackColor = Color.Yellow;
                        polje[x, y + 1].BackColor = Color.Yellow;
                        polje[x + 1, y].BackColor = Color.Yellow;
                        polje[x + 1, y + 1].BackColor = Color.Yellow;
                        break;
                    case 4://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 3, y].BackColor = Color.Aqua;
                                if (x < 16 && polje[x + 4, y].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Green;
                                polje[x + 1, y].BackColor = Color.Green;
                                polje[x + 2, y].BackColor = Color.Green;
                                polje[x + 3, y].BackColor = Color.Green;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x, y - 2].BackColor = Color.Aqua;
                                if (x < 19 && polje[x + 1, y].BackColor == Color.Aqua && polje[x + 1, y + 1].BackColor == Color.Aqua && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x + 1, y - 2].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Green;
                                polje[x, y + 1].BackColor = Color.Green;
                                polje[x, y - 1].BackColor = Color.Green;
                                polje[x, y - 2].BackColor = Color.Green;
                                break;
                        }
                        break;
                    case 5://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x + 2, y - 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 3, y].BackColor == Color.Aqua && polje[x + 3, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 2, y].BackColor = Color.Pink;
                                polje[x + 2, y - 1].BackColor = Color.Pink;
                                break;
                            case 2:
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y - 1].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 1, y + 1].BackColor = Color.Pink;
                                polje[x + 1, y - 1].BackColor = Color.Pink;
                                break;
                            case 3:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 2, y].BackColor = Color.Aqua;
                                polje[x, y + 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 3, y].BackColor == Color.Aqua && polje[x + 1, y + 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Pink;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 2, y].BackColor = Color.Pink;
                                polje[x, y + 1].BackColor = Color.Pink;
                                break;
                            case 4:
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                polje[x + 2, y + 1].BackColor = Color.Aqua;
                                if (x < 17 && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua && polje[x + 3, y + 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x + 1, y].BackColor = Color.Pink;
                                polje[x + 1, y + 1].BackColor = Color.Pink;
                                polje[x + 1, y - 1].BackColor = Color.Pink;
                                polje[x + 2, y + 1].BackColor = Color.Pink;
                                break;
                        }
                        break;
                    case 6://done
                        switch (rotacija)
                        {
                            case 1:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y].BackColor = Color.Aqua;
                                polje[x + 1, y + 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 1, y - 1].BackColor == Color.Aqua && polje[x + 2, y].BackColor == Color.Aqua && polje[x + 2, y + 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Black;
                                polje[x, y - 1].BackColor = Color.Black;
                                polje[x + 1, y].BackColor = Color.Black;
                                polje[x + 1, y + 1].BackColor = Color.Black;
                                break;
                            case 2:
                                polje[x, y].BackColor = Color.Aqua;
                                polje[x - 1, y].BackColor = Color.Aqua;
                                polje[x, y - 1].BackColor = Color.Aqua;
                                polje[x + 1, y - 1].BackColor = Color.Aqua;
                                if (x < 18 && polje[x + 1, y].BackColor == Color.Aqua && polje[x + 2, y - 1].BackColor == Color.Aqua) x++; else pada = false;
                                polje[x, y].BackColor = Color.Black;
                                polje[x - 1, y].BackColor = Color.Black;
                                polje[x, y - 1].BackColor = Color.Black;
                                polje[x + 1, y - 1].BackColor = Color.Black;
                                break;
                        }
                        break;
                }
            }
        }
    }
}