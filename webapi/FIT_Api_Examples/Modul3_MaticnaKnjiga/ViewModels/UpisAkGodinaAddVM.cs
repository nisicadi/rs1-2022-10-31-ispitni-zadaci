using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class UpisAkGodinaAddVM
    {
        public int studentId { get; set; }

        public int akademskaGodinaId { get; set; }

        public DateTime datumUpisaZimskog { get; set; }
        public int godinaStudija { get; set; }
        public float cijenaSkolarine { get; set; }
        public bool isObnova { get; set; }

        public int evidentiraoKorisnik { get; set; }
    }
}
