using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMPING
{
    class StalyKlient : Osoba
    {
        //public int cos;
        public int iloscPrzyjazdow { get; set; } 
        public StalyKlient(int IdOsoby, string Imie, string Nazwisko, int tIloscPrzyjazdow) : base(IdOsoby, Imie, Nazwisko)
        {
            iloscPrzyjazdow = tIloscPrzyjazdow;
        }

        public StalyKlient() : base()
        {

        }
    }
}
