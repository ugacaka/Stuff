namespace passwordcrack
{
    partial class Form1
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
        public void InitializeComponent()
        {
            this.btCrack = new System.Windows.Forms.Button();
            this.tbSifra = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btCrack
            // 
            this.btCrack.Location = new System.Drawing.Point(178, 36);
            this.btCrack.Name = "btCrack";
            this.btCrack.Size = new System.Drawing.Size(75, 23);
            this.btCrack.TabIndex = 0;
            this.btCrack.Text = "Crack";
            this.btCrack.UseVisualStyleBackColor = true;
            this.btCrack.Click += new System.EventHandler(this.btCrack_Click);
            // 
            // tbSifra
            // 
            this.tbSifra.Location = new System.Drawing.Point(41, 38);
            this.tbSifra.Name = "tbSifra";
            this.tbSifra.Size = new System.Drawing.Size(100, 20);
            this.tbSifra.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 111);
            this.Controls.Add(this.tbSifra);
            this.Controls.Add(this.btCrack);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCrack;
        private System.Windows.Forms.TextBox tbSifra;
    }
}

