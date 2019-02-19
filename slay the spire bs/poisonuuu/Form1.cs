using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poisonuuu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        TextBox tbBrojpoteza = new TextBox();
        Button bt1 = new Button();
        int x, dmgp1 = 0, dmgs1 = 0, dmgp2 = 0, dmgs2 = 0;
        private void Bt1_Click(object sender, EventArgs e)
        {
            x = Convert.ToInt32(tbBrojpoteza.Text);
            for (int i = 1; i <= x; i++)
            {
                dmgp1 += 7 * i + 1;
                dmgs1 += 3;
                dmgp2 += i + 1;
                dmgs2 += 12;
            }
            int Poison = dmgp1 + dmgs1;
            int Sadistic = dmgp2 + dmgs2;
            MessageBox.Show("Poison:" + Poison.ToString() + "  " + "Sadistic:" + Sadistic.ToString(), "Rezultat");
            dmgp1 = 0;
            dmgs1 = 0;
            dmgp2 = 0;
            dmgs2 = 0;

        }
    }
}
