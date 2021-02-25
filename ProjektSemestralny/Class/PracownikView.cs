namespace ProjektSemestralny.Class
{
    class PracownikView
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Stanowisko { get; set; }
        public int Praca_Start { get; set; }
        public int Praca_Stop { get; set; }
        public PracownikView(Pracownik pracownik)
        {
            Imie = pracownik.Imie;
            Nazwisko = pracownik.Nazwisko;
            Pesel = pracownik.Pesel;
            Stanowisko = pracownik.Stanowisko;
            Praca_Start = pracownik.Pracuje_Od;
            Praca_Stop = pracownik.Pracuje_Do;
        }
    }
}
