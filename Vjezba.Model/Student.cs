using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class Student : Osoba
    {
        private string jmbag;
        public decimal Prosjek { get; set; }
        public int BrPolozeno { get; set; }
        public int ECTS { get; set; }
        public string JMBAG
        {
            get => jmbag;
            set
            {
                if (value.Length != 10 || !value.All(char.IsDigit))
                {
                    throw new InvalidOperationException("JMBAG mora imati točno 10 znamenaka.");
                }
                jmbag = value;
            }
        }
    }
}
