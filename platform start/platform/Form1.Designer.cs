namespace platform
{
    partial class platform
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
            this.components = new System.ComponentModel.Container();
            this.Vreme = new System.Windows.Forms.Timer(this.components);
            this.pozadina = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Vreme
            // 
            this.Vreme.Enabled = true;
            this.Vreme.Interval = 1;
            this.Vreme.Tick += new System.EventHandler(this.Vreme_Tick);
            // 
            // pozadina
            // 
            this.pozadina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pozadina.Location = new System.Drawing.Point(0, 0);
            this.pozadina.Name = "pozadina";
            this.pozadina.Size = new System.Drawing.Size(800, 400);
            this.pozadina.TabIndex = 0;
            // 
            // platform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.pozadina);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "platform";
            this.ShowIcon = false;
            this.Text = "Platform";
            this.Load += new System.EventHandler(this.Platform_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.platform_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.platform_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer Vreme;
        private System.Windows.Forms.Panel pozadina;
    }
}

