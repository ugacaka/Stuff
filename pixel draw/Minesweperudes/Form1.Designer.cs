using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Minesweperudes
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
            this.ClientSize = new System.Drawing.Size(311, 311);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Minesweperudes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            

        }

        #endregion
    }
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            Visible = true;
            BackColor = System.Drawing.Color.DarkGray;
            Enabled = true;
            Size = new Size(118, 155);
            Location = new Point(620, 401);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "Form2";
            Text = "Options";
            ResumeLayout(false);

            lbl1 = new Label();
            lbl1.Visible = true;
            lbl1.Text = "Sirina";
            lbl1.Location = new Point(1, 5);
            lbl1.Size = new Size(45, 20);
            Controls.Add(lbl1);

            tbSirina = new TextBox();
            tbSirina.Visible = true;
            tbSirina.Enabled = true;
            tbSirina.Location = new Point(47, 1);
            tbSirina.Size = new Size(70, 10);
            tbSirina.BackColor = Color.White;
            Controls.Add(tbSirina);

            lbl2 = new Label();
            lbl2.Visible = true;
            lbl2.Text = "Duzina";
            lbl2.Location = new Point(1, 26);
            lbl2.Size = new Size(45, 20);
            Controls.Add(lbl2);

            tbDuzina = new TextBox();
            tbDuzina.Visible = true;
            tbDuzina.Enabled = true;
            tbDuzina.Location = new Point(47, 22);
            tbDuzina.Size = new Size(70, 10);
            tbDuzina.BackColor = Color.White;
            Controls.Add(tbDuzina);

            lbl3 = new Label();
            lbl3.Visible = true;
            lbl3.Text = "Redovi";
            lbl3.Location = new Point(1, 47);
            lbl3.Size = new Size(45, 20);
            Controls.Add(lbl3);

            tbRedovi = new TextBox();
            tbRedovi.Visible = true;
            tbRedovi.Enabled = true;
            tbRedovi.Location = new Point(47, 43);
            tbRedovi.Size = new Size(70, 10);
            tbRedovi.BackColor = Color.White;
            Controls.Add(tbRedovi);

            lbl4 = new Label();
            lbl4.Visible = true;
            lbl4.Text = "Kolone";
            lbl4.Location = new Point(1, 68);
            lbl4.Size = new Size(45, 20);
            Controls.Add(lbl4);

            tbKolone = new TextBox();
            tbKolone.Visible = true;
            tbKolone.Enabled = true;
            tbKolone.Location = new Point(47, 64);
            tbKolone.Size = new Size(70, 10);
            tbKolone.BackColor = Color.White;
            Controls.Add(tbKolone);

            bt1 = new Button();
            bt1.Visible = true;
            bt1.Enabled = true;
            bt1.Text = "Go";
            bt1.Location = new Point(23, 88);
            bt1.UseVisualStyleBackColor = true;
            bt1.Click += new EventHandler(button1_Click);
            Controls.Add(bt1);
            

        }
        TextBox tbSirina, tbDuzina, tbRedovi, tbKolone;
        Button bt1;
        Label lbl1, lbl2, lbl3, lbl4;
    }
}

