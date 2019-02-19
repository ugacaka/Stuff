namespace passwordcrack2._0
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
        private void InitializeComponent()
        {
            this.tbSifra = new System.Windows.Forms.TextBox();
            this.btConvertuj = new System.Windows.Forms.Button();
            this.btDektriptuj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSifra
            // 
            this.tbSifra.Location = new System.Drawing.Point(99, 91);
            this.tbSifra.Name = "tbSifra";
            this.tbSifra.Size = new System.Drawing.Size(100, 20);
            this.tbSifra.TabIndex = 0;
            // 
            // btConvertuj
            // 
            this.btConvertuj.Location = new System.Drawing.Point(327, 87);
            this.btConvertuj.Name = "btConvertuj";
            this.btConvertuj.Size = new System.Drawing.Size(75, 23);
            this.btConvertuj.TabIndex = 1;
            this.btConvertuj.Text = "To 10";
            this.btConvertuj.UseVisualStyleBackColor = true;
            this.btConvertuj.Click += new System.EventHandler(this.btConvertuj_Click);
            // 
            // btDektriptuj
            // 
            this.btDektriptuj.Location = new System.Drawing.Point(327, 139);
            this.btDektriptuj.Name = "btDektriptuj";
            this.btDektriptuj.Size = new System.Drawing.Size(75, 23);
            this.btDektriptuj.TabIndex = 2;
            this.btDektriptuj.Text = "To 36";
            this.btDektriptuj.UseVisualStyleBackColor = true;
            this.btDektriptuj.Click += new System.EventHandler(this.btDektriptuj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btDektriptuj);
            this.Controls.Add(this.btConvertuj);
            this.Controls.Add(this.tbSifra);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSifra;
        private System.Windows.Forms.Button btConvertuj;
        private System.Windows.Forms.Button btDektriptuj;
    }
}

