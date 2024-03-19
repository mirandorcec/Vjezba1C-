using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class Osoba
    {
        private string ime;
        private string prezime;
        private string oib;
        private string jmbg;

        public Osoba() { }

        public Osoba(string ime, string prezime, string oib, string jmbg)
        {
            Ime = ime;
            Prezime = prezime;
            OIB = oib;
            JMBG = jmbg;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string OIB
        {
            get => oib;
            set
            {
                if (value.Length != 11 || !value.All(char.IsDigit))
                {
                    throw new InvalidOperationException("Krivo unesen oib");
                }
                else
                {
                    oib = value;
                }
            }
        }
        public string JMBG
        {
            get => jmbg;
            set
            {
                if (value.Length != 13 || !value.All(char.IsDigit))
                {
                    throw new InvalidOperationException("Krivo unesen jmbg");
                }
                else
                {
                    jmbg = value;
                }

            }
        }

        public DateTime DatumRodjenja
        {
            get
            {
                int dan = int.Parse(JMBG.Substring(0, 2));
                int mjesec = int.Parse(JMBG.Substring(2, 2));
                int godina = int.Parse(JMBG.Substring(4, 3));
                godina += (godina >= 900) ? 1000 : 2000;

                return new DateTime(godina, mjesec, dan);
            }
        }
    }
}
