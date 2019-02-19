using System.Drawing;
namespace poisonuuu
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
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Text = "Form1";
            this.bt1.Click += new System.EventHandler(this.Bt1_Click);
            this.ResumeLayout(false);
            this.BackColor = System.Drawing.Color.Gray;
            //
            // tbBrojpoteza
            //
            tbBrojpoteza.Name = "tbBrojpoteza";
            tbBrojpoteza.Visible = true;
            tbBrojpoteza.Enabled = true;
            tbBrojpoteza.Location = new System.Drawing.Point(15,15);
            tbBrojpoteza.Text = "0";
            tbBrojpoteza.Size = new System.Drawing.Size(30,10);
            this.Controls.Add(tbBrojpoteza);
            //
            // bt1
            //
            bt1.Name = "bt1";
            bt1.Visible = true;
            bt1.Enabled = true;
            bt1.BackColor = Color.Transparent;
            bt1.ForeColor = Color.White;
            bt1.Location = new Point(15,70);
            bt1.Text = "Go";
            this.Controls.Add(bt1);
        }
        
        #endregion
    }
    
}

