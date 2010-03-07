namespace WindowsFormsApplication1
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.monospaceButton1 = new MinimalUI.MonospaceButton();
            this.monospaceProgressBar1 = new MinimalUI.MonospaceProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 38);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1ValueChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(646, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 304);
            this.vScrollBar1.TabIndex = 3;
            // 
            // monospaceButton1
            // 
            this.monospaceButton1.ButtonScale = 16;
            this.monospaceButton1.Location = new System.Drawing.Point(501, 279);
            this.monospaceButton1.Name = "monospaceButton1";
            this.monospaceButton1.Size = new System.Drawing.Size(142, 13);
            this.monospaceButton1.TabIndex = 4;
            this.monospaceButton1.Text = "Exit";
            this.monospaceButton1.Click += new System.EventHandler(this.MonospaceButton1Click);
            // 
            // monospaceProgressBar1
            // 
            this.monospaceProgressBar1.BarScale = 70;
            this.monospaceProgressBar1.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
            this.monospaceProgressBar1.Location = new System.Drawing.Point(13, 12);
            this.monospaceProgressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.monospaceProgressBar1.Name = "monospaceProgressBar1";
            this.monospaceProgressBar1.Size = new System.Drawing.Size(588, 13);
            this.monospaceProgressBar1.TabIndex = 2;
            this.monospaceProgressBar1.Value = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(663, 304);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.monospaceButton1);
            this.Controls.Add(this.monospaceProgressBar1);
            this.Controls.Add(this.numericUpDown1);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Name = "Form1";
            this.Text = "Not Console";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private MinimalUI.MonospaceProgressBar monospaceProgressBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private MinimalUI.MonospaceButton monospaceButton1;

    }
}

