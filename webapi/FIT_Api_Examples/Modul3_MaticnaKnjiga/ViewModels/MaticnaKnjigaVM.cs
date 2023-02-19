using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using System.Collections.Generic;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels
{
    public class MaticnaKnjigaVM
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public List<NovaUpisanaGodinaVM> listaUpisa { get; set; }
    }
}
