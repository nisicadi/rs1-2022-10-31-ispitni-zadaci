using System;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class Ovjera
    {
        public int id { get; set; }
        public int studentId { get; set; }
        public DateTime datumOvjere { get; set; }
        public string? napomenaOvjera { get; set; }
    }
}
