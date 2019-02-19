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
using System.Numerics;

namespace passwordcrack2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public char[] recnik = new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public BigInteger Konvertuj(string rec)
        {
            BigInteger broj = 0;
            int duzina_rec = rec.Length;
            for (int i = 0; i < duzina_rec; i++)
            {
                broj += BigInteger.Pow(36, i) * Array.FindIndex(recnik, x => x == rec[duzina_rec-1 - i]); 
            }
            return broj;
        }
        public string Dekriptuj(BigInteger broj)
        {
            string rec = null;
            BigInteger temp = new BigInteger();
            do
            {
                temp = broj % 36;
                rec += Convert.ToString(recnik[(int)temp]);
                broj /= 36;

            } while (broj > 0);
            char[] rec1 = rec.ToCharArray();
            Array.Reverse(rec1);
            return new string(rec1);
        }
        private void btConvertuj_Click(object sender, EventArgs e)
        {

            tbSifra.Text = Convert.ToString(Konvertuj(Convert.ToString(tbSifra.Text)));            
        }

        private void btDektriptuj_Click(object sender, EventArgs e)
        {
            
            tbSifra.Text = Dekriptuj(BigInteger.Parse(tbSifra.Text));
        }
    }
}
