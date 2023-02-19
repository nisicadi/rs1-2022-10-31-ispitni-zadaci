using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Controllers
{
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
        public ActionResult<MaticnaKnjigaVM> Get(int id)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var student = _dbContext.Student.Find(id);
            List<NovaUpisanaGodinaVM> lista = _dbContext.NovaUpisanaGodina
                .Where(s => s.studentId == id)
                .Select(u => new NovaUpisanaGodinaVM
                {
                    id = u.id,
                    akademskaGodina = u.akademskaGodina.opis,
                    godinaStudija = u.godinaStudija,
                    isObnova = u.isObnova,
                    datumUpisaZ = u.datumUpisaZ,
                    datumOvjere = u.datumOvjere,
                    korisnik = u.korisnik.korisnickoIme
                })
                .ToList();

            var response = new MaticnaKnjigaVM
            {
                ime = student.ime,
                prezime = student.prezime,
                listaUpisa = lista
            };

            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post(NovaUpisanaGodina nova)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            nova.korisnikId = HttpContext.GetLoginInfo().korisnickiNalog.id;

            _dbContext.NovaUpisanaGodina.Add(nova);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public ActionResult Ovjera(Ovjera ovjera)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");


            var stara = _dbContext.NovaUpisanaGodina.Find(ovjera.id);
            stara.datumOvjere = ovjera.datumOvjere;
            stara.napomenaOvjera = ovjera.napomenaOvjera;
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
