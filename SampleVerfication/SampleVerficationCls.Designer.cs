namespace SampleVerfication
{
    partial class SampleVerficationCls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHeader = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelZ2 = new System.Windows.Forms.Label();
            this.labelZ1 = new System.Windows.Forms.Label();
            this.labelMisBdika = new System.Windows.Forms.Label();
            this.timerFocus = new System.Windows.Forms.Timer(this.components);
            this.labelResult = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblHeader.Location = new System.Drawing.Point(543, 11);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(412, 84);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "אימות דגימה";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(531, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 35);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeDown);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(58, 68);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 35);
            this.textBox2.TabIndex = 2;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(598, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "צנצנת 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(123, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 43);
            this.label2.TabIndex = 4;
            this.label2.Text = "צנצנת 2";
            // 
            // labelZ2
            // 
            this.labelZ2.AutoSize = true;
            this.labelZ2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelZ2.ForeColor = System.Drawing.Color.Red;
            this.labelZ2.Location = new System.Drawing.Point(113, 106);
            this.labelZ2.Name = "labelZ2";
            this.labelZ2.Size = new System.Drawing.Size(169, 32);
            this.labelZ2.TabIndex = 9;
            this.labelZ2.Text = "ברקוד לא תקין";
            this.labelZ2.Visible = false;
            // 
            // labelZ1
            // 
            this.labelZ1.AutoSize = true;
            this.labelZ1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelZ1.ForeColor = System.Drawing.Color.Red;
            this.labelZ1.Location = new System.Drawing.Point(598, 106);
            this.labelZ1.Name = "labelZ1";
            this.labelZ1.Size = new System.Drawing.Size(154, 32);
            this.labelZ1.TabIndex = 10;
            this.labelZ1.Text = "המקרה בוטל";
            this.labelZ1.Visible = false;
            // 
            // labelMisBdika
            // 
            this.labelMisBdika.AutoSize = true;
            this.labelMisBdika.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMisBdika.Location = new System.Drawing.Point(263, 200);
            this.labelMisBdika.Name = "labelMisBdika";
            this.labelMisBdika.Size = new System.Drawing.Size(0, 44);
            this.labelMisBdika.TabIndex = 11;
            // 
            // timerFocus
            // 
            this.timerFocus.Interval = 5000;
            this.timerFocus.Tick += new System.EventHandler(this.timerFocus_Tick);
            // 
            // labelResult
            // 
            this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResult.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelResult.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelResult.ForeColor = System.Drawing.Color.Red;
            this.labelResult.Location = new System.Drawing.Point(58, 257);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(673, 77);
            this.labelResult.TabIndex = 12;
            this.labelResult.Text = "אימות נכשל ";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelMisBdika);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelResult);
            this.panel1.Controls.Add(this.labelZ1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.labelZ2);
            this.panel1.Location = new System.Drawing.Point(257, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 372);
            this.panel1.TabIndex = 13;
            // 
            // SampleVerficationCls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SampleVerficationCls";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1366, 765);
            this.Resize += new System.EventHandler(this.SampleVerficationCls_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }





        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelZ2;
        private System.Windows.Forms.Label labelZ1;
        private System.Windows.Forms.Label labelMisBdika;
        private System.Windows.Forms.Timer timerFocus;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Panel panel1;
    }
}
