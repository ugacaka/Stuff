using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raspored_Mira
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Radnik[] radnik = new Radnik[9];
        public List<string> radnici = new List<string> { "Ljilja", "Jelena", "Ivan", "Beki", "Sandra", "Jasmina", "Ana", "Viktorija", "Dragana"};
        public static Random rng = new Random();
        public int[] brojevi = new int[] {0,1,2,3,4,5,6,7,8};
        public int[] redosled;
        public int godisnjiodmor = 0;
        public int salacd;
        public int popunjeno = 0;
        public bool pocetak=true;
        public bool magnet1=true, magnet2 = true, skener1 = true, skener2 = true, klasicna1 = true, klasicna2 = true, salasok = true,slobodan1=true,slobodan2=true;        
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Sledeca nedelja";
            if (pocetak)
            {
                pocetak = false;
                Probaj1();
            }
            else Probaj();
        }
        void GodisnjiOdmor()
        {
            salacd = 9 - clbGodisnjiOdmor.CheckedItems.Count;
            for (int i = 0; i < 9; i++)
            {
                if (clbGodisnjiOdmor.GetItemCheckState(i) == CheckState.Checked) radnik[i].godisnjiodmor = true;
                else radnik[i].godisnjiodmor = false;
            }
        }
        void Reset()
        {
            magnet1 = true;
            magnet2 = true;
            skener1 = true;
            skener2 = true;
            klasicna1 = true;
            klasicna2 = true;
            salasok = true;
            slobodan1 = true;
            slobodan2 = true;
            lblSala.Text = null;
            lblMagnet1.Text = null;
            lblSkener1.Text = null;
            lblKlasicna1.Text = null;
            lblMagnet2.Text = null;
            lblSkener2.Text = null;
            lblKlasicna2.Text = null;
            lblSlobodan1.Text = null;
            lblSlobodan2.Text = null;
            popunjeno = 0;
            godisnjiodmor = 0;
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            for(int i=0;i<9;i++)
            {
                radnik[i] = new Radnik();
                radnik[i].ime = radnici[i];
                clbBioSlobodan.Items[i] = radnici[i];
                clbGodisnjiOdmor.Items[i] = radnici[i];
                clbRadioKlasicnu.Items[i] = radnici[i];
                clbRadioMagnet.Items[i] = radnici[i];
                clbRadioSkener.Items[i] = radnici[i];
            }
        }
        void Probaj()
        {
            GodisnjiOdmor();
            do {
                Reset();
                for (int i = 0; i < 9; i++)
                {
                    radnik[i].probacdsala = radnik[i].cdsala;
                    radnik[i].probacdmagnet = radnik[i].cdmagnet;
                    radnik[i].probacdskener = radnik[i].cdskener;
                    radnik[i].probacdklasicna = radnik[i].cdklasicna;
                    radnik[i].probacdslobodan = radnik[i].cdslobodan;
                }
                for (int i = 0; i < 9; i++)
                {
                    if (radnik[i].probacdklasicna != 0) radnik[i].probacdklasicna--;
                    if (radnik[i].probacdskener != 0) radnik[i].probacdskener--;
                    if (radnik[i].probacdmagnet != 0) radnik[i].probacdmagnet--;
                    if (radnik[i].probacdslobodan != 0) radnik[i].probacdslobodan--;
                    if (radnik[i].probacdsala != 0) radnik[i].probacdsala--;
                }
                redosled = brojevi.OrderBy(x => rng.Next()).ToArray();
                for (int i = 0; i < 9; i++)
                {
                    if (radnik[redosled[i]].godisnjiodmor) { godisnjiodmor++; continue; }
                    if (salasok && radnik[redosled[i]].probacdsala == 0) { radnik[redosled[i]].probacdsala = salacd; salasok = false; popunjeno++; continue; }
                    if (magnet1 && radnik[redosled[i]].probacdmagnet == 0) { radnik[redosled[i]].probacdmagnet = 3; magnet1 = false; popunjeno++; continue; }
                    if (skener1 && radnik[redosled[i]].probacdskener == 0) { radnik[redosled[i]].probacdskener = 3; skener1 = false; popunjeno++; continue; }
                    if (klasicna1 && radnik[redosled[i]].probacdklasicna == 0) { radnik[redosled[i]].probacdklasicna = 3; klasicna1 = false; popunjeno++; continue; }
                    if (magnet2 && radnik[redosled[i]].probacdmagnet == 0) { radnik[redosled[i]].probacdmagnet = 3; magnet2 = false; popunjeno++; continue; }
                    if (skener2 && radnik[redosled[i]].probacdskener == 0) { radnik[redosled[i]].probacdskener = 3; skener2 = false; popunjeno++; continue; }
                    if (klasicna2 && radnik[redosled[i]].probacdklasicna == 0) { radnik[redosled[i]].probacdklasicna = 3; klasicna2 = false; popunjeno++; continue; }
                    if (slobodan1 && radnik[redosled[i]].probacdslobodan == 0) { radnik[redosled[i]].probacdslobodan = 3; slobodan1 = false; popunjeno++; continue; }
                    if (slobodan2 && radnik[redosled[i]].probacdslobodan == 0) { radnik[redosled[i]].probacdslobodan = 3; slobodan2 = false; popunjeno++; continue; }
                }
            }
            while (popunjeno+godisnjiodmor!=9);
            SledecaNedelja();
        }
        void Probaj1()
        {
            GodisnjiOdmor();
            do
            {
                Reset();
                for (int i = 0; i < 9; i++)
                {
                    if (clbRadioMagnet.GetItemCheckState(i) == CheckState.Checked) radnik[i].cdmagnet = 2;
                    if (clbRadioSkener.GetItemCheckState(i) == CheckState.Checked) radnik[i].cdskener = 2;
                    if (clbRadioKlasicnu.GetItemCheckState(i) == CheckState.Checked) radnik[i].cdklasicna = 2;
                    if (clbBioSlobodan.GetItemCheckState(i) == CheckState.Checked) radnik[i].cdslobodan = 2;
                    switch (radnik[i].ime)
                    {
                        case "Ljilja":
                            if (Convert.ToInt32(tbLjilja.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbLjilja.Text);
                            else radnik[i].cdsala = 0;
                            break;
                        case "Jelena":
                            if (Convert.ToInt32(tbJelena.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbJelena.Text);
                            else radnik[i].cdsala = 0;
                            break;
                        case "Ivan":
                            if (Convert.ToInt32(tbIvan.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbIvan.Text);
                            else radnik[i].cdsala = 0;
                            break;
                        case "Beki":
                            if (Convert.ToInt32(tbBeki.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbBeki.Text);
                            else radnik[i].cdsala = 0;
                            break;
                        case "Sandra":
                            if (Convert.ToInt32(tbSandra.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbSandra.Text);
                            else radnik[i].cdsala = 0;
                            break;
                        case "Jasmina":
                            if (Convert.ToInt32(tbJasmina.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbJasmina.Text);
                            else radnik[i].cdsala = 0;
                            break;
                        case "Ana":
                            if (Convert.ToInt32(tbAna.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbAna.Text);
                            else radnik[i].cdsala = 0;
                            break;
                        case "Viktorija":
                            if (Convert.ToInt32(tbViktorija.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbViktorija.Text);
                            else radnik[i].cdsala = 0;
                            break;
                        case "Dragana":
                            if (Convert.ToInt32(tbDragana.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbDragana.Text);
                            else radnik[i].cdsala = 0;
                            break;
                    }

                }
                for (int i = 0; i < 9; i++)
                {
                    radnik[i].probacdsala = radnik[i].cdsala;
                    radnik[i].probacdmagnet = radnik[i].cdmagnet;
                    radnik[i].probacdskener = radnik[i].cdskener;
                    radnik[i].probacdklasicna = radnik[i].cdklasicna;
                    radnik[i].probacdslobodan = radnik[i].cdslobodan;
                }
                redosled = brojevi.OrderBy(x => rng.Next()).ToArray();
                for (int i = 0; i < 9; i++)
                {
                    if (radnik[redosled[i]].godisnjiodmor) { godisnjiodmor++; continue; }
                    if (salasok && radnik[redosled[i]].probacdsala == 0) { radnik[redosled[i]].probacdsala = salacd; salasok = false; popunjeno++; continue; }
                    if (magnet1 && radnik[redosled[i]].probacdmagnet == 0) { radnik[redosled[i]].probacdmagnet = 3; magnet1 = false; popunjeno++; continue; }
                    if (skener1 && radnik[redosled[i]].probacdskener == 0) { radnik[redosled[i]].probacdskener = 3; skener1 = false; popunjeno++; continue; }
                    if (klasicna1 && radnik[redosled[i]].probacdklasicna == 0) { radnik[redosled[i]].probacdklasicna = 3; klasicna1 = false; popunjeno++; continue; }
                    if (magnet2 && radnik[redosled[i]].probacdmagnet == 0) { radnik[redosled[i]].probacdmagnet = 3; magnet2 = false; popunjeno++; continue; }
                    if (skener2 && radnik[redosled[i]].probacdskener == 0) { radnik[redosled[i]].probacdskener = 3; skener2 = false; popunjeno++; continue; }
                    if (klasicna2 && radnik[redosled[i]].probacdklasicna == 0) { radnik[redosled[i]].probacdklasicna = 3; klasicna2 = false; popunjeno++; continue; }
                    if (slobodan1 && radnik[redosled[i]].probacdslobodan == 0) { radnik[redosled[i]].probacdslobodan = 3; slobodan1 = false; popunjeno++; continue; }
                    if (slobodan2 && radnik[redosled[i]].probacdslobodan == 0) { radnik[redosled[i]].probacdslobodan = 3; slobodan2 = false; popunjeno++; continue; }
                }
            }
            while (popunjeno + godisnjiodmor != 9);
            Ucitaj();
        }
        void SledecaNedelja()
        {
            Reset();
            for (int i = 0; i < 9; i++)
            {
                if (radnik[redosled[i]].cdklasicna != 0) radnik[redosled[i]].cdklasicna--;
                if (radnik[redosled[i]].cdskener != 0) radnik[redosled[i]].cdskener--;
                if (radnik[redosled[i]].cdmagnet != 0) radnik[redosled[i]].cdmagnet--;
                if (radnik[redosled[i]].cdslobodan != 0) radnik[redosled[i]].cdslobodan--;
                if (radnik[redosled[i]].cdsala != 0) radnik[redosled[i]].cdsala--;
            }
            for (int i = 0; i < 9; i++)
            {
                if (radnik[redosled[i]].godisnjiodmor) { godisnjiodmor++; continue; }
                if (salasok && radnik[redosled[i]].cdsala == 0) { radnik[redosled[i]].cdsala = salacd; salasok = false; lblSala.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (magnet1 && radnik[redosled[i]].cdmagnet == 0) { radnik[redosled[i]].cdmagnet = 3; magnet1 = false; lblMagnet1.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (skener1 && radnik[redosled[i]].cdskener == 0) { radnik[redosled[i]].cdskener = 3; skener1 = false; lblSkener1.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (klasicna1 && radnik[redosled[i]].cdklasicna == 0) { radnik[redosled[i]].cdklasicna = 3; klasicna1 = false; lblKlasicna1.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (magnet2 && radnik[redosled[i]].cdmagnet == 0) { radnik[redosled[i]].cdmagnet = 3; magnet2 = false; lblMagnet2.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (skener2 && radnik[redosled[i]].cdskener == 0) { radnik[redosled[i]].cdskener = 3; skener2 = false; lblSkener2.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (klasicna2 && radnik[redosled[i]].cdklasicna == 0) { radnik[redosled[i]].cdklasicna = 3; klasicna2 = false; lblKlasicna2.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (slobodan1 && radnik[redosled[i]].cdslobodan == 0) { radnik[redosled[i]].cdslobodan = 3; slobodan1 = false; lblSlobodan1.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (slobodan2 && radnik[redosled[i]].cdslobodan == 0) { radnik[redosled[i]].cdslobodan = 3; slobodan2 = false; lblSlobodan2.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
            }
            

        }
        void Ucitaj()
        {
            Reset();
            for(int i = 0; i < 9; i++)
            {
                if (clbGodisnjiOdmor.GetItemCheckState(i) == CheckState.Checked) radnik[i].godisnjiodmor = true;
                if (clbRadioMagnet.GetItemCheckState(i) == CheckState.Checked) radnik[i].cdmagnet = 2;
                if (clbRadioSkener.GetItemCheckState(i) == CheckState.Checked) radnik[i].cdskener = 2;
                if (clbRadioKlasicnu.GetItemCheckState(i) == CheckState.Checked) radnik[i].cdklasicna = 2;
                if (clbBioSlobodan.GetItemCheckState(i) == CheckState.Checked) radnik[i].cdslobodan = 2;
                switch (radnik[i].ime)
                {
                    case "Ljilja":
                        if (Convert.ToInt32(tbLjilja.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbLjilja.Text);
                        else radnik[i].cdsala = 0;
                        break;
                    case "Jelena":
                        if (Convert.ToInt32(tbJelena.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbJelena.Text);
                        else radnik[i].cdsala = 0;
                        break;
                    case "Ivan":
                        if (Convert.ToInt32(tbIvan.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbIvan.Text);
                        else radnik[i].cdsala = 0;
                        break;
                    case "Beki":
                        if (Convert.ToInt32(tbBeki.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbBeki.Text);
                        else radnik[i].cdsala = 0;
                        break;
                    case "Sandra":
                        if (Convert.ToInt32(tbSandra.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbSandra.Text);
                        else radnik[i].cdsala = 0;
                        break;
                    case "Jasmina":
                        if (Convert.ToInt32(tbJasmina.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbJasmina.Text);
                        else radnik[i].cdsala = 0;
                        break;
                    case "Ana":
                        if (Convert.ToInt32(tbAna.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbAna.Text);
                        else radnik[i].cdsala = 0;
                        break;
                    case "Viktorija":
                        if (Convert.ToInt32(tbViktorija.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbViktorija.Text);
                        else radnik[i].cdsala = 0;
                        break;
                    case "Dragana":
                        if (Convert.ToInt32(tbDragana.Text) > 0) radnik[i].cdsala = salacd - Convert.ToInt32(tbDragana.Text);
                        else radnik[i].cdsala = 0;
                        break;
                }
                     
            }
            for(int i = 0; i < 9; i++)
            {
                if (radnik[redosled[i]].godisnjiodmor) { godisnjiodmor++; continue; }
                if (salasok && radnik[redosled[i]].cdsala == 0) { radnik[redosled[i]].cdsala = salacd; salasok = false; lblSala.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (magnet1 && radnik[redosled[i]].cdmagnet == 0) { radnik[redosled[i]].cdmagnet = 3; magnet1 = false; lblMagnet1.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (skener1 && radnik[redosled[i]].cdskener == 0) { radnik[redosled[i]].cdskener = 3; skener1 = false; lblSkener1.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (klasicna1 && radnik[redosled[i]].cdklasicna == 0) { radnik[redosled[i]].cdklasicna = 3; klasicna1 = false; lblKlasicna1.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (magnet2 && radnik[redosled[i]].cdmagnet == 0) { radnik[redosled[i]].cdmagnet = 3; magnet2 = false; lblMagnet2.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (skener2 && radnik[redosled[i]].cdskener == 0) { radnik[redosled[i]].cdskener = 3; skener2 = false; lblSkener2.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (klasicna2 && radnik[redosled[i]].cdklasicna == 0) { radnik[redosled[i]].cdklasicna = 3; klasicna2 = false; lblKlasicna2.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (slobodan1 && radnik[redosled[i]].cdslobodan == 0) { radnik[redosled[i]].cdslobodan = 3; slobodan1 = false; lblSlobodan1.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
                if (slobodan2 && radnik[redosled[i]].cdslobodan == 0) { radnik[redosled[i]].cdslobodan = 3; slobodan2 = false; lblSlobodan2.Text = radnik[redosled[i]].ime; popunjeno++; continue; }
            }
            
        }

        public class Radnik
        {
            public string ime { get; set; }
            public int cdmagnet { get; set; }
            public int cdskener { get; set; }
            public int cdklasicna { get; set; }
            public int cdsala { get; set; }
            public int cdslobodan { get; set; }
            public int probacdmagnet { get; set; }
            public int probacdskener { get; set; }
            public int probacdklasicna { get; set; }
            public int probacdsala { get; set; }
            public int probacdslobodan { get; set; }
            public bool godisnjiodmor { get; set; }
        }
    }
}
