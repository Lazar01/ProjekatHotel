using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class FormaRecepcioner : Form
    {
        List<Rezervacije> listaRezervacije = new List<Rezervacije>();
        string fajlRezervacije = @"..\..\TekstDatoteke\rezervacije.txt";

        CultureInfo provider = CultureInfo.InvariantCulture;
        public FormaRecepcioner()
        {
            InitializeComponent();
        }

        private void FormaRecepcioner_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            f.Activate();
        }

        private void FormaRecepcioner_Load(object sender, EventArgs e)
        {
            
            StreamReader srRezervacije = new StreamReader(fajlRezervacije);
            int id, idSobe, idGosta,cena ;
            DateTime datumOd, datumDo;
            string tipRez,tekst;
            string[] informacijeRezervacije;

            if (srRezervacije.ReadLine() != "")
            {
                srRezervacije.BaseStream.Position = 0;
                srRezervacije.DiscardBufferedData();
                while ((tekst = srRezervacije.ReadLine()) != null)
                {
                    informacijeRezervacije = tekst.Split('|');
                    id = Int32.Parse(informacijeRezervacije[0]);
                    idSobe = Int32.Parse(informacijeRezervacije[1]);
                    idGosta = Int32.Parse(informacijeRezervacije[2]);
                    cena = Int32.Parse(informacijeRezervacije[3]);
                    tipRez = informacijeRezervacije[4];
                    datumOd = DateTime.ParseExact(informacijeRezervacije[5], "dd/MM/yyyy", provider);
                    datumDo = DateTime.ParseExact(informacijeRezervacije[6], "dd/MM/yyyy", provider);

                    Rezervacije rezervacija = new Rezervacije(id, idSobe, idGosta, cena, tipRez, datumOd.Date, datumDo.Date);
                    listaRezervacije.Add(rezervacija);
                }
            }
            srRezervacije.Close();

            for (int i = 0; i < listaRezervacije.Count; i++)
                if(listaRezervacije[i].DatumOd == DateTime.Now.Date)
                    lbRezervacije.Items.Add(listaRezervacije[i].ToString());
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if(lbRezervacije.Items.Count!=0)
            { 
                listaRezervacije.Remove(listaRezervacije[Int32.Parse(lbRezervacije.SelectedItem.ToString().Substring(0, 1))]);

                StreamWriter sw = new StreamWriter(fajlRezervacije);
                for (int i = 0; i < listaRezervacije.Count; i++)
                    sw.WriteLine(listaRezervacije[i].ToString());
                sw.Close();
                lbRezervacije.Items.Remove(lbRezervacije.SelectedItem);
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (lbRezervacije.SelectedIndex != -1)
            {
                FormaAdmin fa = new FormaAdmin(Int32.Parse(lbRezervacije.SelectedItem.ToString().Substring(0, 1)));
                fa.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Niste izabrali rezervaciju ili trenutno nema rezervacija!");
        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            FormaRecepcionerRezervisanje frp = new FormaRecepcionerRezervisanje();
            frp.Show();
            frp.Focus();
            this.Hide();
        }
    }
}
