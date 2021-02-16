using System.Collections.Generic;
using System.Linq;

namespace ProjektSemestralny
{
    class PracownicyClass
    {
        Database1Entities db = new Database1Entities();
        /// <summary>
        /// Pobieranie danych z tabeli Pracownik
        /// </summary>
        /// <returns>Pobieranie danych z tabeli Pracownik</returns>
        public List<Pracownik> CreateTable() => db.Pracownik.ToList();
    }
}
