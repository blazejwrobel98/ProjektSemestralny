using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Data.Linq;

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
        public string GetPacjent(int pacjentid)
        {
            var pacjenci = db.Pacjent.ToList();
            var src = from x in pacjenci where x.PacjentID == pacjentid select x;
            return string.Join(",", src);
        }
    }
}
