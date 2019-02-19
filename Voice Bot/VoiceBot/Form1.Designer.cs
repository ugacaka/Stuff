namespace VoiceBot
{
    partial class Voice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Voice));
            this.tbVoice = new System.Windows.Forms.TextBox();
            this.btVoice = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.changeVoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.femaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbVoice
            // 
            this.tbVoice.AllowDrop = true;
            this.tbVoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVoice.Location = new System.Drawing.Point(13, 27);
            this.tbVoice.Multiline = true;
            this.tbVoice.Name = "tbVoice";
            this.tbVoice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbVoice.Size = new System.Drawing.Size(260, 130);
            this.tbVoice.TabIndex = 0;
            // 
            // btVoice
            // 
            this.btVoice.Location = new System.Drawing.Point(12, 196);
            this.btVoice.Name = "btVoice";
            this.btVoice.Size = new System.Drawing.Size(75, 23);
            this.btVoice.TabIndex = 1;
            this.btVoice.Text = "Speak";
            this.btVoice.UseVisualStyleBackColor = true;
            this.btVoice.Click += new System.EventHandler(this.btVoice_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(226, 196);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(47, 23);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(173, 196);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(47, 23);
            this.btPause.TabIndex = 3;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeVoiceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // changeVoiceToolStripMenuItem
            // 
            this.changeVoiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.femaleToolStripMenuItem,
            this.maleToolStripMenuItem});
            this.changeVoiceToolStripMenuItem.Name = "changeVoiceToolStripMenuItem";
            this.changeVoiceToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.changeVoiceToolStripMenuItem.Text = "Change voice";
            // 
            // femaleToolStripMenuItem
            // 
            this.femaleToolStripMenuItem.CheckOnClick = true;
            this.femaleToolStripMenuItem.Name = "femaleToolStripMenuItem";
            this.femaleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.femaleToolStripMenuItem.Text = "Female";
            this.femaleToolStripMenuItem.Click += new System.EventHandler(this.femaleToolStripMenuItem_Click);
            // 
            // maleToolStripMenuItem
            // 
            this.maleToolStripMenuItem.Checked = true;
            this.maleToolStripMenuItem.CheckOnClick = true;
            this.maleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.maleToolStripMenuItem.Name = "maleToolStripMenuItem";
            this.maleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.maleToolStripMenuItem.Text = "Male";
            this.maleToolStripMenuItem.Click += new System.EventHandler(this.maleToolStripMenuItem_Click);
            // 
            // Voice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btVoice);
            this.Controls.Add(this.tbVoice);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Voice";
            this.Text = "Voice Bot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbVoice;
        private System.Windows.Forms.Button btVoice;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changeVoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem femaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maleToolStripMenuItem;
    }
}

