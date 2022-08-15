using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    internal class Korisnik
    {
        string ime, prezime, korisnickoIme, lozinka, vrstaK;
        int id;

        public Korisnik(string ime, string prezime, string korisnickoIme, string lozinka, string vrstaK, int id)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.VrstaK = vrstaK;
            this.Id = id;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public int Id { get => id; set => id = value; }
        public string VrstaK { get => vrstaK; set => vrstaK = value; }

        public override string ToString()
        {
            return Id + "|" + KorisnickoIme + "|" + Lozinka + "|" + Ime + "|" + Prezime + "|" + vrstaK;
        }
    }
}
