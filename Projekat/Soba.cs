using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    internal class Soba
    {
        int ID, brojSobe, brojKreveta, cena, popust, minBrDana;
        string tipSobe;

        public Soba(int iD, int brojSobe, int brojKreveta, int cena, int popust, int minBrDana, string tipSobe)
        {
            ID1 = iD;
            this.BrojSobe = brojSobe;
            this.BrojKreveta = brojKreveta;
            this.Cena = cena;
            this.Popust = popust;
            this.MinBrDana = minBrDana;
            this.TipSobe = tipSobe;
        }

        public int ID1 { get => ID; set => ID = value; }
        public int BrojSobe { get => brojSobe; set => brojSobe = value; }
        public int BrojKreveta { get => brojKreveta; set => brojKreveta = value; }
        public int Cena { get => cena; set => cena = value; }
        public int Popust { get => popust; set => popust = value; }
        public int MinBrDana { get => minBrDana; set => minBrDana = value; }
        public string TipSobe { get => tipSobe; set => tipSobe = value; }

        public override string ToString()
        {
            return ID1 + "|" + BrojSobe + "|" + BrojKreveta + "|" + Cena + "|" + Popust + "|" + MinBrDana + "|" + TipSobe;
        }
    }
}
