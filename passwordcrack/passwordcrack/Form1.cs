using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordcrack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string sifra;

        // public int x = 0,turn=0,y=0;
        // public double app;
        public Semaphore sema = new Semaphore(1, 1);
        void NadjiSifru(object state)
        {
            string rezultat;
            int duzina = Convert.ToInt32(state);
            Random r = new Random();
            // Stopwatch watch = new Stopwatch();
            char[] karakter = new Char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] proba = new Char[duzina];
            sema.WaitOne();
            string cache = sifra;
            sema.Release();
            // watch.Start();
            do
            {
                // if (watch.Elapsed.TotalMilliseconds >= 10000) break;
            
                for (int i = 0; i < duzina; i++)
                {
                    proba[i] = karakter[r.Next(0, 36)];
                }
                rezultat = new string(proba);
                //x++;
                
            }
            while (rezultat != cache);
            // watch.Reset();
            // y += x;
            // app = y / turn;
            if (rezultat == cache) MessageBox.Show(rezultat, cache);
            // MessageBox.Show(app.ToString(), x.ToString());
        }
        private void btCrack_Click(object sender, EventArgs e)
        {
            //turn++;
            //x = 0;
            sifra = tbSifra.Text.ToString();
            int duzinasifre = sifra.Length;
            ThreadPool.QueueUserWorkItem(new WaitCallback(NadjiSifru),duzinasifre);
            //ThreadPool.QueueUserWorkItem(new WaitCallback(NadjiSifru),duzinasifre);
        }
    }
}
