using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class Fakultet
    {
        public List<Osoba> Osobe { get; private set; }

        public Fakultet()
        {
            Osobe = new List<Osoba>();
        }


        public int KolikoProfesora()
        {
            return Osobe.Count(osoba => osoba is Profesor);
        }

        public int KolikoStudenata()
        {
            return Osobe.Count(osoba => osoba is Student);
        }


        public Student DohvatiStudenta(string trazeniJMBAG)
        {
            return Osobe
                .OfType<Student>()
                .FirstOrDefault(student => student.JMBAG == trazeniJMBAG);
        }

        public IEnumerable<Profesor> DohvatiProfesore()
        {
            return Osobe.OfType<Profesor>().OrderBy(p => p.DatumIzbora).AsEnumerable();
        }

        public IEnumerable<Student> DohvatiStudente91()
        {
            return Osobe.OfType<Student>().Where(o => o.DatumRodjenja.Year > 1991).AsEnumerable();

        }

        public IEnumerable<Student> DohvatiStudente91NoLinq()
        {
            List<Student> studentiRodjeniNakon91 = new List<Student>();

            foreach (var osoba in Osobe)
            {
                if (osoba is Student student && osoba.DatumRodjenja.Year > 1991)
                {
                    studentiRodjeniNakon91.Add(student);
                }
            }

            return studentiRodjeniNakon91;
        }

        public IEnumerable<Student> StudentiNeTvzD()
        {
            return Osobe.OfType<Student>().Where(s => !s.JMBAG.StartsWith("0246") && s.Prezime.StartsWith("D")).AsEnumerable();
        }

        public List<Student> DohvatiStudente91List()
        {
            return Osobe.OfType<Student>().Where(o => o.DatumRodjenja.Year > 1991).ToList();

        }

        public Student NajboljiProsjek(int god)
        {
            return Osobe.OfType<Student>().Where(s => s.DatumRodjenja.Year == god).OrderByDescending(s => s.Prosjek).FirstOrDefault();
        }

        public IEnumerable<Student> StudentiGodinaOrdered(int god)
        {
            return Osobe.OfType<Student>().Where(s => s.DatumRodjenja.Year == god).OrderByDescending(s => s.Prosjek).AsEnumerable();
        }

        public IEnumerable<Profesor> SviProfesori(bool asc)
        {
            return asc == true ? Osobe.OfType<Profesor>().OrderBy(p => p.Prezime).ThenBy(p => p.Ime).AsEnumerable() : Osobe.OfType<Profesor>().OrderByDescending(p => p.Prezime).ThenByDescending(p => p.Ime).AsEnumerable();
        }

        public int KolikoProfesoraUZvanju(Zvanje zvanje)
        {
            return Osobe.OfType<Profesor>().Count(p => p.Zvanje == zvanje);
        }

        public IEnumerable<Profesor> NeaktivniProfesori(int x)
        {
            return Osobe.OfType<Profesor>().Where(p => (p.Zvanje == Zvanje.Predavac || p.Zvanje == Zvanje.VisiPredavac) && p.Predmeti.Count < x).AsEnumerable();
        }

        public IEnumerable<Profesor> AktivniAsistenti(int x, int minEcts)
        {
            return Osobe.OfType<Profesor>().Where(p => p.Zvanje == Zvanje.Asistent && p.Predmeti.Count(pr => pr.ECTS >= minEcts) > x).AsEnumerable();
        }

        public void IzmjeniProfesore(Action<Profesor> action)
        {
            Osobe.OfType<Profesor>().ToList().ForEach(action);
        }
    }
}
