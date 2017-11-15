using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMPING
{
    public class Pracownik : Osoba
    {
        public int cos;
        //public Pracownik(int nPersonId, string sFirstName, string sLastName, string nArDate)
        public Pracownik(int IdOsoby) : base(IdOsoby, "", "")
        {

        }
    }
}
