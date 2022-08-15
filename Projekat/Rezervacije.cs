using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    internal class Rezervacije
    {
        int id, idSobe, idGosta, ukupnaCena;
        string tipRezervacije;
        DateTime datumOd, datumDo;

        public Rezervacije(int id, int idSobe, int idGosta, int ukupnaCena, string tipRezervacije, DateTime datumOd, DateTime datumDo)
        {
            this.Id = id;
            this.IdSobe = idSobe;
            this.IdGosta = idGosta;
            this.UkupnaCena = ukupnaCena;
            this.TipRezervacije = tipRezervacije;
            this.DatumOd = datumOd;
            this.DatumDo = datumDo;
        }

        public int Id { get => id; set => id = value; }
        public int IdSobe { get => idSobe; set => idSobe = value; }
        public int IdGosta { get => idGosta; set => idGosta = value; }
        public int UkupnaCena { get => ukupnaCena; set => ukupnaCena = value; }
        public string TipRezervacije { get => tipRezervacije; set => tipRezervacije = value; }
        public DateTime DatumOd { get => datumOd; set => datumOd = value; }
        public DateTime DatumDo { get => datumDo; set => datumDo = value; }

        public override string ToString()
        {
            return Id +"|" + IdSobe + "|" + IdGosta + "|" + UkupnaCena + "|" + TipRezervacije + "|" + DatumOd.ToString("dd/MM/yyyy") + "|" + DatumDo.ToString("dd/MM/yyyy");
        }
    }
}
