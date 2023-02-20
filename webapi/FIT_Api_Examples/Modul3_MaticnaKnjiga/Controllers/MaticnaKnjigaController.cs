using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
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
        public ActionResult<List<UpisAkGodinaVM>> GetByStudent(int id)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            return Ok(_dbContext.UpisAkGodina
                .Where(s => s.studentId == id)
                .Select(x => new UpisAkGodinaVM
                {
                    id= x.id,
                    akademskaGodina = x.akademskaGodina.opis,
                    korisnik = x.korisnik.korisnickoIme,
                    datumUpisa= x.datumUpisa,
                    datumOvjere= x.datumOvjere,
                    cijenaSkolarine = x.cijenaSkolarine,
                    godinaStudija = x.godinaStudija,
                    isObnova = x.isObnova
                })
                .OrderByDescending(x => x.datumUpisa)
                .ToList());
        }

        [HttpPost]
        public ActionResult SaveChanges(UpisAkGodina upis)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            UpisAkGodina saveUpis;

            if(upis.id == 0)
            {
                saveUpis = upis;
                saveUpis.korisnikId = HttpContext.GetLoginInfo().korisnickiNalog.id;
                _dbContext.UpisAkGodina.Add(saveUpis);
            } else
            {
                saveUpis = _dbContext.UpisAkGodina.Find(upis.id);
                if(saveUpis.datumOvjere== null && upis.datumOvjere != null)
                {
                    saveUpis.datumOvjere = upis?.datumOvjere;
                    saveUpis.ovjeraNapomena = upis?.ovjeraNapomena;
                }
            }
            _dbContext.SaveChanges();

            return Ok();
        }


    }
}
