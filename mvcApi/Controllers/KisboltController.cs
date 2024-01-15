using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcApi.Models;

namespace mvcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisboltController : ControllerBase
    {
        public readonly KisboltContext _context;
        
        public KisboltController(KisboltContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var minden=(from k in _context.Kisboltok select k).ToList();
            if(minden==null) return NoContent();
            return Ok(minden);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var egy = (from k in _context.Kisboltok where k.Id == id select k).FirstOrDefault();

            if(egy==null) return NotFound();
            return Ok(egy);
        }

        //egy kategória termékei
        [HttpGet("kategoria/{kat}")]
        public IActionResult Get(string kat)
        {
           //return notfound ha nincs ilyen kategória
            var termek=(from k in _context.Kisboltok where k.Kategoria==kat select k).ToList();
            if(termek==null) return NotFound();
            return Ok(termek);


        }

        //hiányzó termékek (készlet=0)
        [HttpGet("hianyzo")]
        public IActionResult GetHianyzo()
        {
            var hianyzo=(from k in _context.Kisboltok where k.Keszlet==0 select k).ToList();
            if (hianyzo == null) return NoContent();
            return Ok(hianyzo);
        }

        //termék felvétele
        [HttpPost("felvesz")]
        public async Task<IActionResult>TermekFelveszAsync (Kisbolt kisbolt)
        {
            if(!ModelState.IsValid) return BadRequest();
            _context.Kisboltok.Add(kisbolt);
            await _context.SaveChangesAsync();
            return Ok("Sikeresen hozzáadva");
        }

    }
}
