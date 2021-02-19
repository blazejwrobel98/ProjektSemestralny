using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny
{
    class PacjenciClass
    {
        Database1Entities1 db = new Database1Entities1();
        /// <summary>
        /// Pobieranie danych z tabeli Pacjent
        /// </summary>
        /// <returns>Pobieranie danych z tabeli Pacjent</returns>
        public List<Pacjent> CreateTable() => db.Pacjent.ToList();
        public void ChangePatientValue(Pacjent pacjent)
        {
            var OldValQuery= (from el in db.Pacjent where el.Pesel == pacjent.Pesel select el).ToList();
            foreach(var OldVal in OldValQuery)
            {
                OldVal.Imie = pacjent.Imie;
                OldVal.Nazwisko = pacjent.Nazwisko;
                OldVal.Kod_Pocztowy = pacjent.Kod_Pocztowy;
                OldVal.Miejscowosc = pacjent.Miejscowosc;
                OldVal.Ulica = pacjent.Ulica;
                OldVal.Nr_Domu = pacjent.Nr_Domu;
                OldVal.Nr_Lokalu = pacjent.Nr_Lokalu;
            }
            db.SaveChanges();
        }
        /// <summary>
        /// Usuwanie rekordu Pacjent
        /// </summary>
        /// <param name="pacjent"></param>
        public void DeletePatient(Pacjent pacjent)
        {
            var Query = (from el in db.Pacjent where el.Pesel == pacjent.Pesel select el).ToList();
            foreach(var row in Query)
            {
                var QueryForeign = (from el in db.Wizyta where el.Pacjent == row.PacjentID select el).ToList();
                foreach (var foreign in QueryForeign)
                {
                    db.Wizyta.Remove(foreign);
                    db.SaveChanges();
                }
                var QueryHistory = (from el in db.Historia_Chorob where el.Pacjent == row.PacjentID select el).ToList();
                foreach (var history in QueryHistory)
                {
                    db.Historia_Chorob.Remove(history);
                    db.SaveChanges();
                }
                db.Pacjent.Remove(row);
            }
            db.SaveChanges();
        }
    }
}
