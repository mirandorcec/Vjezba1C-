using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class Predmet
    {
        private int sifra;
        private int ects;
        private string naziv;

        public Predmet()
        {
        }

        public Predmet(int sifra, int ects, string naziv)
        {
            Sifra = sifra;
            ECTS = ects;
            Naziv = naziv;
        }

        public int Sifra { get => sifra; set => sifra = value; }
        public int ECTS { get => ects; set => ects = value; }
        public string Naziv { get => naziv; set => naziv = value; }
    }
}
