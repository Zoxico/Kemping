using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMPING
{
    public class Pobyt : Osoba
    {
        public int cos;
        public string DataPrzyjazdu { get; set; }
        //public Pracownik(int nPersonId, string sFirstName, string sLastName, string nArDate)
        public Pobyt(int IdOsoby, string Imie, string Nazwisko, string tDataPrzyjazdu) : base(IdOsoby, Imie, Nazwisko)
        {
            DataPrzyjazdu = tDataPrzyjazdu;
        }

        public Pobyt() : base()
        {

        }
    }
}
