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
    public partial class FormaRecepcionerRezervisanje : Form
    {
        public FormaRecepcionerRezervisanje()
        {
            InitializeComponent();
        }

        FormaRecepcioner f = new FormaRecepcioner();

        List<Gost> listaGosti = new List<Gost>();
        List<Rezervacije> listaRezervacije = new List<Rezervacije>();
        List<Soba> listaSobe = new List<Soba>();
        List<Soba> listaSlobodneSobe = new List<Soba>();

        string fajlGost = @"..\..\TekstDatoteke\gosti.txt";
        string fajlRezervacije = @"..\..\TekstDatoteke\rezervacije.txt";
        string fajlSobe = @"..\..\TekstDatoteke\sobe.txt";

        CultureInfo provider = CultureInfo.InvariantCulture;

        string ime, prezime, tekst, brTelefona, tipSobe, tipRez;
        int id, brSobe, brKreveta, cena, popust, minBrDana, idSobe, idGosta, idGostaForma;
        string[] informacije;

        DateTime datumOd, datumDo, datumRodj;

        private void lbSlobodneSobe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbSlobodneSobe.SelectedIndex!=-1)
            { 
                int idSobe = Int32.Parse(lbSlobodneSobe.SelectedItem.ToString().Substring(0, 1));
                txtUkupnaCena.Text = listaSobe[idSobe-1].Cena - (listaSobe[idSobe-1].Cena * listaSobe[idSobe-1].Popust / 100) + "";
            }
        }

        private void btnSacuvajRez_Click(object sender, EventArgs e)
        {
             int idRezervacije=listaRezervacije.Count+1;
            idGostaForma = listaGosti.Count + 1;
            if (btnDodajGosta.Enabled==false)
            {
                if (txtImeGosta.Text.Trim() != "" && txtPrezimeGosta.Text.Trim() != "" && txtTelefonGosta.Text.Trim() != "")
                {

                    if ((DateTime.Now.Year - dtpDatRodj.Value.Year) < 18)
                        MessageBox.Show("Neispravan datum! Osoba mora biti punoletna");
                    else
                    {
                        if (lbSlobodneSobe.SelectedIndex != -1 && txtTipRez.Text.Trim() != "")
                        {
                            if (lbGosti.Items.Count == 0)
                                idGostaForma = 1;
                            else
                            {
                                for (int i = 0; i < listaGosti.Count; i++)
                                    if (i + 1 < listaGosti[i].Id)
                                    {
                                        idGostaForma = i + 1;
                                        break;
                                    }
                                    else if (i == listaGosti.Count - 1)
                                        idGostaForma = listaGosti.Count + 1;
                            }

                            Gost noviGost = new Gost(idGostaForma, txtImeGosta.Text.Trim(), txtPrezimeGosta.Text.Trim(), dtpDatRodj.Value.Date, txtTelefonGosta.Text.Trim());
                            listaGosti.Add(noviGost);
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
                            StreamWriter writer = new StreamWriter(fajlGost);
                            for (int i = 0; i < listaGosti.Count; i++)
                                writer.WriteLine(listaGosti[i].ToString());
                            writer.Close();

                            ///////////////////////////////////////////////////REZERVACIJE///////////////////////////////////////////////////////////////////////////
                            if (listaRezervacije.Count == 0)
                                idRezervacije = 1;
                            else
                            {
                                for (int i = 0; i < listaRezervacije.Count; i++)
                                    if (i + 1 < listaRezervacije[i].Id)
                                    {
                                        idRezervacije = i + 1;
                                        break;
                                    }
                                    else if (i == listaRezervacije.Count - 1)
                                        idRezervacije = listaRezervacije.Count + 1;
                            }

                            if (ProveraGosta())
                            {
                                int idSobe = Int32.Parse(lbSlobodneSobe.SelectedItem.ToString().Substring(0, 1));
                                Rezervacije novaRezervacija = new Rezervacije(idRezervacije, idSobe, idGostaForma, Int32.Parse(txtUkupnaCena.Text), txtTipRez.Text.Trim(), dtpDatumOd.Value.Date, dtpDatumDo.Value.Date);
                                listaRezervacije.Add(novaRezervacija);
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

                                writer = new StreamWriter(fajlRezervacije);
                                for (int i = 0; i < listaRezervacije.Count; i++)
                                    writer.WriteLine(listaRezervacije[i].ToString());
                                writer.Close();

                                MessageBox.Show("Uspešno dodata nova rezervacija.");
                                f.Show();
                                f.Focus();
                                this.Hide();
                            }
                        }
                        else
                            MessageBox.Show("Niste izabrali sobu ili nema dostupnih u izabranom terminu ili niste uneli sve potrene informacije.");
                    }
                }
                else MessageBox.Show("Niste popunili sve informacije za gosta!");
            }
            ///////////////////////////////////////////////////IZABERI GOSTA///////////////////////////////////////////////////////////////////////////
            if (btnDodajGosta.Enabled==true)
            {
                if (lbGosti.SelectedIndex != -1)
                {
                    if (lbSlobodneSobe.SelectedIndex != -1 && txtTipRez.Text.Trim() != "")
                    {

                        if (listaRezervacije.Count == 0)
                            idRezervacije = 1;
                        else
                        {
                            for (int i = 0; i < listaRezervacije.Count; i++)
                                if (i + 1 < listaRezervacije[i].Id)
                                {
                                    idRezervacije = i + 1;
                                    break;
                                }
                                else if (i == listaRezervacije.Count - 1)
                                    idRezervacije = listaRezervacije.Count + 1;
                        }
                        idGostaForma = Int32.Parse(lbGosti.SelectedItem.ToString().Substring(0, 1));
                        int idSobe = Int32.Parse(lbSlobodneSobe.SelectedItem.ToString().Substring(0, 1));
                        if (ProveraGosta())
                        {
                            Rezervacije novaRezervacija = new Rezervacije(idRezervacije, idSobe, idGostaForma, Int32.Parse(txtUkupnaCena.Text), txtTipRez.Text.Trim(), dtpDatumOd.Value.Date, dtpDatumDo.Value.Date);
                            listaRezervacije.Add(novaRezervacija);
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


                            StreamWriter writer = new StreamWriter(fajlRezervacije);
                            for (int i = 0; i < listaRezervacije.Count; i++)
                                writer.WriteLine(listaRezervacije[i].ToString());
                            writer.Close();

                            MessageBox.Show("Uspešno dodata nova rezervacija.");
                            f.Show();
                            f.Focus();
                            this.Hide();
                        }
                    }
                    else
                        MessageBox.Show("Niste izabrali sobu ili nema dostupnih u izabranom terminu ili niste uneli sve potrebne informacije za rezervaciju.");
                
                }
                else
                    MessageBox.Show("Niste izabrali gosta!");
            }
        }

        private void cmbBrKreveta_SelectedIndexChanged(object sender, EventArgs e)
        {
            DostupneSobe();
        }

        private void cmbTipSobe_SelectedIndexChanged(object sender, EventArgs e)
        {
            DostupneSobe();
        }

        private void FormaRecepcionerRezervisanje_Load(object sender, EventArgs e)
        {
            dtpDatRodj.CustomFormat = "dd/MM/yyyy";
            dtpDatumOd.CustomFormat = "dd/MM/yyyy";
            dtpDatumDo.CustomFormat = "dd/MM/yyyy";

            dtpDatumOd.MinDate = DateTime.Now.Date;
            dtpDatumDo.Value = dtpDatumOd.Value.AddDays(1);
            dtpDatumDo.MinDate = dtpDatumOd.Value.AddDays(1);
            dtpDatumDo.MaxDate = dtpDatumOd.Value.AddDays(10);



            StreamReader sr = new StreamReader(fajlRezervacije);

            if (sr.ReadLine() != "")
            {
                sr.BaseStream.Position = 0;
                sr.DiscardBufferedData();
                while ((tekst = sr.ReadLine()) != null)
                {
                    informacije = tekst.Split('|');
                    id = Int32.Parse(informacije[0]);
                    idSobe = Int32.Parse(informacije[1]);
                    idGosta = Int32.Parse(informacije[2]);
                    cena = Int32.Parse(informacije[3]);
                    tipRez = informacije[4];
                    datumOd = DateTime.ParseExact(informacije[5], "dd/MM/yyyy", provider);
                    datumDo = DateTime.ParseExact(informacije[6], "dd/MM/yyyy", provider);

                    Rezervacije rezervacija = new Rezervacije(id, idSobe, idGosta, cena, tipRez, datumOd.Date, datumDo.Date);
                    listaRezervacije.Add(rezervacija);
                }
            }
            sr.Close();

            sr = new StreamReader(fajlSobe);

            if (sr.ReadLine() != "")
            {
                sr.BaseStream.Position = 0;
                sr.DiscardBufferedData();
                while ((tekst = sr.ReadLine()) != null)
                {
                    informacije = tekst.Split('|');
                    id = Int32.Parse(informacije[0]);
                    brSobe = Int32.Parse(informacije[1]);
                    brKreveta = Int32.Parse(informacije[2]);
                    cena = Int32.Parse(informacije[3]);
                    popust = Int32.Parse(informacije[4]);
                    minBrDana = Int32.Parse(informacije[5]);
                    tipSobe = informacije[6];
                    Soba soba = new Soba(id, brSobe, brKreveta, cena, popust, minBrDana, tipSobe);
                    listaSobe.Add(soba);
                }
            }
            sr.Close();

            sr = new StreamReader(fajlGost);

            if (sr.ReadLine() != "")
            {
                sr.BaseStream.Position = 0;
                sr.DiscardBufferedData();
                while ((tekst = sr.ReadLine()) != null)
                {
                    informacije = tekst.Split('|');
                    //MessageBox.Show(informacije[0]);
                    id = Int32.Parse(informacije[0]);
                    ime = informacije[1];
                    prezime = informacije[2];
                    datumRodj = DateTime.ParseExact(informacije[3], "dd/MM/yyyy", provider);
                    brTelefona = informacije[4];
                    Gost gost = new Gost(id, ime, prezime, datumRodj, brTelefona);
                    listaGosti.Add(gost);
                }
            }
            sr.Close();

            for (int i = 0; i < listaGosti.Count; i++)
                lbGosti.Items.Add(listaGosti[i]);


            txtImeGosta.KeyPress += TxtImeGosta_KeyPress;
            txtPrezimeGosta.KeyPress += TxtPrezimeGosta_KeyPress;
            txtTelefonGosta.KeyPress += TxtTelefonGosta_KeyPress;


        }

        private void FormaRecepcionerRezervisanje_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Show();
            f.Activate();
        }

        private void btnDodajGosta_Click(object sender, EventArgs e)
        {
            lbGosti.Enabled = false;
            btnDodajGosta.Enabled = false;
            lbGosti.SelectedIndex = -1;

            txtImeGosta.Enabled = true;
            txtPrezimeGosta.Enabled = true;
            dtpDatRodj.Enabled = true;
            txtTelefonGosta.Enabled = true;
            btnIzaberiGosta.Enabled = true;

            txtImeGosta.Focus();
        }

        private void btnIzaberiGosta_Click(object sender, EventArgs e)
        {
            txtImeGosta.Enabled = false;
            txtPrezimeGosta.Enabled = false;
            dtpDatRodj.Enabled = false;
            txtTelefonGosta.Enabled = false;
            btnIzaberiGosta.Enabled = false;
            txtImeGosta.Text = "";
            txtPrezimeGosta.Text = "";
            txtTelefonGosta.Text = "";

            lbGosti.Enabled = true;
            btnDodajGosta.Enabled = true;
        }

        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            dtpDatumDo.MaxDate = new DateTime(DateTime.Now.Year + 10, DateTime.Now.Month, DateTime.Now.Day);
            dtpDatumDo.MinDate = new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day);
            dtpDatumDo.Value = dtpDatumOd.Value.AddDays(1);
            dtpDatumDo.MaxDate = dtpDatumOd.Value.AddDays(10);
            dtpDatumDo.MinDate = dtpDatumOd.Value.AddDays(1);
            
        }

        private void dtpDatumDo_ValueChanged(object sender, EventArgs e)
        {
            DostupneSobe();
        }

        private void DostupneSobe()
        {
            if (cmbBrKreveta.SelectedIndex != -1 && cmbTipSobe.SelectedIndex != -1)
            {
                lbSlobodneSobe.Items.Clear();
                listaSlobodneSobe.Clear();
                int brojPoklapanja = 0;
                for (int i = 0; i < listaSobe.Count; i++)
                {
                    if (listaSobe[i].BrojKreveta == Int32.Parse(cmbBrKreveta.SelectedItem.ToString()) && listaSobe[i].TipSobe == cmbTipSobe.SelectedItem.ToString())
                        listaSlobodneSobe.Add(listaSobe[i]);
                }
                if (listaSlobodneSobe.Count != 0)
                {
                    if (listaRezervacije.Count != 0)
                        for (int i = 0; i < listaRezervacije.Count; i++)
                            for (int j = 0; j < listaSlobodneSobe.Count; j++)
                                if (listaRezervacije[i].IdSobe == listaSlobodneSobe[j].ID1)
                                    if ((dtpDatumOd.Value.Date >= listaRezervacije[i].DatumOd && dtpDatumOd.Value.Date <= listaRezervacije[i].DatumDo.Date) ||
                                        (dtpDatumOd.Value.Date <= listaRezervacije[i].DatumOd.Date && dtpDatumDo.Value.Date >= listaRezervacije[i].DatumOd.Date) ||
                                        (dtpDatumDo.Value.Date >= listaRezervacije[i].DatumOd.Date && dtpDatumDo.Value.Date <= listaRezervacije[i].DatumDo.Date))
                                        listaSlobodneSobe.RemoveAt(j);
                }
                if (listaSlobodneSobe.Count != 0)
                    for (int i = 0; i < listaSlobodneSobe.Count; i++)
                    {
                        if (dtpDatumDo.Value.Date.Subtract(dtpDatumOd.Value.Date).Days >= listaSlobodneSobe[i].MinBrDana && dtpDatumDo.Value.Date.Subtract(dtpDatumOd.Value.Date).Days <= 10)
                            lbSlobodneSobe.Items.Add(listaSlobodneSobe[i]);
                    }
            }
        }

        private bool ProveraGosta()
        {
            MessageBox.Show(idGostaForma+"");
            int brojPoklapanjaGosta=0;
            {
                for (int i = 0; i < listaRezervacije.Count; i++)
                    if (listaRezervacije[i].IdGosta == idGostaForma)
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

        }

        private void TxtTelefonGosta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back) && e.KeyChar != (char)Keys.Oemplus)
                    e.Handled = true;
        }

        private void TxtPrezimeGosta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }

        private void TxtImeGosta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar))
                if (e.KeyChar != ((char)Keys.Back))
                    e.Handled = true;
        }
    }
}
