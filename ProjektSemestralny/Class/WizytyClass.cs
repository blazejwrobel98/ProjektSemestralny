using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjektSemestralny.Class
{
    class WizytyClass
    {
        Database1Entities1 db = new Database1Entities1();
        /// <summary>
        /// Pobieranie danych z tabeli Wizyta
        /// </summary>
        /// <returns>Pobieranie danych z tabeli Wizyta</returns>
        public List<Wizyta> CreateTable()
        {
            var list = db.Wizyta
                .Include("Pacjent1")
                .Include("Pracownik1")
                .ToList();
            return list;
        }
        public void DeleteRow(Wizyta wizyta)
        {
            var Query = (from el in db.Wizyta where el.WizytaID == wizyta.WizytaID select el).ToList();
            foreach (var row in Query)
            {
                db.Wizyta.Remove(row);
                db.SaveChanges();
            }
        }
        public List<Wizyta> ListRows(Wizyta wizyta)
        {
            var query = (from el in db.Wizyta where el.Pracownik == wizyta.Pracownik && el.Termin == wizyta.Termin select el).ToList();
            return query;
        }
        public bool AddRow(Wizyta wizyta)
        {
            try
            {
                db.Wizyta.Add(wizyta);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
