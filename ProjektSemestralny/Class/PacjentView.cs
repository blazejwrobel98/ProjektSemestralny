using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Class
{
    class PacjentView
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Kod_Pocztowy { get; set; }
        public string Miejscowosc { get; set; }
        public string Ulica { get; set; }
        public string Nr_Domu { get; set; }
        public string Nr_Lokalu { get; set; }

        public PacjentView(Pacjent pacjent)
        {
            Imie = pacjent.Imiê;
            Nazwisko = pacjent.Nazwisko;
            Pesel = pacjent.Pesel;
            Kod_Pocztowy = pacjent.Kod_Pocztowy;
            Miejscowosc = pacjent.Miejscowoœæ;
            Ulica = pacjent.Ulica;
            Nr_Domu = pacjent.Nr_Domu;
            Nr_Lokalu = pacjent.Nr_Lokalu;
        }
    }
}
