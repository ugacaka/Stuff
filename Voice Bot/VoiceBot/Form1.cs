using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace VoiceBot
{
    public partial class Voice : Form
    {
        SpeechSynthesizer voiceBot = new SpeechSynthesizer();
        bool pause = false;
        public Voice()
        {
            InitializeComponent();
            voiceBot.SelectVoiceByHints(VoiceGender.Male);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void btVoice_Click(object sender, EventArgs e)
        {
            if (!pause) voiceBot.SpeakAsync(tbVoice.Text.ToString()); else { pause = false; btPause.Text = "Pause"; voiceBot.Resume(); voiceBot.SpeakAsyncCancelAll(); voiceBot.SpeakAsync(tbVoice.Text.ToString()); }
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            if (!pause) { voiceBot.Pause(); pause = true; btPause.Text = "Resume"; } else { voiceBot.Resume(); pause = false; btPause.Text = "Pause"; }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            voiceBot.SpeakAsyncCancelAll();
            pause = false;
            btPause.Text = "Pause";
            voiceBot.Resume();
        }

        private void femaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (femaleToolStripMenuItem.Checked)
            {
                maleToolStripMenuItem.Checked = false;
                maleToolStripMenuItem.CheckState = CheckState.Unchecked;
                voiceBot.SelectVoiceByHints(VoiceGender.Female);
                femaleToolStripMenuItem.CheckState = CheckState.Checked;
                femaleToolStripMenuItem.Checked = true;
            }
        }

        private void maleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (maleToolStripMenuItem.Checked)
            {
                femaleToolStripMenuItem.Checked = false;
                femaleToolStripMenuItem.CheckState = CheckState.Unchecked;
                voiceBot.SelectVoiceByHints(VoiceGender.Male);
                maleToolStripMenuItem.CheckState = CheckState.Checked;
                maleToolStripMenuItem.Checked = true;
            }
        }

        
    }
}
