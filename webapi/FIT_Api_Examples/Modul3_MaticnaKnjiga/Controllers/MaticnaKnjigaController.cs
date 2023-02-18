using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class MaticnaKnjigaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MaticnaKnjigaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<MaticnaKnjigaAddVM> GetByID(int id)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var student = _dbContext.Student.Find(id);
            var response = new MaticnaKnjigaAddVM
            {
                AkGodine = _dbContext.UpisAkGodina.Where(s => s.studentId == id)
                    .Select(u => new MaticnaKnjigaUpisiVM
                    {
                        upisAkGodID = u.id,
                        akGodOpis = u.akademskaGodina.opis,
                        godinaStudija = u.godinaStudija,
                        isObnova = u.isObnova,
                        datumOvjeraZimski = u.datumOvjereZimskog,
                        datumUpisZimski = u.datumUpisaZimskog,
                        evidentiraoKorisnik = u.evidentiraoKorisnik.korisnickoIme
                    })
                    .ToList(),
                ime = student.ime,
                prezime = student.prezime,
                studentId = student.id
            };

            return response;
        }
    }
}
