namespace ProjektSemestralny.Class
{
    class LekarzView
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Specjalizacja { get; set; }
        public int Praca_Start { get; set; }
        public int Praca_Stop { get; set; }

        public LekarzView(Pracownik pracownik)
        {
            Imie = pracownik.Imie;
            Nazwisko = pracownik.Nazwisko;
            Pesel = pracownik.Pesel;
            Specjalizacja = pracownik.Specjalizacja;
            Praca_Start = pracownik.Pracuje_Od;
            Praca_Stop = pracownik.Pracuje_Do;
        }
    }
}
