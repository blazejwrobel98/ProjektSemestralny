using System.Collections.Generic;
using System.Linq;

namespace ProjektSemestralny
{
    class PracownicyClass
    {
        Database1Entities db = new Database1Entities();
        /// <summary>
        /// Pobieranie danych z tabeli Pracownik z wykluczeniem lekarzy
        /// </summary>
        /// <returns>Pobieranie danych z tabeli Pracownik z wykluczeniem lekarzy</returns>
        public List<Pracownik> CreateTable()
        {
            var x = db.Pracownik.ToList();
            return (from el in x where el.Stanowisko != "Lekarz" select el).ToList();
        }
    }
}
