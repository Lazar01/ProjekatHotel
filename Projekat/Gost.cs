using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    internal class Gost
    {
        int id;
        string ime, prezime,telefon;
        DateTime datum_rodjenja;

        public Gost(int id, string ime, string prezime, DateTime datum_rodjenja, string telefon)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Datum_rodjenja = datum_rodjenja;
            this.Telefon = telefon;
        }

        public int Id { get => id; set => id = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime Datum_rodjenja { get => datum_rodjenja; set => datum_rodjenja = value; }
        public string Telefon { get => telefon; set => telefon = value; }

        public override string ToString()
        {
            return Id + "|" + Ime + "|" + Prezime + "|" + Datum_rodjenja.ToString("dd/MM/yyyy") + "|" + Telefon;
        }
    }
}
