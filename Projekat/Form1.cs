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
    public partial class Form1 : Form
    {
        List<Korisnik> listaKorisnici = new List<Korisnik>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Ucitavanje podataka
            string fajlKorisnici = @"..\..\TekstDatoteke\korisnici.txt";
            StreamReader srKorisnici = new StreamReader(fajlKorisnici);
            string tekst, korIme, lozinka, ime, prezime, vrstaKor;
            int id;
            string[] informacijeKorisnici;


            //UCitavanje Korisnika u listu ListaKorisnici
            while ((tekst = srKorisnici.ReadLine()) != null)
            {
                informacijeKorisnici = tekst.Split('|');
                id = Int32.Parse(informacijeKorisnici[0]);
                korIme = informacijeKorisnici[1];
                lozinka = informacijeKorisnici[2];
                ime = informacijeKorisnici[3];
                prezime = informacijeKorisnici[4];
                vrstaKor = informacijeKorisnici[5];
                Korisnik korisnik = new Korisnik(ime, prezime, korIme, lozinka, vrstaKor, id);
                listaKorisnici.Add(korisnik);
            }
            //MessageBox.Show(String.Join("|", ListaKorisnici));

            srKorisnici.Close();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (rbRecepcioner.Checked)
            {
                proveriUnosRecepcioner();
            }
            else
            {
                proveriUnosAdmin();
            }
        }

        private void proveriUnosAdmin()
        {
            // Kod za otvaranje admin forme
            if (txtKorisnickoIme.Text.Trim() != "" && txtSifra.Text.Trim() != "")
            {
                for (int i = 0; i < listaKorisnici.Count; i++)
                {
                    if (txtKorisnickoIme.Text == listaKorisnici[i].KorisnickoIme && txtSifra.Text == listaKorisnici[i].Lozinka && listaKorisnici[i].VrstaK == "a")
                    {
                        FormaAdmin formaAdmin = new FormaAdmin(-1);
                        formaAdmin.Show();
                        this.Hide();
                        break;
                    }
                    //Proverava da li je I poslednji i ukoliko jeste znaci da nije pronadjen odgovarajuci username i sifra naloga.
                    if (i == listaKorisnici.Count - 1)
                    {
                        MessageBox.Show("Ne postoji admin nalog sa unetim parametrima!");
                        txtKorisnickoIme.Text = "";
                        txtSifra.Text = "";
                        txtKorisnickoIme.Focus();
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Greška! Niste uneli sve podatke!");
        }

        private void proveriUnosRecepcioner()
        {
            if (txtKorisnickoIme.Text.Trim() != "" && txtSifra.Text.Trim() != "")
            {
                for (int i = 0; i < listaKorisnici.Count; i++)
                {
                    if (txtKorisnickoIme.Text == listaKorisnici[i].KorisnickoIme && txtSifra.Text == listaKorisnici[i].Lozinka && listaKorisnici[i].VrstaK == "r")
                    {
                        FormaRecepcioner formaRecepcioner = new FormaRecepcioner();
                        formaRecepcioner.Show();
                        this.Hide();
                        break;
                    }
                    //Proverava da li je I poslednji i ukoliko jeste znaci da nije pronadjen odgovarajuci username i sifra naloga.
                    if (i == listaKorisnici.Count - 1)
                    {
                        MessageBox.Show("Ne postoji recepcioner nalog sa unetim parametrima!");
                        txtKorisnickoIme.Text = "";
                        txtSifra.Text = "";
                        txtKorisnickoIme.Focus();
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Greška! Niste uneli sve podatke!");
        }

        private void txtSifra_Enter(object sender, EventArgs e)
        {
            txtSifra.ForeColor = Color.Black;
            txtSifra.UseSystemPasswordChar = true;
        }

        private void txtSifra_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Sakrivanje sifre dvoklikom
            if (txtSifra.UseSystemPasswordChar == true)
                txtSifra.UseSystemPasswordChar = false;
            else
                txtSifra.UseSystemPasswordChar= true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        
    }
}
