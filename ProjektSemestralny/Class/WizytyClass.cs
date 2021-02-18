using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace ProjektSemestralny.Class
{
    class WizytyClass
    {
        Database1Entities db = new Database1Entities();
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
    }
}
