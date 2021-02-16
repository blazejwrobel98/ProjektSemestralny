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
        public List<Wizyta> CreateTable() => db.Wizyta.ToList();
        public List<Pacjent> GetPacjent(int pacjentid)
        {
            var pacjenci = db.Pacjent.ToList();
            return (from x in pacjenci where x.PacjentID == pacjentid select x).ToList();
        }
    }
}
