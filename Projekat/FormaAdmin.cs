using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class FormaAdmin : Form
    {
        List<Korisnik> listaKorisnici = new List<Korisnik>();
        List<Gost> listaGosti = new List<Gost>();
        List<Soba> listaSobe = new List<Soba>();
        List<Rezervacije> listaRezervacije = new List<Rezervacije>();

        string fajlKorisnici = @"..\..\TekstDatoteke\korisnici.txt";
        string fajlSobe = @"..\..\TekstDatoteke\sobe.txt";
        string fajlGost = @"..\..\TekstDatoteke\gosti.txt";
        string fajlRezervacije = @"..\..\TekstDatoteke\rezervacije.txt";
        CultureInfo provider = CultureInfo.InvariantCulture;

        string tekst, korIme, lozinka, ime, prezime, vrstaKor, brTelefona, tipSobe, tipRezervacije;
        int id, brSobe, brKreveta, cena, popust, minBrDana, idSobe, idGosta, izabraniID=-1;
        string[] informacijeKorisnici, informacijeSobe, informacijeGosti, informacijeRezervacije;

        

        DateTime dat_rodjenja, datumOd, datumDo;
        Button btnSacuvajUnos = new Button();
        Button btnSacuvajIzmene = new Button();

        public FormaAdmin(int izabraniID)
        {
            this.izabraniID = izabraniID;
            InitializeComponent();
        }

        private void FormaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            f.Activate();
        }

        private void FormaAdmin_Load(object sender, EventArgs e)
        {
            StreamReader srKorisnici = new StreamReader(fajlKorisnici);
            StreamReader srSobe = new StreamReader(fajlSobe);
            StreamReader srGosti = new StreamReader(fajlGost);
            StreamReader srRezervacije = new StreamReader(fajlRezervacije);

            dtpGost.MaxDate = DateTime.Now.Date;

            dtpGost.CustomFormat = "dd/MM/yyyy";
            dtpDatumOd.CustomFormat="dd/MM/yyyy";
            dtpDatumDo.CustomFormat = "dd/MM/yyyy";

            btnSacuvajUnos.Height = 50;
            btnSacuvajUnos.Width = 100;
            btnSacuvajUnos.Location = new Point(tbpGost.Width / 2 - 50, tbpGost.Height - 70);
            btnSacuvajUnos.Text = "Sačuvaj";

            btnSacuvajIzmene.Height = 50;
            btnSacuvajIzmene.Width = 100;
            btnSacuvajIzmene.Location = new Point(tbpGost.Width / 2 - 50, tbpGost.Height - 70);
            btnSacuvajIzmene.Text = "Sačuvaj";
            //Ucitavanje Korisnika u listu ListaKorisnici
            if(srKorisnici.ReadLine()!="")
            {
                srKorisnici.BaseStream.Position = 0;
                srKorisnici.DiscardBufferedData();
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
            }
            //MessageBox.Show(String.Join("|", ListaKorisnici));

            //Ucitavanje Gostiju u listu ListaGosti
            if(srGosti.ReadLine()!="")
            {
                srGosti.BaseStream.Position = 0;
                srGosti.DiscardBufferedData();
                while ((tekst = srGosti.ReadLine()) != null)
                {
                    informacijeGosti = tekst.Split('|');
                    //MessageBox.Show(informacijeGosti[0]);
                    id = Int32.Parse(informacijeGosti[0]);
                    ime = informacijeGosti[1];
                    prezime = informacijeGosti[2];
                    dat_rodjenja = DateTime.ParseExact(informacijeGosti[3], "dd/MM/yyyy", provider);
                    brTelefona = informacijeGosti[4];
                    Gost gost = new Gost(id, ime, prezime, dat_rodjenja, brTelefona);
                    listaGosti.Add(gost);
                }
            }
            //MessageBox.Show(String.Join("|", listaGosti));if(srSobe.ReadLine() != "")
            {
                srSobe.BaseStream.Position = 0;
                srSobe.DiscardBufferedData();
                while ((tekst = srSobe.ReadLine()) != null)
                {
                    informacijeSobe = tekst.Split('|');
                    id = Int32.Parse(informacijeSobe[0]);
                    brSobe = Int32.Parse(informacijeSobe[1]);
                    brKreveta = Int32.Parse(informacijeSobe[2]);
                    cena = Int32.Parse(informacijeSobe[3]);
                    popust = Int32.Parse(informacijeSobe[4]);
                    minBrDana = Int32.Parse(informacijeSobe[5]);
                    tipSobe = informacijeSobe[6];
                    Soba soba = new Soba(id, brSobe, brKreveta, cena, popust, minBrDana, tipSobe);
                    listaSobe.Add(soba);
                }
            }
            
            //MessageBox.Show(String.Join("|", listaSobe));

            //Rezervacije ucitavanje
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
                    tipRezervacije = informacijeRezervacije[4];
                    datumOd = DateTime.ParseExact(informacijeRezervacije[5], "dd/MM/yyyy", provider);
                    datumDo = DateTime.ParseExact(informacijeRezervacije[6], "dd/MM/yyyy", provider);
                    
                    Rezervacije rezervacija = new Rezervacije(id, idSobe, idGosta, cena, tipRezervacije, datumOd.Date, datumDo.Date);
                    listaRezervacije.Add(rezervacija);
                }
            }
            //MessageBox.Show(String.Join("|", listaRezervacije));

            srKorisnici.Close();
            srGosti.Close();
            srRezervacije.Close();
            srSobe.Close();

            //Ucitavanje elemenata u kombo boxove
            for (int i = 0; i < listaGosti.Count; i++)
                cmbIdGosta.Items.Add(listaGosti[i].Id);
            for (int i = 0; i < listaSobe.Count; i++)
                cmbIdSobe.Items.Add(listaSobe[i].ID1);
            for (int i = 0; i < listaRezervacije.Count; i++)
                cmbIdRez.Items.Add(listaRezervacije[i].Id);
            for (int i = 0; i < listaGosti.Count; i++)
                cmbIdGostaRez.Items.Add(listaGosti[i].Id);
            for (int i = 0; i < listaSobe.Count; i++)
                cmbIdSobeRez.Items.Add(listaSobe[i].ID1);
            for (int i = 0; i < listaKorisnici.Count; i++)
                cmbIdKor.Items.Add(listaKorisnici[i].Id);

            if (izabraniID != -1)
                IzmenaRezervacijeRecepcioner();

            btnSacuvajUnos.Click += BtnSacuvajUnos_Click;
            btnSacuvajIzmene.Click += BtnSacuvajIzmene_Click;

            txtTelefonGosta.KeyPress += TxtTelefonGosta_KeyPress;
            txtPrezimeGosta.KeyPress += TxtPrezimeGosta_KeyPress;
            txtImeGosta.KeyPress += TxtImeGosta_KeyPress;
            

            txtBrojSobe.KeyPress += TxtBrojSobe_KeyPress;
            txtBrojKreveta.KeyPress += TxtBrojKreveta_KeyPress;
            txtTipSobe.KeyPress += TxtTipSobe_KeyPress;
            txtCena.KeyPress += TxtCena_KeyPress;
            txtPopust.KeyPress += TxtPopust_KeyPress;
            txtMinBrDana.KeyPress += TxtMinBrDana_KeyPress;

            txtTipRez.KeyPress += TxtTipRez_KeyPress;

            txtImeKor.KeyPress += TxtImeKor_KeyPress;
            txtPrezimeKor.KeyPress += TxtPrezimeKor_KeyPress;
            txtKorisnickoIme.KeyPress += TxtKorisnickoIme_KeyPress;
            txtLozinka.KeyPress += TxtLozinka_KeyPress;
        }

        private void TxtLozinka_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (e.KeyChar != ((char)Keys.Space))
                    e.Handled = true;
        }

        private void TxtKorisnickoIme_KeyPress(object sender, KeyPressEventArgs e)
        { 
                if (e.KeyChar != ((char)Keys.Space))
                    e.Handled = true;
        }

        private void TxtPrezimeKor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtImeKor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtTipRez_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtMinBrDana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtPopust_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtCena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtTipSobe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtBrojKreveta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtBrojSobe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtImeGosta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtPrezimeGosta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtTelefonGosta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back) && e.KeyChar != (char)Keys.Oemplus)
                    e.Handled = true;
        }

        private void dtpDatumOd_CloseUp(object sender, EventArgs e)
        {
            if (cmbIdSobeRez.SelectedIndex == -1)
            {
                MessageBox.Show("Prvo izaberite id sobe!");
                dtpDatumOd.Value = DateTime.Now.Date;
            }
            else
            { 
                if (dtpDatumOd.Value < DateTime.Now.Date)
                MessageBox.Show("Ne mozete izabrati ovaj datum!");
                else
                    ProveraOdDatuma();
            }
        }

        private void dtpDatumDo_CloseUp(object sender, EventArgs e)
        {
            if (cmbIdSobeRez.SelectedIndex == -1)
            {
                MessageBox.Show("Prvo izaberite id sobe!");
                dtpDatumDo.Value = DateTime.Now.Date;
            }
        }



        //Podesavanje podataka kada se klikne dugme dodaj, kreiranje dugmeta sacuvaj
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            btnOdustani.Enabled = true;
            switch (tabControl1.SelectedIndex)
            {
                case 0: DodavanjeGosta();break;
                case 1: DodavanjeSobe();break;
                case 2: DodavanjeRezervacije();break;
                case 3: DodavanjeKorisnika();break;
            }
        }
        private void DodavanjeGosta()
        {
            //Provera da li je novi indeks manji od vec postojecih indeksa
            if (cmbIdGosta.Items.Count == 0)
                cmbIdGosta.Items.Add(1);
            else
            {
                for (int i = 0; i < listaGosti.Count; i++)
                        if (i + 1 < listaGosti[i].Id)
                        {
                            cmbIdGosta.Items.Add(i + 1);
                            break;
                        }
                        else if (i == listaGosti.Count - 1)
                            cmbIdGosta.Items.Add(listaGosti.Count + 1);

                    cmbIdGosta.SelectedIndex = cmbIdGosta.Items.Count - 1;

                    cmbIdGosta.Enabled = false;
                    txtImeGosta.Enabled = true;
                    txtPrezimeGosta.Enabled = true;
                    dtpGost.Enabled = true;
                    txtTelefonGosta.Enabled = true;
                    btnDodaj.Enabled = false;
                    btnIzbrisi.Enabled = false;
                    btnIzmeni.Enabled = false;

                    txtImeGosta.Text = "";
                    txtPrezimeGosta.Text = "";
                    dtpGost.Value = DateTime.Today;
                    txtTelefonGosta.Text = "";

                    tbpGost.Controls.Add(btnSacuvajUnos);
            }
        }
        private void DodavanjeSobe()
        {
            if (cmbIdSobe.Items.Count == 0)
                cmbIdSobe.Items.Add(1);
            else
            { 
            //Provera da li je novi indeks manji od vec postojecih indeksa
                for (int i = 0; i < listaSobe.Count; i++)
                    if (i + 1 < listaSobe[i].ID1)
                    {
                        cmbIdSobe.Items.Add(i + 1);
                        break;
                    }
                    else if (i == listaSobe.Count - 1)
                        cmbIdSobe.Items.Add(listaSobe.Count + 1);
                if (cmbIdSobe.Items.Count == 0)
                    cmbIdSobe.Items.Add(1);

                cmbIdSobe.SelectedIndex = cmbIdSobe.Items.Count - 1;

                cmbIdSobe.Enabled = false;
                txtBrojSobe.Enabled = true;
                txtBrojKreveta.Enabled = true;
                txtTipSobe.Enabled = true;
                txtCena.Enabled = true;
                txtPopust.Enabled = true;
                txtMinBrDana.Enabled = true;

                btnDodaj.Enabled = false;
                btnIzbrisi.Enabled = false;
                btnIzmeni.Enabled = false;

                txtBrojSobe.Text = "";
                txtBrojKreveta.Text = "";
                txtTipSobe.Text = "";
                txtCena.Text = "";
                txtPopust.Text = "";
                txtMinBrDana.Text = "";

                tbpSoba.Controls.Add(btnSacuvajUnos);
            }
        }
        private void DodavanjeRezervacije()
        {
            if (cmbIdRez.Items.Count == 0)
                cmbIdRez.Items.Add(1);
            else
            {    
                //Provera da li je novi indeks manji od vec postojecih indeksa
                for (int i = 0; i < listaRezervacije.Count; i++)
                    if (i + 1 < listaRezervacije[i].Id)
                    {
                        cmbIdRez.Items.Add(i + 1);
                        break;
                    }
                    else if (i == listaRezervacije.Count - 1)
                        cmbIdRez.Items.Add(listaRezervacije.Count + 1);
                if (cmbIdRez.Items.Count == 0)
                    cmbIdRez.Items.Add(1);

                cmbIdRez.SelectedIndex = cmbIdRez.Items.Count - 1;

                cmbIdRez.Enabled = false;
                cmbIdSobeRez.Enabled = true;
                cmbIdGostaRez.Enabled = true;
                dtpDatumOd.Enabled = true;

                cmbIdSobeRez.SelectedIndex = -1;
                cmbIdGostaRez.SelectedIndex = -1;

                //Ogranicavanje datum od
                dtpDatumDo.MaxDate = new DateTime(DateTime.Now.Year + 10, DateTime.Now.Month, DateTime.Now.Day);
                dtpDatumDo.MinDate = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);
                dtpDatumOd.MaxDate = new DateTime(DateTime.Now.Year + 10, DateTime.Now.Month, DateTime.Now.Day);
                dtpDatumOd.MinDate = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);
                dtpDatumOd.Value = DateTime.Now.Date;
                dtpDatumDo.Value = DateTime.Now.Date;
                dtpDatumOd.MinDate = DateTime.Now.Date;
                dtpDatumOd.MaxDate = dtpDatumOd.Value.AddYears(1);

                txtUkupnaCena.Text = "";
                txtTipRez.Text = "";

                btnDodaj.Enabled = false;
                btnIzbrisi.Enabled = false;
                btnIzmeni.Enabled = false;

            
                txtTipRez.Enabled = true;

                tbpRez.Controls.Add(btnSacuvajUnos);
            }
        }
        private void DodavanjeKorisnika()
        {
            if (cmbIdKor.Items.Count == 0)
                cmbIdKor.Items.Add(1);
            else
            { 
                for (int i = 0; i < listaKorisnici.Count; i++)
                    if (i + 1 < listaKorisnici[i].Id)
                    {
                        cmbIdKor.Items.Add(i + 1);
                        break;
                    }
                    else if (i == listaKorisnici.Count - 1)
                        cmbIdKor.Items.Add(listaKorisnici.Count + 1);

                cmbIdKor.SelectedIndex = cmbIdKor.Items.Count - 1;

                cmbIdKor.Enabled = false;
                txtImeKor.Enabled = true;
                txtPrezimeKor.Enabled = true;
                txtKorisnickoIme.Enabled = true;
                txtLozinka.Enabled = true;
                cmbVrKor.Enabled = true;

                btnDodaj.Enabled = false;
                btnIzbrisi.Enabled = false;
                btnIzmeni.Enabled = false;

                txtImeKor.Text = "";
                txtPrezimeKor.Text = "";
                txtKorisnickoIme.Text = "";
                txtLozinka.Text = "";
                cmbVrKor.SelectedIndex = -1;


                tbpKorisnik.Controls.Add(btnSacuvajUnos);
            }
        }

        //Upisivanje novih podataka
        private void BtnSacuvajUnos_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: SacuvajUnetogGosta();break;
                case 1: SacuvajUnetuSobu();break;
                case 2: SacuvajUnetuRezervaciju();break;
                case 3:
                    if (cmbVrKor.SelectedIndex == 0) 
                        SacuvajUnetogKorisnika("a");
                    else
                        SacuvajUnetogKorisnika("r");
                    break;
            }
        }
        private void SacuvajUnetogGosta()
        {
            if (txtImeGosta.Text.Trim() != "" && txtPrezimeGosta.Text.Trim() != "" && txtTelefonGosta.Text.Trim() != "")
            {
                if ((DateTime.Now.Year - dtpGost.Value.Year) < 18)
                    MessageBox.Show("Neispravan datum! Osoba mora biti punoletna");
                else
                {
                    Gost NoviGost = new Gost(Int32.Parse(cmbIdGosta.SelectedItem.ToString()), txtImeGosta.Text, txtPrezimeGosta.Text, dtpGost.Value, txtTelefonGosta.Text);
                    listaGosti.Add(NoviGost);
                    Gost zamenaGost;
                    for (int i = 0; i < listaGosti.Count; i++)
                    {
                        for (int j = i + 1; j < listaGosti.Count; j++)
                        {
                            if (listaGosti[i].Id > listaGosti[j].Id)
                            {
                                zamenaGost = listaGosti[i];
                                listaGosti[i] = listaGosti[j];
                                listaGosti[j] = zamenaGost;
                            }
                        }
                    }
                    cmbIdGosta.Items.Clear();
                    for (int i = 0; i < listaGosti.Count; i++)
                        cmbIdGosta.Items.Add(listaGosti[i].Id);
                    cmbIdGosta.SelectedIndex = -1;
                    StreamWriter writer = new StreamWriter(fajlGost);
                    for (int i = 0; i < listaGosti.Count; i++)
                        writer.WriteLine(listaGosti[i].ToString());
                    writer.Close();

                    tbpGost.Controls.Remove(btnSacuvajUnos);
                    MessageBox.Show("Uspešno dodat novi gost");

                    cmbIdGostaRez.Items.Clear();
                    for (int i = 0; i < listaGosti.Count; i++)
                        cmbIdGostaRez.Items.Add(listaGosti[i].Id);

                    txtImeGosta.Text = "";
                    txtPrezimeGosta.Text = "";
                    dtpGost.MaxDate = DateTime.Now;
                    dtpGost.Value = DateTime.Now;

                    cmbIdGosta.Enabled = true;
                    txtImeGosta.Enabled = false;
                    txtPrezimeGosta.Enabled = false;
                    dtpGost.Enabled = false;
                    txtTelefonGosta.Enabled = false;
                    btnDodaj.Enabled = true;
                    btnIzbrisi.Enabled = true;
                    btnIzmeni.Enabled = true;

                }
            }
            else
                MessageBox.Show("Niste popunili sve parametre");
        }
        private void SacuvajUnetuSobu()
        {
            if (txtBrojSobe.Text.Trim() != "" && txtBrojKreveta.Text.Trim() != "" && txtTipSobe.Text.Trim() != "" && txtCena.Text != "" && txtPopust.Text != "" && txtMinBrDana.Text != "")
            {
                if (Int32.Parse(txtBrojKreveta.Text) <= 4)
                {
                    Soba NovaSoba = new Soba(Int32.Parse(cmbIdSobe.SelectedItem.ToString()), Int32.Parse(txtBrojSobe.Text), Int32.Parse(txtBrojKreveta.Text), Int32.Parse(txtCena.Text), Int32.Parse(txtPopust.Text), Int32.Parse(txtMinBrDana.Text), txtTipSobe.Text);
                    listaSobe.Add(NovaSoba);
                    Soba ZamenaSoba;
                    for (int i = 0; i < listaSobe.Count; i++)
                    {
                        for (int j = i + 1; j < listaSobe.Count; j++)
                        {
                            if (listaSobe[i].ID1 > listaSobe[j].ID1)
                            {
                                ZamenaSoba = listaSobe[i];
                                listaSobe[i] = listaSobe[j];
                                listaSobe[j] = ZamenaSoba;
                            }
                        }
                    }
                    cmbIdSobe.Items.Clear();

                    for (int i = 0; i < listaSobe.Count; i++)
                        cmbIdSobe.Items.Add(listaSobe[i].ID1);
                    ;
                    StreamWriter writer = new StreamWriter(fajlSobe);

                    for (int i = 0; i < listaSobe.Count; i++)
                        writer.WriteLine(listaSobe[i].ToString());
                    writer.Close();

                    tbpSoba.Controls.Remove(btnSacuvajUnos);

                    cmbIdSobe.SelectedIndex = -1;
                    txtBrojSobe.Text = "";
                    txtBrojKreveta.Text = "";
                    txtTipSobe.Text = "";
                    txtCena.Text = "";
                    txtPopust.Text = "";
                    txtMinBrDana.Text = "";


                    MessageBox.Show("Uspešno dodata nova soba!");

                    //Ucitavanje u combo box na stranici rezervacija
                    cmbIdSobeRez.Items.Clear();
                    for (int i = 0; i < listaSobe.Count; i++)
                        cmbIdSobeRez.Items.Add(listaSobe[i].ID1);

                    cmbIdSobe.Enabled = true;
                    txtBrojSobe.Enabled = false;
                    txtBrojKreveta.Enabled = false;
                    txtTipSobe.Enabled = false;
                    txtCena.Enabled = false;
                    txtPopust.Enabled = false;
                    txtMinBrDana.Enabled = false;

                    btnDodaj.Enabled = true;
                    btnIzbrisi.Enabled = true;
                    btnIzmeni.Enabled = true;

                }
                else
                    MessageBox.Show("Broj kreveta ne moze biti veci od 4");
            }
            else
                MessageBox.Show("Niste popunili sve parametre");
        }    
        private void SacuvajUnetuRezervaciju()
        {
            if (ProveraDoDatuma() || dtpDatumDo.Enabled)
            {
                if (ProveraGosta())
                {
                    if (txtUkupnaCena.Text.Trim() != "" && txtTipRez.Text.Trim() != "" && cmbIdGostaRez.SelectedIndex != -1 && cmbIdSobeRez.SelectedIndex != -1)
                    {

                        Rezervacije NovaRezervacija = new Rezervacije(Int32.Parse(cmbIdRez.SelectedItem.ToString()), Int32.Parse(cmbIdSobeRez.SelectedItem.ToString()), Int32.Parse(cmbIdGostaRez.SelectedItem.ToString()), Int32.Parse(txtUkupnaCena.Text), txtTipRez.Text, dtpDatumOd.Value.Date, dtpDatumDo.Value.Date);
                        listaRezervacije.Add(NovaRezervacija);
                        Rezervacije ZamenaRez;
                        for (int i = 0; i < listaRezervacije.Count; i++)
                        {
                            for (int j = i + 1; j < listaRezervacije.Count; j++)
                            {
                                if (listaRezervacije[i].Id > listaRezervacije[j].Id)
                                {
                                    ZamenaRez = listaRezervacije[i];
                                    listaRezervacije[i] = listaRezervacije[j];
                                    listaRezervacije[j] = ZamenaRez;
                                }
                            }
                        }
                        cmbIdRez.Items.Clear();
                        for (int i = 0; i < listaRezervacije.Count; i++)
                            cmbIdRez.Items.Add(listaRezervacije[i].Id);
                        cmbIdRez.SelectedIndex = -1;
                        StreamWriter writer = new StreamWriter(fajlRezervacije);
                        for (int i = 0; i < listaRezervacije.Count; i++)
                            writer.WriteLine(listaRezervacije[i].ToString());
                        writer.Close();

                        tbpRez.Controls.Remove(btnSacuvajUnos);

                        MessageBox.Show("Uspešno dodata nova rezervacije!");

                        cmbIdRez.Enabled = true;
                        cmbIdSobeRez.Enabled = false;
                        cmbIdGostaRez.Enabled = false;
                        dtpDatumOd.Enabled = false;
                        dtpDatumDo.Enabled = false;
                        txtUkupnaCena.Enabled = false;
                        txtTipRez.Enabled = false;

                        cmbIdGostaRez.SelectedIndex = -1;
                        cmbIdSobeRez.SelectedIndex = -1;
                        txtUkupnaCena.Text = "";
                        txtTipRez.Text = "";

                        btnDodaj.Enabled = true;
                        btnIzbrisi.Enabled = true;
                        btnIzmeni.Enabled = true;
                    }
                    else
                        MessageBox.Show("Niste popunili sve parametre");
                }
            }
            else
                MessageBox.Show("Izabrani datum do kojeg ćete boraviti je već rezervisan za ovu sobu, molimo vas promenite datum.");
        }
        private void SacuvajUnetogKorisnika(string vrstaK)
        {
            if (txtImeKor.Text.Trim() != "" && txtPrezimeKor.Text.Trim() != "" && txtKorisnickoIme.Text.Trim() != "" && txtLozinka.Text.Trim() !="" && cmbVrKor.SelectedIndex !=-1)
            {
                Korisnik NoviKorisnik = new Korisnik(txtImeKor.Text,txtPrezimeKor.Text,txtKorisnickoIme.Text,txtLozinka.Text,vrstaK,Int32.Parse(cmbIdKor.SelectedItem.ToString()));
                listaKorisnici.Add(NoviKorisnik);
                Korisnik zamenaKorisnik;
                for (int i = 0; i < listaKorisnici.Count; i++)
                {
                    for (int j = i + 1; j < listaKorisnici.Count; j++)
                    {
                        if (listaKorisnici[i].Id > listaKorisnici[j].Id)
                        {
                            zamenaKorisnik = listaKorisnici[i];
                            listaKorisnici[i] = listaKorisnici[j];
                            listaKorisnici[j] = zamenaKorisnik;
                        }
                    }
                }
                cmbIdKor.Items.Clear();

                for (int i = 0; i < listaKorisnici.Count; i++)
                    cmbIdKor.Items.Add(listaKorisnici[i].Id);
                cmbIdKor.SelectedIndex = -1;

                StreamWriter writer = new StreamWriter(fajlKorisnici);
                for (int i = 0; i < listaKorisnici.Count; i++)
                    writer.WriteLine(listaKorisnici[i].ToString());
                writer.Close();

                tbpKorisnik.Controls.Remove(btnSacuvajUnos);
                MessageBox.Show("Uspešno dodat novi korisnik!");

                txtImeKor.Text = "";
                txtPrezimeKor.Text = "";
                txtKorisnickoIme.Text = "";
                txtLozinka.Text = "";
                cmbVrKor.SelectedIndex = -1;

                cmbIdKor.Enabled = true;
                txtImeKor.Enabled = false;
                txtPrezimeKor.Enabled = false;
                txtKorisnickoIme.Enabled = false;
                txtLozinka.Enabled = false;
                cmbVrKor.Enabled = false;

                btnDodaj.Enabled = true;
                btnIzbrisi.Enabled = true;
                btnIzmeni.Enabled = true;
            }
            else
                MessageBox.Show("Niste popunili sve parametre");
        }


        // Izmena zelejnog podatka
        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (cmbIdGosta.SelectedIndex == -1)
                        MessageBox.Show("Niste izabrali id gosta!");
                    else
                    {
                        btnOdustani.Enabled = true;
                        IzmeneGost();
                    }
                    break;
                case 1:
                    if (cmbIdSobe.SelectedIndex == -1)
                        MessageBox.Show("Niste izabrali id sobe!");
                    else
                    {
                        btnOdustani.Enabled = true;
                        IzemeneSoba();
                    }
                    break;
                case 2:
                    if (cmbIdRez.SelectedIndex == -1)
                        MessageBox.Show("Niste izabrali id rezervacije!");
                    else
                    {
                        btnOdustani.Enabled = true;
                        IzmeneRez();
                    }
                    break;
                case 3:
                    if (cmbIdKor.SelectedIndex == -1)
                        MessageBox.Show("Niste izabrali id korisnika!");
                    else
                    {
                        btnOdustani.Enabled = true;
                        IzmeneKor();
                    }
                    break;
            }
            
        }
        private void IzemeneSoba()
        {
            cmbIdSobe.Enabled = false;
            txtBrojSobe.Enabled = true;
            txtBrojKreveta.Enabled = true;
            txtTipSobe.Enabled = true;
            txtCena.Enabled = true;
            txtPopust.Enabled = true;
            txtMinBrDana.Enabled = true;

            btnDodaj.Enabled = false;
            btnIzbrisi.Enabled = false;
            btnIzmeni.Enabled = false;

            tbpSoba.Controls.Add(btnSacuvajIzmene);
        }
        private void IzmeneGost()
        {
            if (txtImeGosta.Text.Trim() != "" && txtPrezimeGosta.Text.Trim() != "" && txtTelefonGosta.Text.Trim() != "")
            {
                cmbIdGosta.Enabled = false;
                txtImeGosta.Enabled = true;
                txtPrezimeGosta.Enabled = true;
                dtpGost.Enabled = true;
                txtTelefonGosta.Enabled = true;

                btnDodaj.Enabled = false;
                btnIzbrisi.Enabled = false;
                btnIzmeni.Enabled = false;

                
                tbpGost.Controls.Add(btnSacuvajIzmene);
                
            }
        }
        private void IzmeneRez()
        {

            cmbIdRez.Enabled = false;
            cmbIdSobeRez.Enabled = true;
            cmbIdGostaRez.Enabled = true;
            dtpDatumOd.Enabled = true;
            txtTipRez.Enabled = true;

            btnDodaj.Enabled = false;
            btnIzbrisi.Enabled = false;
            btnIzmeni.Enabled = false;

            dtpDatumOd.MinDate = DateTime.Now.Date;

            tbpRez.Controls.Add(btnSacuvajIzmene);
        }
        private void IzmeneKor()
        {
            if (txtImeKor.Text.Trim() != "" && txtPrezimeKor.Text.Trim() != "" && txtKorisnickoIme.Text.Trim() != "" && txtLozinka.Text.Trim() != "")
            {
                cmbIdKor.Enabled = false;
                txtImeKor.Enabled = true;
                txtPrezimeKor.Enabled = true;
                txtKorisnickoIme.Enabled = true;
                txtLozinka.Enabled = true;
                cmbVrKor.Enabled = true;

                btnDodaj.Enabled = false;
                btnIzbrisi.Enabled = false;
                btnIzmeni.Enabled = false;

                tbpKorisnik.Controls.Add(btnSacuvajIzmene);

            }
        }
        private void IzmenaRezervacijeRecepcioner()
        {
            tabControl1.SelectedTab = tbpRez;
           

            cmbIdRez.Enabled = false;
            cmbIdGostaRez.Enabled = true;
            cmbIdSobeRez.Enabled = true;
            dtpDatumOd.Enabled = true;
            dtpDatumDo.Enabled = true;
            txtTipRez.Enabled = true;

            listaRezervacije.RemoveAt(cmbIdRez.SelectedIndex);


            cmbIdRez.SelectedIndex = izabraniID-1;
            InformacijeRezervacije();
            txtUkupnaCena.Text = listaSobe[cmbIdSobeRez.SelectedIndex].Cena - (listaSobe[cmbIdSobeRez.SelectedIndex].Cena * listaSobe[cmbIdSobeRez.SelectedIndex].Popust / 100) + "";

            tbpRez.Controls.Add(btnSacuvajIzmene);
            
        }

        // Cuvanje Izmena
        private void BtnSacuvajIzmene_Click(object sender, EventArgs e)
        {
            tabControl1.Enabled = true;
            switch (tabControl1.SelectedIndex)
            {
                case 0: SacuvajIzmeneGost(); break;
                case 1: SacuvajIzmeneSoba();break;
                case 2: SacuvajIzmeneRez();break;
                case 3: SacuvajIzmeneKorisnik();break;
            }
            
        }
        private void SacuvajIzmeneGost()
        {
            if (txtImeGosta.Text.Trim() != "" && txtPrezimeGosta.Text.Trim() != "" && txtTelefonGosta.Text.Trim() != "")
            {
                if ((DateTime.Now.Year - dtpGost.Value.Year) < 18)
                    MessageBox.Show("Neispravan datum! Osoba mora biti punoletna");
                else
                {
                    listaGosti[cmbIdGosta.SelectedIndex].Ime = txtImeGosta.Text;
                    listaGosti[cmbIdGosta.SelectedIndex].Prezime = txtPrezimeGosta.Text;
                    listaGosti[cmbIdGosta.SelectedIndex].Datum_rodjenja = dtpGost.Value;
                    listaGosti[cmbIdGosta.SelectedIndex].Telefon = txtTelefonGosta.Text;
                    tbpGost.Controls.Remove(btnSacuvajIzmene);
                    StreamWriter writer = new StreamWriter(fajlGost);
                    for (int i = 0; i < listaGosti.Count; i++)
                        writer.WriteLine(listaGosti[i].ToString());
                    writer.Close();
                    MessageBox.Show("Uspešno ste napravili izmenu!");

                    cmbIdGosta.SelectedIndex = -1;
                    txtImeGosta.Text = "";
                    txtPrezimeGosta.Text = "";

                    dtpGost.MaxDate = DateTime.Now;
                    dtpGost.Value = DateTime.Now;
                    txtTelefonGosta.Text = "";
                    
                    cmbIdGosta.Enabled = true;
                    txtImeGosta.Enabled = false;
                    txtPrezimeGosta.Enabled = false;
                    dtpGost.Enabled = false;
                    txtTelefonGosta.Enabled = false;
                    btnDodaj.Enabled = true;
                    btnIzbrisi.Enabled = true;
                    btnIzmeni.Enabled = true;

                }
            }
            else
                MessageBox.Show("Niste popunili sve parametre");
        }
        private void SacuvajIzmeneSoba()
        {
            if (txtBrojSobe.Text.Trim() != "" && txtBrojKreveta.Text.Trim() != "" && txtTipSobe.Text.Trim() != "" && txtCena.Text != "" && txtPopust.Text != "" && txtMinBrDana.Text != "")
            {
                if (Int32.Parse(txtBrojKreveta.Text) <= 4)
                {
                    listaSobe[cmbIdSobe.SelectedIndex].BrojSobe = Int32.Parse(txtBrojSobe.Text);
                    listaSobe[cmbIdSobe.SelectedIndex].BrojKreveta = Int32.Parse(txtBrojKreveta.Text);
                    listaSobe[cmbIdSobe.SelectedIndex].TipSobe = txtTipSobe.Text;
                    listaSobe[cmbIdSobe.SelectedIndex].Cena = Int32.Parse(txtCena.Text);
                    listaSobe[cmbIdSobe.SelectedIndex].Popust = Int32.Parse(txtPopust.Text);
                    listaSobe[cmbIdSobe.SelectedIndex].MinBrDana = Int32.Parse(txtMinBrDana.Text);

                    tbpSoba.Controls.Remove(btnSacuvajIzmene);

                    StreamWriter writer = new StreamWriter(fajlSobe);
                    for (int i = 0; i < listaSobe.Count; i++)
                        writer.WriteLine(listaSobe[i].ToString());
                    writer.Close();

                    MessageBox.Show("Uspešno ste napravili izmenu!");
                }
                else
                    MessageBox.Show("Broj kreveta ne moze biti veci od 4.");

            }
            else
                MessageBox.Show("Niste popunili sve parametre");
        }
        private void SacuvajIzmeneRez()
        {
            if (ProveraDoDatuma() && dtpDatumDo.Enabled)
            { 
                if(ProveraGosta())
                { 
                    if (txtUkupnaCena.Text.Trim() != "" && txtTipRez.Text.Trim() != "" && cmbIdGostaRez.SelectedIndex != -1 && cmbIdSobeRez.SelectedIndex != -1)
                    {
                    

                        listaRezervacije[cmbIdRez.SelectedIndex].IdSobe= Int32.Parse(cmbIdSobeRez.SelectedItem.ToString());
                        listaRezervacije[cmbIdRez.SelectedIndex].IdGosta= Int32.Parse(cmbIdGostaRez.SelectedItem.ToString());
                        listaRezervacije[cmbIdRez.SelectedIndex].DatumOd = dtpDatumOd.Value.Date;
                        listaRezervacije[cmbIdRez.SelectedIndex].DatumDo = dtpDatumDo.Value.Date;
                        listaRezervacije[cmbIdRez.SelectedIndex].UkupnaCena = Int32.Parse(txtUkupnaCena.Text);
                        listaRezervacije[cmbIdRez.SelectedIndex].TipRezervacije = txtTipRez.Text;

                        StreamWriter writer = new StreamWriter(fajlRezervacije);
                            for (int i = 0; i < listaRezervacije.Count; i++)
                                writer.WriteLine(listaRezervacije[i].ToString());
                        writer.Close();

                        btnDodaj.Enabled = true;
                        btnIzmeni.Enabled = true;
                        btnIzbrisi.Enabled = true;


                        tbpRez.Controls.Remove(btnSacuvajIzmene);
                        cmbIdRez.Enabled = true;
                        cmbIdSobeRez.Enabled = false;
                        cmbIdGostaRez.Enabled = false;
                        dtpDatumOd.Enabled = false;
                        dtpDatumDo.Enabled = false;
                        txtTipRez.Enabled = false;

                        cmbIdRez.SelectedIndex = -1;
                        cmbIdSobeRez.SelectedIndex = -1;
                        cmbIdGostaRez.SelectedIndex = -1;
                        dtpDatumOd.Value = dtpDatumOd.MinDate;
                        dtpDatumDo.Value = dtpDatumDo.MaxDate;
                        txtUkupnaCena.Text = "";
                        txtTipRez.Text = "";

                        MessageBox.Show("Uspešno ste napravili izmenu!");

                        if (izabraniID != -1)
                        {
                            FormaRecepcioner fr = new FormaRecepcioner();
                            fr.Show();
                            this.Hide();
                            fr.Activate();
                            izabraniID = -1;
                        }

                    }
                    else
                        MessageBox.Show("Niste popunili sve parametre");
                }
            }
            else
                MessageBox.Show("Izabrani datum do kojeg ćete boraviti je već rezervisan za ovu sobu, molimo vas promenite datum.");
        }    
        private void SacuvajIzmeneKorisnik()

        {
            if (txtImeKor.Text.Trim() != "" && txtPrezimeKor.Text.Trim() != "" && txtKorisnickoIme.Text.Trim() != "" && txtLozinka.Text.Trim() != "" && cmbVrKor.SelectedIndex != -1)
            {
                listaKorisnici[cmbIdKor.SelectedIndex].Ime = txtImeKor.Text;
                listaKorisnici[cmbIdKor.SelectedIndex].Prezime = txtPrezimeKor.Text;
                listaKorisnici[cmbIdKor.SelectedIndex].KorisnickoIme = txtKorisnickoIme.Text;
                listaKorisnici[cmbIdKor.SelectedIndex].Lozinka = txtLozinka.Text;
                if (cmbVrKor.SelectedIndex == 0)
                    listaKorisnici[cmbIdKor.SelectedIndex].VrstaK = "a";
                else
                    listaKorisnici[cmbIdKor.SelectedIndex].VrstaK = "r";

                tbpGost.Controls.Remove(btnSacuvajIzmene);

                StreamWriter writer = new StreamWriter(fajlRezervacije);
                for (int i = 0; i < listaRezervacije.Count; i++)
                    writer.WriteLine(listaRezervacije[i].ToString());
                writer.Close();

                MessageBox.Show("Uspešno ste napravili izmenu!");

                cmbIdKor.SelectedIndex = -1;
                txtImeKor.Text = "";
                txtPrezimeKor.Text = "";
                txtKorisnickoIme.Text = "";
                txtLozinka.Text = "";
                cmbVrKor.SelectedIndex = -1;

                cmbIdKor.Enabled = true;
                txtImeKor.Enabled = false;
                txtPrezimeKor.Enabled = false;
                txtKorisnickoIme.Enabled = false;
                txtLozinka.Enabled = false;
                cmbVrKor.Enabled = false;
            }
            else
                MessageBox.Show("Niste popunili sve parametre");
        }

        //Brisanje
        private void btnIzbrisi_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (cmbIdGosta.SelectedIndex == -1)
                        MessageBox.Show("Niste izabrali id gosta!");
                    else
                        IzbrisiGosta(); 
                    break;
                case 1:
                    if (cmbIdSobe.SelectedIndex == -1)
                        MessageBox.Show("Niste izabrali id sobe!");
                    else 
                        IzbrisiSobu();
                    break;
                case 2:
                    if (cmbIdRez.SelectedIndex == -1)
                        MessageBox.Show("Niste izabrali id rezervacije!");
                    else 
                        IzbrisiRez();
                    break;
                case 3:
                    if (cmbIdKor.SelectedIndex == -1)
                        MessageBox.Show("Nista izabrali id korisnika!");
                    else
                        IzbrisiKorisnika();
                    break;
            }
            
        }
        private void IzbrisiGosta()
        {
            if (txtImeGosta.Text.Trim() != "" && txtPrezimeGosta.Text.Trim() != "" && txtTelefonGosta.Text.Trim() != "")
            {
                if ((DateTime.Now.Year - dtpGost.Value.Year) < 18)
                    MessageBox.Show("Neispravan datum! Osoba mora biti punoletna");
                else
                {
                    int idGostaBrisanje;
                    idGostaBrisanje = Int32.Parse(cmbIdGosta.SelectedItem.ToString());
                    IzbrisiRez(idGostaBrisanje, "g");
                    StreamWriter writer = new StreamWriter(fajlGost);
                    listaGosti.Remove(listaGosti[cmbIdGosta.SelectedIndex]);

                    if (listaGosti != null)
                        for (int i = 0; i < listaGosti.Count; i++)
                            writer.WriteLine(listaGosti[i].ToString());
                    else
                        writer.Write("");

                    cmbIdGosta.Items.Clear();
                    writer.Close();

                    for (int i = 0; i < listaGosti.Count; i++)
                        cmbIdGosta.Items.Add(listaGosti[i].Id);

                    cmbIdGostaRez.Items.Clear();
                    for (int i = 0; i < listaGosti.Count; i++)
                        cmbIdGostaRez.Items.Add(listaGosti[i].Id);

                    cmbIdGosta.SelectedItem = 0;
                    txtImeGosta.Text = "";
                    txtPrezimeGosta.Text = "";
                    dtpGost.Value = DateTime.Today;
                    txtTelefonGosta.Text = "";

                    MessageBox.Show("Uspešno ste izbrisali gosta i njegove rezervacije!");

                }
            }
            else
                MessageBox.Show("Izabrani gost ne postoji");
        }
        private void IzbrisiSobu()
        {
            if (txtBrojSobe.Text.Trim() != "" && txtBrojKreveta.Text.Trim() != "" && txtTipSobe.Text.Trim() != "" && txtCena.Text != "" && txtPopust.Text != "" && txtMinBrDana.Text != "")
            {
                int idSobeBrisanje;
                idSobeBrisanje = Int32.Parse(cmbIdSobe.SelectedItem.ToString());
                IzbrisiRez(idSobeBrisanje, "s");
                StreamWriter writer = new StreamWriter(fajlSobe);
                listaSobe.Remove(listaSobe[cmbIdSobe.SelectedIndex]);
                if (listaSobe != null)
                    for (int i = 0; i < listaSobe.Count; i++)
                        writer.WriteLine(listaSobe[i].ToString());
                else
                    writer.Write("");

                cmbIdSobe.Items.Clear();
                writer.Close();

                for (int i = 0; i < listaSobe.Count; i++)
                    cmbIdSobe.Items.Add(listaSobe[i].ID1);

                cmbIdSobeRez.Items.Clear();
                for (int i = 0; i < listaSobe.Count; i++)
                    cmbIdSobeRez.Items.Add(listaSobe[i].ID1);

                cmbIdSobe.SelectedItem = 0;
                txtBrojSobe.Text = "";
                txtBrojKreveta.Text = "";
                txtTipSobe.Text = "";
                txtCena.Text = "";
                txtPopust.Text = "";
                txtMinBrDana.Text = "";

                MessageBox.Show("Uspešno ste izbrisali sobu!");
            }
        }
        private void IzbrisiRez()
        {
            StreamWriter writer = new StreamWriter(fajlRezervacije);
            listaRezervacije.Remove(listaRezervacije[cmbIdRez.SelectedIndex]);
            for (int i = 0; i < listaRezervacije.Count; i++)
                writer.WriteLine(listaRezervacije[i].ToString());
            cmbIdRez.Items.Clear();
            writer.Close();

            for (int i = 0; i < listaRezervacije.Count; i++)
                cmbIdRez.Items.Add(listaRezervacije[i].Id);
            cmbIdRez.SelectedIndex = -1;
            cmbIdSobeRez.SelectedIndex = -1;
            cmbIdGostaRez.SelectedIndex = -1;
            dtpDatumOd.Value = DateTime.Now.Date;
            dtpDatumDo.Value = dtpDatumOd.Value.AddDays(2);
            txtUkupnaCena.Text = "";
            txtTipRez.Text = "";

            MessageBox.Show("Uspešno ste izbrisali rezervaciju!");
        }
        private void IzbrisiRez(int idBrisanja, string o)
        {
            switch(o)
            {
            case "g":
                    for (int i = 0; i < listaRezervacije.Count; i++)
                        if (listaRezervacije[i].IdGosta == idBrisanja)
                        { 
                            listaRezervacije.Remove(listaRezervacije[i]);
                            i--;
                        }

                    StreamWriter writer = new StreamWriter(fajlRezervacije);

                    if (listaRezervacije != null)
                        for (int i = 0; i < listaRezervacije.Count; i++)
                            writer.WriteLine(listaRezervacije[i].ToString());
                    else
                        writer.Write("");

                    writer.Close();

                    cmbIdRez.Items.Clear();
                    for (int i = 0; i < listaRezervacije.Count; i++)
                    cmbIdRez.Items.Add(listaRezervacije[i].Id);
                    break;

            case "s":
                    MessageBox.Show(string.Join("|",listaRezervacije));
                    for (int i = 0; i < listaRezervacije.Count; i++)
                    {
                        MessageBox.Show(i+"");
                        if (listaRezervacije[i].IdSobe == idBrisanja)
                        { 
                            listaRezervacije.Remove(listaRezervacije[i]);
                            i--;
                        }
                    }

                    StreamWriter writerRez = new StreamWriter(fajlRezervacije);
                    if (listaRezervacije != null)
                        for (int i = 0; i < listaRezervacije.Count; i++)
                            writerRez.WriteLine(listaRezervacije[i].ToString());
                    else
                        writerRez.Write("");

                    cmbIdRez.Items.Clear();
                    writerRez.Close();

                    for (int i = 0; i < listaRezervacije.Count; i++)
                        cmbIdRez.Items.Add(listaRezervacije[i].Id);
                    break;


                default:
                    break;
            }
        }
        private void IzbrisiKorisnika()
        {
            StreamWriter writer = new StreamWriter(fajlKorisnici);
            listaKorisnici.Remove(listaKorisnici[cmbIdKor.SelectedIndex]);
            for (int i = 0; i < listaKorisnici.Count; i++)
                writer.WriteLine(listaKorisnici[i].ToString());
            cmbIdKor.Items.Clear();
            writer.Close();

            for (int i = 0; i < listaKorisnici.Count; i++)
                cmbIdKor.Items.Add(listaKorisnici[i].Id);

            cmbIdKor.SelectedIndex=-1;
            txtImeKor.Text = "";
            txtPrezimeKor.Text = "";
            txtKorisnickoIme.Text = "";
            txtLozinka.Text = "";
            cmbVrKor.SelectedIndex = -1;

            MessageBox.Show("Uspešno ste izbrisali korisnika!");
        }
        ///
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            btnOdustani.Enabled = false;
            switch (tabControl1.SelectedIndex)
            {
                case 0: OdustaniGost(); break;
                case 1: OdustaniSoba(); break;
                case 2: OdustaniRezervacija(); break;
                case 3: OdustaniKorisnik(); break;
            }
        }
        private void OdustaniGost()
        {
            cmbIdGosta.Enabled = true;
            cmbIdGosta.SelectedIndex = -1;

            txtImeGosta.Enabled = false;
            txtImeGosta.Text = "";

            txtPrezimeGosta.Enabled = false;
            txtPrezimeGosta.Text = "";

            dtpGost.Enabled = false;
            dtpGost.Value = DateTime.Now.Date;

            txtTelefonGosta.Enabled = false;
            txtTelefonGosta.Text = "";

            btnDodaj.Enabled = true;
            btnIzmeni.Enabled = true;
            btnIzbrisi.Enabled = true;

            tbpGost.Controls.Remove(btnSacuvajUnos);
            tbpGost.Controls.Remove(btnSacuvajIzmene);
        }
        private void OdustaniSoba()
        {
            cmbIdSobe.Enabled = true;
            cmbIdSobe.SelectedIndex = -1;

            txtBrojSobe.Enabled = false;
            txtBrojSobe.Text = "";

            txtBrojKreveta.Enabled = false;
            txtBrojKreveta.Text = "";

            txtTipSobe.Enabled = false;
            txtTipSobe.Text = "";

            txtCena.Enabled = false;
            txtCena.Text = "";

            txtPopust.Enabled = false;
            txtPopust.Text = "";

            txtMinBrDana.Enabled = false;
            txtMinBrDana.Text = "";

            btnDodaj.Enabled = true;
            btnIzmeni.Enabled = true;
            btnIzbrisi.Enabled = true;

            tbpSoba.Controls.Remove(btnSacuvajUnos);
            tbpSoba.Controls.Remove(btnSacuvajIzmene);
        }
        private void OdustaniRezervacija()
        {
            cmbIdRez.Enabled = true;
            cmbIdRez.SelectedIndex = -1;

            cmbIdSobeRez.Enabled = false;
            cmbIdSobeRez.SelectedIndex = -1;

            cmbIdGostaRez.Enabled = false;
            cmbIdGostaRez.Text = "";

            dtpDatumOd.Enabled = false;
            dtpDatumOd.MaxDate = new DateTime(DateTime.Now.Year + 10, DateTime.Now.Month, DateTime.Now.Day);
            dtpDatumOd.MinDate = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);
            dtpDatumOd.Value = DateTime.Now.Date;
            dtpDatumOd.MinDate = DateTime.Now;
            dtpDatumOd.MaxDate = dtpDatumOd.Value.AddYears(1);

            dtpDatumDo.Enabled = false;
            dtpDatumDo.MaxDate = new DateTime(DateTime.Now.Year + 10, DateTime.Now.Month, DateTime.Now.Day);
            dtpDatumDo.MinDate = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);
            dtpDatumDo.Value = dtpDatumOd.Value.AddDays(1);

            txtUkupnaCena.Text = "";

            txtTipRez.Enabled = false;
            txtTipRez.Text = "";

            btnDodaj.Enabled = true;
            btnIzmeni.Enabled = true;
            btnIzbrisi.Enabled = true;

            tbpRez.Controls.Remove(btnSacuvajUnos);
            tbpRez.Controls.Remove(btnSacuvajIzmene);
        }
        private void OdustaniKorisnik()
        {
            cmbIdKor.Enabled = true;
            cmbIdKor.SelectedIndex = -1;

            txtImeKor.Enabled = false;
            txtImeKor.Text = "";

            txtPrezimeKor.Enabled = false;
            txtPrezimeKor.Text = "";

            txtKorisnickoIme.Enabled = false;
            txtKorisnickoIme.Text = "";

            txtLozinka.Enabled = false;
            txtLozinka.Text = "";

            cmbVrKor.Enabled = false;
            cmbVrKor.SelectedIndex = -1;

            btnDodaj.Enabled = true;
            btnIzmeni.Enabled = true;
            btnIzbrisi.Enabled = true;

            tbpKorisnik.Controls.Remove(btnSacuvajUnos);
            tbpKorisnik.Controls.Remove(btnSacuvajIzmene);
        }



        //Ucitavanje podataka kad se promeni izabrani index
        private void cmbIdGosta_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbIdGosta.SelectedIndex != -1)
            { 
                txtImeGosta.Text = listaGosti[cmbIdGosta.SelectedIndex].Ime;
                txtPrezimeGosta.Text = listaGosti[cmbIdGosta.SelectedIndex].Prezime;
                dtpGost.Value = listaGosti[cmbIdGosta.SelectedIndex].Datum_rodjenja;
                txtTelefonGosta.Text = listaGosti[cmbIdGosta.SelectedIndex].Telefon;
            }
        }

        private void cmbIdSobe_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbIdSobe.SelectedIndex != -1)
            {
                txtBrojSobe.Text = listaSobe[cmbIdSobe.SelectedIndex].BrojSobe + "";
                txtBrojKreveta.Text = listaSobe[cmbIdSobe.SelectedIndex].BrojKreveta + "";
                txtTipSobe.Text = listaSobe[cmbIdSobe.SelectedIndex].TipSobe;
                txtCena.Text = listaSobe[cmbIdSobe.SelectedIndex].Cena + "";
                txtPopust.Text = listaSobe[cmbIdSobe.SelectedIndex].Popust + "";
                txtMinBrDana.Text = listaSobe[cmbIdSobe.SelectedIndex].MinBrDana + "";
            }
        }

        private void cmbIdRez_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbIdRez.SelectedIndex != -1)
            {
                InformacijeRezervacije();
            }
        }

        //Ucitvanje informacija za rezervacije
        private void InformacijeRezervacije()
        {
            //Proverava koji je index sobe u listi soba i taj index izabere u combo box-u jer je redosled isti.
            for (int i = 0; i < cmbIdSobeRez.Items.Count; i++)
                if (listaRezervacije[cmbIdRez.SelectedIndex].IdSobe == listaSobe[i].ID1)
                    cmbIdSobeRez.SelectedIndex = i;

            for (int i = 0; i < cmbIdGostaRez.Items.Count; i++)
                if (listaRezervacije[cmbIdRez.SelectedIndex].IdGosta == listaGosti[i].Id)
                    cmbIdGostaRez.SelectedIndex = i;

            dtpDatumDo.MaxDate = new DateTime(DateTime.Now.Year + 10, DateTime.Now.Month, DateTime.Now.Day);
            dtpDatumDo.MinDate = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);
            dtpDatumOd.Value = listaRezervacije[cmbIdRez.SelectedIndex].DatumOd;
            dtpDatumDo.Value = listaRezervacije[cmbIdRez.SelectedIndex].DatumDo;
            txtUkupnaCena.Text = listaRezervacije[cmbIdRez.SelectedIndex].UkupnaCena + "";
            txtTipRez.Text = listaRezervacije[cmbIdRez.SelectedIndex].TipRezervacije;
        }

        private void cmbIdSobeRez_DropDownClosed(object sender, EventArgs e)
        {
            if(cmbIdSobeRez.SelectedIndex!=-1)
            {
                txtUkupnaCena.Text = listaSobe[cmbIdSobeRez.SelectedIndex].Cena - (listaSobe[cmbIdSobeRez.SelectedIndex].Cena * listaSobe[cmbIdSobeRez.SelectedIndex].Popust / 100) + "";
                dtpDatumDo.Enabled = false;
                dtpDatumOd.MaxDate = new DateTime(DateTime.Now.Year + 10, DateTime.Now.Month, DateTime.Now.Day);
                dtpDatumDo.MinDate = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);
                dtpDatumOd.Value = DateTime.Now.Date;
                dtpDatumDo.Value = DateTime.Now.Date;
            }
        }
        private void cmbIdKor_DropDownClosed(object sender, EventArgs e)
        {
            if(cmbIdKor.SelectedIndex!=-1)
            {
                txtImeKor.Text = listaKorisnici[cmbIdKor.SelectedIndex].Ime;
                txtPrezimeKor.Text = listaKorisnici[cmbIdKor.SelectedIndex].Prezime;
                txtKorisnickoIme.Text = listaKorisnici[cmbIdKor.SelectedIndex].KorisnickoIme;
                txtLozinka.Text = listaKorisnici[cmbIdKor.SelectedIndex].Lozinka;
                if (listaKorisnici[cmbIdKor.SelectedIndex].VrstaK == "a")
                    cmbVrKor.SelectedIndex = 0;
                else
                    cmbVrKor.SelectedIndex = 1;
            }
        }

        //private void MenjanjeDatumaRez()
        //{
        //dtpdatumdo.maxdate = new datetime(datetime.now.year + 10, datetime.now.month, datetime.now.day);
        //dtpdatumdo.mindate = new datetime(datetime.now.year - 10, datetime.now.month, datetime.now.day);
        //    dtpDatumDo.Value = dtpDatumOd.Value.AddDays(listaSobe[cmbIdSobeRez.SelectedIndex].MinBrDana);
        //    dtpDatumDo.MaxDate = dtpDatumOd.Value.AddDays(10);
        //    dtpDatumDo.MinDate = dtpDatumOd.Value.AddDays(listaSobe[cmbIdSobeRez.SelectedIndex].MinBrDana);
        //    dtpDatumDo.MinDate = dtpDatumDo.Value;
        //}

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (izabraniID != -1)
                tabControl1.SelectedTab =  tbpRez;
            if(btnOdustani.Enabled)
            {
                e.Cancel = true;
            }
        }
      //  dtpDatumOd.Value.Date.Day <= listaRezervacije[i].DatumDo.Date.Day && dtpDatumOd.Value.Date.Day >= listaRezervacije[i].DatumOd.Date.Day && (dtpDatumOd.Value.Date.Month == listaRezervacije[i].DatumOd.Date.Month || dtpDatumOd.Value.Date.Month == listaRezervacije[i].DatumDo.Date.Month
        private void ProveraOdDatuma()
        {
            int brojPoklapanjaDatuma = 0, maxDana = 10;
            for (int i = 0; i < listaRezervacije.Count; i++)
                if (Int32.Parse(cmbIdSobeRez.SelectedItem.ToString()) == listaRezervacije[i].IdSobe && listaRezervacije[i].Id != Int32.Parse(cmbIdRez.SelectedItem.ToString()))
                {
                    if ((dtpDatumOd.Value.Date >= listaRezervacije[i].DatumOd.Date && dtpDatumOd.Value.Date <= listaRezervacije[i].DatumDo.Date))
                        brojPoklapanjaDatuma++;
                    if (listaRezervacije[i].DatumOd > dtpDatumOd.Value.Date)
                        if (listaRezervacije[i].DatumOd.Subtract(dtpDatumOd.Value.Date).Days <= 10)
                            maxDana = listaRezervacije[i].DatumOd.Subtract(dtpDatumOd.Value.Date).Days - 1;
                }
            if (brojPoklapanjaDatuma == 0)
            {
                if (maxDana < listaSobe[cmbIdSobeRez.SelectedIndex].MinBrDana)
                    MessageBox.Show("Izabrani datum je nedostupan!");
                else
                {
                    dtpDatumDo.MaxDate = new DateTime(DateTime.Now.Year + 10, DateTime.Now.Month, DateTime.Now.Day);
                    dtpDatumDo.MinDate = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);
                    dtpDatumDo.Value = dtpDatumOd.Value.AddDays(listaSobe[cmbIdSobeRez.SelectedIndex].MinBrDana);
                    dtpDatumDo.MinDate = dtpDatumDo.Value;
                    dtpDatumDo.MaxDate = dtpDatumOd.Value.AddDays(maxDana);
                    dtpDatumDo.Enabled = true;
                }
            }

            else
            {
                dtpDatumOd.Value = DateTime.Now.Date;
                dtpDatumDo.Enabled = false;
                MessageBox.Show("Izabrani datum je već rezervisan za željenu sobu ili je nedostupan.");
            }

        }

        private bool ProveraDoDatuma()
        {
            int brojPoklapanjaDatuma = 0;
            if (cmbIdSobeRez.SelectedIndex == -1)
            {
                MessageBox.Show("Niste popunili sve parametre!");
                return false;
            }
            else
            {
                for (int i = 0; i < listaRezervacije.Count; i++)
                    if (Int32.Parse(cmbIdSobeRez.SelectedItem.ToString()) == listaRezervacije[i].IdSobe && listaRezervacije[i].Id != Int32.Parse(cmbIdRez.SelectedItem.ToString()))
                        if (dtpDatumDo.Value.Date >= listaRezervacije[i].DatumOd.Date && dtpDatumDo.Value.Date <= listaRezervacije[i].DatumDo.Date)
                            brojPoklapanjaDatuma++;
                if (brojPoklapanjaDatuma == 0)
                    return true;
                else
                    return false;
            }
        }

        //private bool ProveraDatuma()
        //{
        //    int brojPoklapanjaDatuma = 0;
        //    if (listaRezervacije.Count != 0)
        //    {
        //        if (listaRezervacije[cmbIdRez.SelectedIndex].IdSobe == listaSobe[Int32.Parse(cmbIdSobeRez.SelectedItem.ToString())].ID1 && listaRezervacije[i].Id != Int32.Parse(cmbIdRez.SelectedItem.ToString()))
        //            for (int i = 0; i < listaRezervacije.Count; i++)
        //                if ((dtpDatumOd.Value.Date >= listaRezervacije[i].DatumOd && dtpDatumOd.Value.Date <= listaRezervacije[i].DatumDo.Date) ||
        //                    (dtpDatumOd.Value.Date <= listaRezervacije[i].DatumOd.Date && dtpDatumDo.Value.Date >= listaRezervacije[i].DatumOd.Date) ||
        //                    (dtpDatumDo.Value.Date >= listaRezervacije[i].DatumOd.Date && dtpDatumDo.Value.Date <= listaRezervacije[i].DatumDo.Date))
        //                {
        //                    brojPoklapanjaDatuma++;
        //                }
        //        if (brojPoklapanjaDatuma == 0)
        //            return true;
        //        else
        //        {
        //            MessageBox.Show("Datum je nedostupan!");
        //            for()

        //            return false;
        //        }
        //    }
        //    else
        //        return true;
        //}

        private bool ProveraGosta()
        {
            int brojPoklapanjaGosta = 0;
            if (cmbIdGostaRez.SelectedIndex != -1)
            {
                for (int i = 0; i < listaRezervacije.Count; i++)
                    if (Int32.Parse(cmbIdGostaRez.SelectedItem.ToString()) == listaRezervacije[i].IdGosta && Int32.Parse(cmbIdRez.SelectedItem.ToString()) != listaRezervacije[i].Id)
                        if ((dtpDatumOd.Value.Date >= listaRezervacije[i].DatumOd && dtpDatumOd.Value.Date <= listaRezervacije[i].DatumDo.Date) ||
                            (dtpDatumOd.Value.Date <= listaRezervacije[i].DatumOd.Date && dtpDatumDo.Value.Date >= listaRezervacije[i].DatumOd.Date) ||
                            (dtpDatumDo.Value.Date >= listaRezervacije[i].DatumOd.Date && dtpDatumDo.Value.Date <= listaRezervacije[i].DatumDo.Date))
                            brojPoklapanjaGosta++;
                if (brojPoklapanjaGosta == 0)
                    return true;
                else
                {
                    MessageBox.Show("Gost već ima rezervaciju u željenom terminu!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Izaberite id gosta!");
                return false;
            }
                
        }

    }
}
