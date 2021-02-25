using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Class
{
    class LekarzeClass
    {
        Database1Entities1 db = new Database1Entities1();
        /// <summary>
        /// Pobieranie danych z tabeli Pracownik; wyłącznie lekarzy
        /// </summary>
        /// <returns>Pobieranie danych z tabeli Pracownik; wyłącznie lekarzy</returns>
        public List<Pracownik> CreateTable()
        {
            var x = db.Pracownik.ToList();
            return (from el in x where el.Stanowisko == "Lekarz" select el).ToList();
        }
        public void ChangeLekarzValue(Pracownik pracownik)
        {
            var OldValQuery = (from el in db.Pracownik where el.Pesel == pracownik.Pesel select el).ToList();
            foreach (var OldVal in OldValQuery)
            {
                OldVal.Imie = pracownik.Imie;
                OldVal.Nazwisko = pracownik.Nazwisko;
                OldVal.Specjalizacja = pracownik.Specjalizacja;
                OldVal.Pracuje_Od = pracownik.Pracuje_Od;
                OldVal.Pracuje_Do = pracownik.Pracuje_Do;
            }
            db.SaveChanges();
        }
        /// <summary>
        /// Usuwa pracownika ze wszystkich tabel
        /// </summary>
        /// <param name="pracownik"></param>
        public void DeleteLekarz(Pracownik pracownik)
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
        public bool AddLekarz(Pracownik pracownik)
        {
            if (WorkerExists(pracownik))
            {
                throw new Exception("Lekarz już istnieje");
            }
            else
            {
                db.Pracownik.Add(pracownik);
                db.SaveChanges();
                return true;
            }
        }
        private bool WorkerExists(Pracownik pracownik)
        {
            if ((from el in db.Pracownik where el.Pesel == pracownik.Pesel select el).ToList().Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetId(string pesel)
        {
            int id = 0;
            var query = (from el in db.Pracownik where el.Pesel == pesel select el).ToList();
            foreach (var el in query)
            {
                id = el.PracownikID;
            }
            return id;
        }
    }
}
