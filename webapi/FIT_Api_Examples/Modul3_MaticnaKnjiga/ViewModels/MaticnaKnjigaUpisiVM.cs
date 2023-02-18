using System;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class MaticnaKnjigaUpisiVM
    {
        public int upisAkGodID { get; set; }
        public string akGodOpis { get; set; }
        public int godinaStudija { get; set; }
        public bool isObnova { get; set; }
        public DateTime datumUpisZimski { get; set; }
        public DateTime datumOvjeraZimski { get; set; }
        public string evidentiraoKorisnik { get; set; }
    }
}
