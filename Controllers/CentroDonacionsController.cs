using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendFinal.DataContext;
using BackendFinal.Models;

namespace BackendFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentroDonacionsController : ControllerBase
    {
        private readonly BackendContext _context;

        public CentroDonacionsController(BackendContext context)
        {
            _context = context;
        }

        // GET: api/CentroDonacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CentroDonacion>>> GetCentrosDonacion()
        {
            return await _context.CentrosDonacion.ToListAsync();
        }

        // GET: api/CentroDonacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CentroDonacion>> GetCentroDonacion(int id)
        {
            var centroDonacion = await _context.CentrosDonacion.FindAsync(id);

            if (centroDonacion == null)
            {
                return NotFound();
            }

            return centroDonacion;
        }

        // PUT: api/CentroDonacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCentroDonacion(int id, CentroDonacion centroDonacion)
        {
            if (id != centroDonacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(centroDonacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentroDonacionExists(id))
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

        // POST: api/CentroDonacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CentroDonacion>> PostCentroDonacion(CentroDonacion centroDonacion)
        {
            _context.CentrosDonacion.Add(centroDonacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCentroDonacion", new { id = centroDonacion.Id }, centroDonacion);
        }

        // DELETE: api/CentroDonacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCentroDonacion(int id)
        {
            var centroDonacion = await _context.CentrosDonacion.FindAsync(id);
            if (centroDonacion == null)
            {
                return NotFound();
            }

            _context.CentrosDonacion.Remove(centroDonacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CentroDonacionExists(int id)
        {
            return _context.CentrosDonacion.Any(e => e.Id == id);
        }
    }
}
