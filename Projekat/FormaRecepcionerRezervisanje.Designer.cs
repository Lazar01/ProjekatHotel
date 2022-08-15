
namespace Projekat
{
    partial class FormaRecepcionerRezervisanje
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
            this.lbGosti = new System.Windows.Forms.ListBox();
            this.btnDodajGosta = new System.Windows.Forms.Button();
            this.btnIzaberiGosta = new System.Windows.Forms.Button();
            this.txtImeGosta = new System.Windows.Forms.TextBox();
            this.txtPrezimeGosta = new System.Windows.Forms.TextBox();
            this.txtTelefonGosta = new System.Windows.Forms.TextBox();
            this.dtpDatRodj = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDatumOd = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumDo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBrKreveta = new System.Windows.Forms.ComboBox();
            this.cmbTipSobe = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbSlobodneSobe = new System.Windows.Forms.ListBox();
            this.btnSacuvajRez = new System.Windows.Forms.Button();
            this.txtUkupnaCena = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTipRez = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbGosti
            // 
            this.lbGosti.FormattingEnabled = true;
            this.lbGosti.Location = new System.Drawing.Point(12, 12);
            this.lbGosti.Name = "lbGosti";
            this.lbGosti.Size = new System.Drawing.Size(248, 225);
            this.lbGosti.TabIndex = 0;
            // 
            // btnDodajGosta
            // 
            this.btnDodajGosta.Location = new System.Drawing.Point(74, 268);
            this.btnDodajGosta.Name = "btnDodajGosta";
            this.btnDodajGosta.Size = new System.Drawing.Size(115, 38);
            this.btnDodajGosta.TabIndex = 1;
            this.btnDodajGosta.Text = "Dodaj novog gosta";
            this.btnDodajGosta.UseVisualStyleBackColor = true;
            this.btnDodajGosta.Click += new System.EventHandler(this.btnDodajGosta_Click);
            // 
            // btnIzaberiGosta
            // 
            this.btnIzaberiGosta.Enabled = false;
            this.btnIzaberiGosta.Location = new System.Drawing.Point(302, 268);
            this.btnIzaberiGosta.Name = "btnIzaberiGosta";
            this.btnIzaberiGosta.Size = new System.Drawing.Size(115, 38);
            this.btnIzaberiGosta.TabIndex = 2;
            this.btnIzaberiGosta.Text = "Izaberi gosta";
            this.btnIzaberiGosta.UseVisualStyleBackColor = true;
            this.btnIzaberiGosta.Click += new System.EventHandler(this.btnIzaberiGosta_Click);
            // 
            // txtImeGosta
            // 
            this.txtImeGosta.Enabled = false;
            this.txtImeGosta.Location = new System.Drawing.Point(310, 24);
            this.txtImeGosta.Name = "txtImeGosta";
            this.txtImeGosta.Size = new System.Drawing.Size(100, 20);
            this.txtImeGosta.TabIndex = 3;
            // 
            // txtPrezimeGosta
            // 
            this.txtPrezimeGosta.Enabled = false;
            this.txtPrezimeGosta.Location = new System.Drawing.Point(310, 87);
            this.txtPrezimeGosta.Name = "txtPrezimeGosta";
            this.txtPrezimeGosta.Size = new System.Drawing.Size(100, 20);
            this.txtPrezimeGosta.TabIndex = 5;
            // 
            // txtTelefonGosta
            // 
            this.txtTelefonGosta.Enabled = false;
            this.txtTelefonGosta.Location = new System.Drawing.Point(310, 207);
            this.txtTelefonGosta.Name = "txtTelefonGosta";
            this.txtTelefonGosta.Size = new System.Drawing.Size(100, 20);
            this.txtTelefonGosta.TabIndex = 6;
            // 
            // dtpDatRodj
            // 
            this.dtpDatRodj.Enabled = false;
            this.dtpDatRodj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatRodj.Location = new System.Drawing.Point(310, 149);
            this.dtpDatRodj.Name = "dtpDatRodj";
            this.dtpDatRodj.Size = new System.Drawing.Size(107, 20);
            this.dtpDatRodj.TabIndex = 7;
            this.dtpDatRodj.Value = new System.DateTime(2022, 8, 14, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Prezime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Datum rođenja";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Telefon";
            // 
            // dtpDatumOd
            // 
            this.dtpDatumOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumOd.Location = new System.Drawing.Point(12, 353);
            this.dtpDatumOd.Name = "dtpDatumOd";
            this.dtpDatumOd.Size = new System.Drawing.Size(84, 20);
            this.dtpDatumOd.TabIndex = 12;
            this.dtpDatumOd.ValueChanged += new System.EventHandler(this.dtpDatumOd_ValueChanged);
            // 
            // dtpDatumDo
            // 
            this.dtpDatumDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumDo.Location = new System.Drawing.Point(12, 399);
            this.dtpDatumDo.Name = "dtpDatumDo";
            this.dtpDatumDo.Size = new System.Drawing.Size(84, 20);
            this.dtpDatumDo.TabIndex = 13;
            this.dtpDatumDo.ValueChanged += new System.EventHandler(this.dtpDatumDo_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Datum od";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Datum do";
            // 
            // cmbBrKreveta
            // 
            this.cmbBrKreveta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrKreveta.FormattingEnabled = true;
            this.cmbBrKreveta.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbBrKreveta.Location = new System.Drawing.Point(113, 351);
            this.cmbBrKreveta.Name = "cmbBrKreveta";
            this.cmbBrKreveta.Size = new System.Drawing.Size(76, 21);
            this.cmbBrKreveta.TabIndex = 16;
            this.cmbBrKreveta.SelectedIndexChanged += new System.EventHandler(this.cmbBrKreveta_SelectedIndexChanged);
            // 
            // cmbTipSobe
            // 
            this.cmbTipSobe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipSobe.FormattingEnabled = true;
            this.cmbTipSobe.Items.AddRange(new object[] {
            "lux",
            "standard"});
            this.cmbTipSobe.Location = new System.Drawing.Point(113, 399);
            this.cmbTipSobe.Name = "cmbTipSobe";
            this.cmbTipSobe.Size = new System.Drawing.Size(76, 21);
            this.cmbTipSobe.TabIndex = 17;
            this.cmbTipSobe.SelectedIndexChanged += new System.EventHandler(this.cmbTipSobe_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Broj kreveta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tip sobe";
            // 
            // lbSlobodneSobe
            // 
            this.lbSlobodneSobe.FormattingEnabled = true;
            this.lbSlobodneSobe.Location = new System.Drawing.Point(249, 312);
            this.lbSlobodneSobe.Name = "lbSlobodneSobe";
            this.lbSlobodneSobe.Size = new System.Drawing.Size(213, 108);
            this.lbSlobodneSobe.TabIndex = 20;
            this.lbSlobodneSobe.SelectedIndexChanged += new System.EventHandler(this.lbSlobodneSobe_SelectedIndexChanged);
            // 
            // btnSacuvajRez
            // 
            this.btnSacuvajRez.Location = new System.Drawing.Point(225, 439);
            this.btnSacuvajRez.Name = "btnSacuvajRez";
            this.btnSacuvajRez.Size = new System.Drawing.Size(109, 36);
            this.btnSacuvajRez.TabIndex = 21;
            this.btnSacuvajRez.Text = "Unesi rezervaciju";
            this.btnSacuvajRez.UseVisualStyleBackColor = true;
            this.btnSacuvajRez.Click += new System.EventHandler(this.btnSacuvajRez_Click);
            // 
            // txtUkupnaCena
            // 
            this.txtUkupnaCena.Enabled = false;
            this.txtUkupnaCena.Location = new System.Drawing.Point(12, 448);
            this.txtUkupnaCena.Name = "txtUkupnaCena";
            this.txtUkupnaCena.Size = new System.Drawing.Size(84, 20);
            this.txtUkupnaCena.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 432);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Ukupna cena";
            // 
            // txtTipRez
            // 
            this.txtTipRez.Location = new System.Drawing.Point(103, 448);
            this.txtTipRez.Name = "txtTipRez";
            this.txtTipRez.Size = new System.Drawing.Size(86, 20);
            this.txtTipRez.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(103, 429);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Tip rezervacije";
            // 
            // FormaRecepcionerRezervisanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 487);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTipRez);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUkupnaCena);
            this.Controls.Add(this.btnSacuvajRez);
            this.Controls.Add(this.lbSlobodneSobe);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbTipSobe);
            this.Controls.Add(this.cmbBrKreveta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDatumDo);
            this.Controls.Add(this.dtpDatumOd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDatRodj);
            this.Controls.Add(this.txtTelefonGosta);
            this.Controls.Add(this.txtPrezimeGosta);
            this.Controls.Add(this.txtImeGosta);
            this.Controls.Add(this.btnIzaberiGosta);
            this.Controls.Add(this.btnDodajGosta);
            this.Controls.Add(this.lbGosti);
            this.Name = "FormaRecepcionerRezervisanje";
            this.Text = "FormaRecepcionerRezervisanje";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormaRecepcionerRezervisanje_FormClosed);
            this.Load += new System.EventHandler(this.FormaRecepcionerRezervisanje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGosti;
        private System.Windows.Forms.Button btnDodajGosta;
        private System.Windows.Forms.Button btnIzaberiGosta;
        private System.Windows.Forms.TextBox txtImeGosta;
        private System.Windows.Forms.TextBox txtPrezimeGosta;
        private System.Windows.Forms.TextBox txtTelefonGosta;
        private System.Windows.Forms.DateTimePicker dtpDatRodj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDatumOd;
        private System.Windows.Forms.DateTimePicker dtpDatumDo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBrKreveta;
        private System.Windows.Forms.ComboBox cmbTipSobe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lbSlobodneSobe;
        private System.Windows.Forms.Button btnSacuvajRez;
        private System.Windows.Forms.TextBox txtUkupnaCena;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTipRez;
        private System.Windows.Forms.Label label10;
    }
}