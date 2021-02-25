namespace ProjektSemestralny.Class
{
    class WizytaView
    {
        public int wizyta_id { get; set; }
        public string wizyta_data { get; set; }
        public int wizyta_godzina { get; set; }
        public string pacjent_imie { get; set; }
        public string pacjent_nazwisko { get; set; }
        public string pacjent_pesel { get; set; }
        public string lekarz_imie { get; set; }
        public string lekarz_nazwisko { get; set; }
        public string lekarz_specjalizacja { get; set; }

        public WizytaView(Wizyta wizyta)
        {
            wizyta_id = wizyta.WizytaID;
            pacjent_imie = wizyta.Pacjent1.Imie;
            pacjent_nazwisko = wizyta.Pacjent1.Nazwisko;
            pacjent_pesel = wizyta.Pacjent1.Pesel;
            wizyta_data = wizyta.Termin.ToString("dd/MM/yyyy");
            wizyta_godzina = wizyta.Godzina;
            lekarz_imie = wizyta.Pracownik1.Imie;
            lekarz_nazwisko = wizyta.Pracownik1.Nazwisko;
            lekarz_specjalizacja = wizyta.Pracownik1.Specjalizacja;
        }
    }
}
