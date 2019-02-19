namespace Titanium_counter
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
            this.tbTO = new System.Windows.Forms.TextBox();
            this.tbSO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblTB = new System.Windows.Forms.Label();
            this.bt1 = new System.Windows.Forms.Button();
            this.tbSB = new System.Windows.Forms.TextBox();
            this.tbTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbTO
            // 
            this.tbTO.Location = new System.Drawing.Point(121, 64);
            this.tbTO.Name = "tbTO";
            this.tbTO.Size = new System.Drawing.Size(100, 20);
            this.tbTO.TabIndex = 0;
            this.tbTO.Text = "0";
            // 
            // tbSO
            // 
            this.tbSO.Location = new System.Drawing.Point(121, 12);
            this.tbSO.Name = "tbSO";
            this.tbSO.Size = new System.Drawing.Size(100, 20);
            this.tbSO.TabIndex = 1;
            this.tbSO.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Saronite ore";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Titanium ore";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Titanium bars";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "No. Choppers";
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Location = new System.Drawing.Point(129, 164);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(0, 13);
            this.lblC.TabIndex = 6;
            // 
            // lblTB
            // 
            this.lblTB.AutoSize = true;
            this.lblTB.Location = new System.Drawing.Point(127, 142);
            this.lblTB.Name = "lblTB";
            this.lblTB.Size = new System.Drawing.Size(0, 13);
            this.lblTB.TabIndex = 7;
            // 
            // bt1
            // 
            this.bt1.Location = new System.Drawing.Point(130, 195);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(75, 23);
            this.bt1.TabIndex = 8;
            this.bt1.Text = "Calculate";
            this.bt1.UseVisualStyleBackColor = true;
            this.bt1.Click += new System.EventHandler(this.bt1_Click);
            // 
            // tbSB
            // 
            this.tbSB.Location = new System.Drawing.Point(121, 38);
            this.tbSB.Name = "tbSB";
            this.tbSB.Size = new System.Drawing.Size(100, 20);
            this.tbSB.TabIndex = 10;
            this.tbSB.Text = "0";
            // 
            // tbTB
            // 
            this.tbTB.Location = new System.Drawing.Point(121, 90);
            this.tbTB.Name = "tbTB";
            this.tbTB.Size = new System.Drawing.Size(100, 20);
            this.tbTB.TabIndex = 11;
            this.tbTB.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Saronite bar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Titanium bar";
            // 
            // cbTB
            // 
            this.cbTB.AutoSize = true;
            this.cbTB.Location = new System.Drawing.Point(121, 116);
            this.cbTB.Name = "cbTB";
            this.cbTB.Size = new System.Drawing.Size(97, 17);
            this.cbTB.TabIndex = 14;
            this.cbTB.Text = "Transmute buff";
            this.cbTB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cbTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTB);
            this.Controls.Add(this.tbSB);
            this.Controls.Add(this.bt1);
            this.Controls.Add(this.lblTB);
            this.Controls.Add(this.lblC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSO);
            this.Controls.Add(this.tbTO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Titanium counter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTO;
        private System.Windows.Forms.TextBox tbSO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblTB;
        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.TextBox tbSB;
        private System.Windows.Forms.TextBox tbTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbTB;
    }
}

