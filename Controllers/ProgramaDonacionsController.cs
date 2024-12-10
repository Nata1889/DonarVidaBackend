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
    public class ProgramaDonacionsController : ControllerBase
    {
        private readonly BackendContext _context;

        public ProgramaDonacionsController(BackendContext context)
        {
            _context = context;
        }

        // GET: api/ProgramaDonacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramaDonacion>>> GetProgramasDonacion()
        {
            return await _context.ProgramasDonacion.ToListAsync();
        }

        // GET: api/ProgramaDonacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramaDonacion>> GetProgramaDonacion(int id)
        {
            var programaDonacion = await _context.ProgramasDonacion.FindAsync(id);

            if (programaDonacion == null)
            {
                return NotFound();
            }

            return programaDonacion;
        }

        // PUT: api/ProgramaDonacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramaDonacion(int id, ProgramaDonacion programaDonacion)
        {
            if (id != programaDonacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(programaDonacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramaDonacionExists(id))
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

        // POST: api/ProgramaDonacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProgramaDonacion>> PostProgramaDonacion(ProgramaDonacion programaDonacion)
        {
            _context.ProgramasDonacion.Add(programaDonacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramaDonacion", new { id = programaDonacion.Id }, programaDonacion);
        }

        // DELETE: api/ProgramaDonacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramaDonacion(int id)
        {
            var programaDonacion = await _context.ProgramasDonacion.FindAsync(id);
            if (programaDonacion == null)
            {
                return NotFound();
            }

            _context.ProgramasDonacion.Remove(programaDonacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramaDonacionExists(int id)
        {
            return _context.ProgramasDonacion.Any(e => e.Id == id);
        }
    }
}
