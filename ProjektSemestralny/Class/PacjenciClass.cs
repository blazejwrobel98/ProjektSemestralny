using System;
using System.Collections.Generic;
using System.Linq;

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
            var OldValQuery = (from el in db.Pacjent where el.Pesel == pacjent.Pesel select el).ToList();
            foreach (var OldVal in OldValQuery)
            {
                if (OldVal.Imie != pacjent.Imie) OldVal.Imie = pacjent.Imie;
                if (OldVal.Nazwisko != pacjent.Nazwisko) OldVal.Nazwisko = pacjent.Nazwisko;
                if (OldVal.Kod_Pocztowy != pacjent.Kod_Pocztowy) OldVal.Kod_Pocztowy = pacjent.Kod_Pocztowy;
                if (OldVal.Miejscowosc != pacjent.Miejscowosc) OldVal.Miejscowosc = pacjent.Miejscowosc;
                if (OldVal.Ulica != pacjent.Ulica) OldVal.Ulica = pacjent.Ulica;
                if (OldVal.Nr_Domu != pacjent.Nr_Domu) OldVal.Nr_Domu = pacjent.Nr_Domu;
                if (OldVal.Nr_Lokalu != pacjent.Nr_Lokalu) OldVal.Nr_Lokalu = pacjent.Nr_Lokalu;
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
            foreach (var row in Query)
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
        public bool AddPatient(Pacjent pacjent)
        {
            if (PatientExists(pacjent))
            {
                throw new Exception("Pacjent już istnieje");
            }
            else
            {
                db.Pacjent.Add(pacjent);
                db.SaveChanges();
                return true;
            }
        }
        private bool PatientExists(Pacjent pacjent)
        {
            if ((from el in db.Pacjent where el.Pesel == pacjent.Pesel select el).ToList().Count > 0)
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
            var query = (from el in db.Pacjent where el.Pesel == pesel select el).ToList();
            foreach (var el in query)
            {
                id = el.PacjentID;
            }
            return id;
        }
    }
}
