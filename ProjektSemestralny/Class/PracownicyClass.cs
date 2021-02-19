using System.Collections.Generic;
using System.Linq;

namespace ProjektSemestralny
{
    class PracownicyClass
    {
        Database1Entities1 db = new Database1Entities1();
        /// <summary>
        /// Pobieranie danych z tabeli Pracownik z wykluczeniem lekarzy
        /// </summary>
        /// <returns>Pobieranie danych z tabeli Pracownik z wykluczeniem lekarzy</returns>
        public List<Pracownik> CreateTable()
        {
            var x = db.Pracownik.ToList();
            return (from el in x where el.Stanowisko != "Lekarz" select el).ToList();
        }
        /// <summary>
        /// Zmiana danych pracownika
        /// </summary>
        /// <param name="pracownik"></param>
        public void ChangePracownikValue(Pracownik pracownik)
        {
            var OldValQuery = (from el in db.Pracownik where el.Pesel == pracownik.Pesel select el).ToList();
            foreach (var OldVal in OldValQuery)
            {
                OldVal.Imie = pracownik.Imie;
                OldVal.Nazwisko = pracownik.Nazwisko;
                OldVal.Stanowisko = pracownik.Stanowisko;
                OldVal.Pracuje_Od = pracownik.Pracuje_Od;
                OldVal.Pracuje_Do = pracownik.Pracuje_Do;
            }
            db.SaveChanges();
        }
        /// <summary>
        /// Usuwa pracownika ze wszystkich tabel
        /// </summary>
        /// <param name="pracownik"></param>
        public void DeletePracownik(Pracownik pracownik)
        {
            var Query = (from el in db.Pracownik where el.Pesel == pracownik.Pesel select el).ToList();
            foreach (var row in Query)
            {
                var QueryForeign = (from el in db.Wizyta where el.Pracownik == row.PracownikID select el).ToList();
                foreach (var foreign in QueryForeign)
                {
                    db.Wizyta.Remove(foreign);
                    db.SaveChanges();
                }
                var QueryHistory = (from el in db.Historia_Chorob where el.Pracownik == row.PracownikID select el).ToList();
                foreach (var history in QueryHistory)
                {
                    db.Historia_Chorob.Remove(history);
                    db.SaveChanges();
                }
                db.Pracownik.Remove(row);
            }
            db.SaveChanges();
        }
    }
}
