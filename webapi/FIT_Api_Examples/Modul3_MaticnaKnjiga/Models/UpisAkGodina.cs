using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    public class UpisAkGodina
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(student))]
        public int studentId { get; set; }
        public Student student { get; set; }
        
        [ForeignKey(nameof(akademskaGodina))]
        public int akademskaGodinaId { get; set; }
        public AkademskaGodina akademskaGodina { get; set; }
        
        public DateTime datumUpisaZimskog { get; set; }
        public DateTime datumOvjereZimskog { get; set; }
        public int godinaStudija { get; set; }
        public float cijenaSkolarine { get; set; }
        public bool isObnova { get; set; }

        [ForeignKey(nameof(evidentiraoKorisnik))]
        public int evidentiraoKorisnikId { get; set; }
        public KorisnickiNalog evidentiraoKorisnik { get; set; }

    }
}
