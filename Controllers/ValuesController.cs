using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Model;
using Serilog.Exceptions.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/{action}")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly WebApp.Data.DataContext _context;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(WebApp.Data.DataContext context, ILogger<ValuesController> logger)
        {
   
            _context = context;
            _logger = logger;
            _logger.LogInformation("Writing to log file with INFORMATION severity level.");

            _logger.LogDebug("Writing to log file with DEBUG severity level.");

            _logger.LogWarning("Writing to log file with WARNING severity level.");

            _logger.LogError("Writing to log file with ERROR severity level.");

            _logger.LogCritical("Writing to log file with CRITICAL severity level.");
        }

        public IList<Etudiant> Etudiants { get; set; }

        [HttpGet]
        public async Task<IList<Etudiant>> GetEtudiants()
        {
            Etudiants = await _context.Etudiant.ToListAsync();
            return Etudiants;
        }

        public Etudiant Etudiant { get; set; }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
                return "this is the string";    
        }
    

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Etudiant etudiant)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Etudiant Etudiant)
        {
            if (id != Etudiant.EtudiantID)
            {
                return BadRequest();
            }

            _context.Entry(Etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool EtudiantExists(int id)
        {
            return _context.Etudiant.Any(e => e.EtudiantID == id);
        }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            var Etudiant = await _context.Etudiant.FindAsync(id);
            if (Etudiant == null)
            {
                return NotFound();
            }

            _context.Etudiant.Remove(Etudiant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
