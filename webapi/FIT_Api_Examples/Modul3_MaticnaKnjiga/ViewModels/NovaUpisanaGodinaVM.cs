using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class NovaUpisanaGodinaVM
    {
        public int id { get; set; }
        public string akademskaGodina { get; set; }
        public int godinaStudija { get; set; }
        public bool isObnova { get; set; }
        public DateTime datumUpisaZ { get; set; }
        public DateTime? datumOvjere { get; set; }
        public string korisnik { get; set; }
        public string? napomenaOvjera { get; set; }
    }
}
