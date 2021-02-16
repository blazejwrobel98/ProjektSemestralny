using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Class
{
    class LekarzeClass
    {
        Database1Entities db = new Database1Entities();
        /// <summary>
        /// Pobieranie danych z tabeli Pracownik; wyłącznie lekarzy
        /// </summary>
        /// <returns>Pobieranie danych z tabeli Pracownik; wyłącznie lekarzy</returns>
        public List<Pracownik> CreateTable()
        {
            var x = db.Pracownik.ToList();
            return (from el in x where el.Stanowisko == "Lekarz" select el).ToList();
        }
    }
}
