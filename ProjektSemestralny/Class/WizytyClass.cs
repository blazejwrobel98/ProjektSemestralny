using System.Collections.Generic;
using System.Linq;
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
            foreach(var row in Query)
            {
                db.Wizyta.Remove(row);
                db.SaveChanges();
            }
        }
    }
}
