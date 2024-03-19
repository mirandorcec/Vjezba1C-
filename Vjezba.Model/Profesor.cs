using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public enum Zvanje
    {
        Asistent,
        Predavac,
        VisiPredavac,
        ProfVisokeSkole
    }

    public class Profesor : Osoba
    {
        public string Odjel { get; set; }
        public Zvanje Zvanje { get; set; }
        public DateTime DatumIzbora { get; set; }
        public List<Predmet> Predmeti { get;  set; }

        public Profesor(string ime, string prezime, string oib, string jmbg, string odjel, Zvanje zvanje, DateTime datumIzbora)
             : base(ime, prezime, oib, jmbg)
        {
            Odjel = odjel;
            Zvanje = zvanje;
            DatumIzbora = datumIzbora;
        }

        public Profesor(string odjel, Zvanje zvanje, DateTime datumIzbora)
        {
            Odjel = odjel;
            Zvanje = zvanje;
            DatumIzbora = datumIzbora;
        }

        public Profesor() {
            Predmeti = new List<Predmet>();
        }

        public int KolikoDoReizbora()
        {
            int periodReizbora = Zvanje == Zvanje.Asistent ? 4 : 5;
            int godineOdIzbora = DateTime.Now.Year - DatumIzbora.Year;
            int godineDoReizbora = periodReizbora - (godineOdIzbora % periodReizbora);

            return godineDoReizbora;
        }

    }
}
