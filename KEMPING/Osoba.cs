using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMPING
{
    public class Osoba
    {

        public int IdOsoby { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string NrPesel { get; set; }
        public string MjscPochodz { get; set; }
        public char Plec { get; set; }

        public Osoba(int nPersonId, string sFirstName, string sLastName)
        {
            IdOsoby = nPersonId;
            Imie = sFirstName;
            Nazwisko = sLastName;
        }

        public Osoba()
        {
        }
        //public Osoba() { }
    }
}
