﻿namespace ObliciCrtanje
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
            this.components = new System.ComponentModel.Container();
            this.pozadina = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pozadina
            // 
            this.pozadina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pozadina.Location = new System.Drawing.Point(0, 0);
            this.pozadina.Name = "pozadina";
            this.pozadina.Size = new System.Drawing.Size(800, 451);
            this.pozadina.TabIndex = 0;
            this.pozadina.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pozadina_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.pozadina);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pozadina;
    }
}

