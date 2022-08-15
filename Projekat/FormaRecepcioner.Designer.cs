namespace Projekat
{
    partial class FormaRecepcioner
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
            this.lbRezervacije = new System.Windows.Forms.ListBox();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnRezervisi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbRezervacije
            // 
            this.lbRezervacije.FormattingEnabled = true;
            this.lbRezervacije.Location = new System.Drawing.Point(81, 12);
            this.lbRezervacije.Name = "lbRezervacije";
            this.lbRezervacije.Size = new System.Drawing.Size(384, 251);
            this.lbRezervacije.TabIndex = 0;
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(81, 269);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(141, 23);
            this.btnObrisi.TabIndex = 1;
            this.btnObrisi.Text = "Obriši rezervaciju";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Location = new System.Drawing.Point(324, 269);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(141, 23);
            this.btnIzmeni.TabIndex = 2;
            this.btnIzmeni.Text = "Izmeni rezervaciju";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnRezervisi
            // 
            this.btnRezervisi.Location = new System.Drawing.Point(205, 309);
            this.btnRezervisi.Name = "btnRezervisi";
            this.btnRezervisi.Size = new System.Drawing.Size(141, 23);
            this.btnRezervisi.TabIndex = 3;
            this.btnRezervisi.Text = "Rezerviši";
            this.btnRezervisi.UseVisualStyleBackColor = true;
            this.btnRezervisi.Click += new System.EventHandler(this.btnRezervisi_Click);
            // 
            // FormaRecepcioner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 365);
            this.Controls.Add(this.btnRezervisi);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.lbRezervacije);
            this.Name = "FormaRecepcioner";
            this.Text = "FormaRecepcioner";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormaRecepcioner_FormClosed);
            this.Load += new System.EventHandler(this.FormaRecepcioner_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbRezervacije;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnRezervisi;
    }
}