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

namespace ObliciCrtanje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int oblik = 2, a = 50;
        Point tu;
        void CrtacGore(object sender)
        {
            Point _tu = tu;
            int oblik = (int)sender, _a = a, b = Convert.ToInt32(_a * 3 / 4);
            double y, preciznost = 0.1;
            Pen olovka = new Pen(Color.Blue);
            Graphics g = pozadina.CreateGraphics();
            Point point = new Point(_a + _tu.X, _tu.Y);
            Point _point = point;
            for (double x = _a; x >= -1 * _a; x -= preciznost)
            {
                if (oblik == 0)
                {
                    y = -1 * Math.Sqrt(Math.Pow(_a, 2) - Math.Pow(x, 2));//kruznica
                    point = new Point(_tu.X, _tu.Y);
                    _point = new Point(Convert.ToInt32(x + _tu.X), Convert.ToInt32(y + _tu.Y));
                }
                if (oblik == 1)
                {
                    y = -1 * b * Math.Sqrt(1 - Math.Pow(x, 2) / Math.Pow(_a, 2));//elipsa
                    point = new Point(_tu.X, _tu.Y);
                    _point = new Point(Convert.ToInt32(x + _tu.X), Convert.ToInt32(y + _tu.Y));
                }
                if (oblik == 2)
                {
                    _point = point;
                    y = -1 * Math.Sqrt(Math.Pow(_a, 2) - Math.Pow(x, 2));//krug
                    point = new Point(Convert.ToInt32(x + _tu.X), Convert.ToInt32(y + _tu.Y));
                }
                g.DrawLine(olovka, point, _point);
            }
        }

        void CrtacDole(object sender)
        {
            Point _tu = tu;
            int oblik = (int)sender, _a = a, b = Convert.ToInt32(_a * 3 / 4);
            double y, preciznost = 0.1;
            Pen olovka = new Pen(Color.Red);
            Graphics g = pozadina.CreateGraphics();
            Point point = new Point(-1 * _a + _tu.X, _tu.Y);
            Point _point = point;
            for (double x = -1 * _a; x <= _a; x += preciznost)
            {
                if (oblik == 0)
                {
                    y = Math.Sqrt(Math.Pow(_a, 2) - Math.Pow(x, 2));//kruznica
                    point = new Point(_tu.X, _tu.Y);
                    _point = new Point(Convert.ToInt32(x + _tu.X), Convert.ToInt32(y + _tu.Y));
                }
                if (oblik == 1)
                {
                    y = b * Math.Sqrt(1 - Math.Pow(x, 2) / Math.Pow(_a, 2));//elipsa
                    point = new Point(_tu.X, _tu.Y);
                    _point = new Point(Convert.ToInt32(x + _tu.X), Convert.ToInt32(y + _tu.Y));
                }
                if (oblik == 2)
                {
                    _point = point;
                    y = Math.Sqrt(Math.Pow(_a, 2) - Math.Pow(x, 2));//krug
                    point = new Point(Convert.ToInt32(x + _tu.X), Convert.ToInt32(y + _tu.Y));
                }
                g.DrawLine(olovka, point, _point);
            }
        }
        void Tacka(object sender)
        {
            Point _tu = tu;
            int _a = a;
            double y, preciznost = 1;
            Pen olovka = new Pen(Color.Blue),t;
            Graphics g = pozadina.CreateGraphics();
            Point point = new Point(_a + _tu.X, _tu.Y);
            Point _point = point;
            do
            {
                for (double x = _a; x >= -1 * _a; x -= preciznost)
                {
                    
                    _point = point;
                    y = -1 * Math.Sqrt(Math.Pow(_a, 2) - Math.Pow(x, 2));//krug
                    point = new Point(Convert.ToInt32(x + _tu.X), Convert.ToInt32(y + _tu.Y));
                    g.DrawLine(olovka, point, _point);
                }
                for (double x = -1 * _a; x <= _a; x += preciznost)
                {
                    
                    _point = point;
                    y = Math.Sqrt(Math.Pow(_a, 2) - Math.Pow(x, 2));//krug
                    point = new Point(Convert.ToInt32(x + _tu.X), Convert.ToInt32(y + _tu.Y));
                    g.DrawLine(olovka, point, _point);
                    
                }
                if (olovka.Color == Color.Red) olovka.Color = Color.Blue;
                else if (olovka.Color == Color.Blue) olovka.Color = Color.Green;
                else if (olovka.Color == Color.Green) olovka.Color = Color.Magenta;
                else if (olovka.Color == Color.Magenta) olovka.Color = Color.Cyan;
                else if (olovka.Color == Color.Cyan) olovka.Color = Color.Black;
                else  olovka.Color = Color.Red;
            } while(true);
        }
        void Radar(object sender)
        {
            Point _tu = tu;
            int _a = a;
            double y, preciznost = 0.1;
            Pen olovka = new Pen(Color.Blue), t;
            Graphics g = pozadina.CreateGraphics();
            Point point = new Point(_a + _tu.X, _tu.Y);
            Point _point = point;
            do
            {
                for (double x = _a; x >= -1 * _a; x -= preciznost)
                {
                    g.DrawLine(t = new Pen(DefaultBackColor), point, _point);
                    y = -1 * Math.Sqrt(Math.Pow(_a, 2) - Math.Pow(x, 2));//kruznica
                    point = new Point(_tu.X, _tu.Y);
                    _point = new Point(Convert.ToInt32(x + _tu.X), Convert.ToInt32(y + _tu.Y));
                    g.DrawLine(olovka, point, _point);
                }
                for (double x = -1 * _a; x <= _a; x += preciznost)
                {
                    g.DrawLine(t = new Pen(DefaultBackColor), point, _point);
                    y = Math.Sqrt(Math.Pow(_a, 2) - Math.Pow(x, 2));//kruznica
                    point = new Point(_tu.X, _tu.Y);
                    _point = new Point(Convert.ToInt32(x + _tu.X), Convert.ToInt32(y + _tu.Y));
                    g.DrawLine(olovka, point, _point);

                }
            } while (true);
        }
        private void pozadina_MouseClick(object sender, MouseEventArgs e)
        {
            tu = pozadina.PointToClient(Cursor.Position);
           // ThreadPool.QueueUserWorkItem(CrtacGore, oblik);
           // ThreadPool.QueueUserWorkItem(CrtacDole, oblik);
            ThreadPool.QueueUserWorkItem(Radar);
        }
    }
}