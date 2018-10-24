using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CeoWebServices.Models;

namespace CeoWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly CeoContext _context;

        public ProyectosController(CeoContext context)
        {
            _context = context;
        }

        // GET: api/Proyectos
        [HttpGet]
        public IEnumerable<Proyectos> GetProyectos()
        {
            return _context.Proyectos;
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProyectos([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proyectos = await _context.Proyectos.FindAsync(id);

            if (proyectos == null)
            {
                return NotFound();
            }

            return Ok(proyectos);
        }

        // GET: api/Proyectos/search/keyword

        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> GetProyectos([FromRoute] string keyword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Proyectos> proyectos = await _context.Proyectos.Where(m => m.PryNombreDelProyecto.Contains(keyword)).ToListAsync();

            if (proyectos == null)
            {
                return NotFound();
            }

            return Ok(proyectos);
        }
        // GET: api/Proyectos/clientes

        [HttpGet("clientes")]
        public async Task<IActionResult> GetClientes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Proyectos> proyectos = await _context.Proyectos.Include(p => p.PryIdEmpresaNavigation)
                .ToListAsync();

            if (proyectos == null)
            {
                return NotFound();
            }

            return Ok(proyectos);
        }

        // PUT: api/Proyectos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyectos([FromRoute] decimal id, [FromBody] Proyectos proyectos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proyectos.PryIdProyecto)
            {
                return BadRequest();
            }

            _context.Entry(proyectos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectosExists(id))
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

        // POST: api/Proyectos
        [HttpPost]
        public async Task<IActionResult> PostProyectos([FromBody] Proyectos proyectos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Proyectos.Add(proyectos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyectos", new { id = proyectos.PryIdProyecto }, proyectos);
        }

        // DELETE: api/Proyectos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyectos([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proyectos = await _context.Proyectos.FindAsync(id);
            if (proyectos == null)
            {
                return NotFound();
            }

            _context.Proyectos.Remove(proyectos);
            await _context.SaveChangesAsync();

            return Ok(proyectos);
        }

        private bool ProyectosExists(decimal id)
        {
            return _context.Proyectos.Any(e => e.PryIdProyecto == id);
        }
    }
}