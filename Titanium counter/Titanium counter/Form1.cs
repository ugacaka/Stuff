using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Titanium_counter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            double saronite_ore, titanium_ore, saronite_bar, titanium_bar;
            double num_titanium, num_chopper;
            saronite_ore = Convert.ToInt32(tbSO.Text);
            saronite_bar = Convert.ToInt32(tbSB.Text);
            titanium_ore = Convert.ToInt32(tbTO.Text);
            titanium_bar = Convert.ToInt32(tbTB.Text);
            if (cbTB.Checked) { num_titanium = saronite_ore * 1.2 / 16 + saronite_bar * 1.2 / 8 + titanium_bar + titanium_ore / 2; }
            else { num_titanium = saronite_ore / 16 + saronite_bar / 8 + titanium_bar + titanium_ore / 2; }
            num_chopper = num_titanium / 36;
            lblTB.Text = Math.Round(num_titanium, 2).ToString();
            lblC.Text = Math.Round(num_chopper, 2).ToString();
        }
    }
}
