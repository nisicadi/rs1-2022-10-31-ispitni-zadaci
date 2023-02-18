using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using System;
using System.Collections.Generic;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class MaticnaKnjigaAddVM
    {
        public int studentId { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }

        public List<MaticnaKnjigaUpisiVM> AkGodine { get; set; }
    }
}
