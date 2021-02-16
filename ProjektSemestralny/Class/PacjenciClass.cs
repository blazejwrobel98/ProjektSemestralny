using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny
{
    class PacjenciClass
    {
        Database1Entities db = new Database1Entities();
        /// <summary>
        /// Pobieranie danych z tabeli Pacjent
        /// </summary>
        /// <returns>Pobieranie danych z tabeli Pacjent</returns>
        public List<Pacjent> CreateTable() => db.Pacjent.ToList();
    }
}
