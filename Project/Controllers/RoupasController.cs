using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/roupa")]
    [ApiController]
    public class RoupasController : ControllerBase
    {
        private readonly ProjectContext _context;

        public RoupasController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Roupas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roupa>>> GetRoupa()
        {
            return await _context.Roupa.ToListAsync();
        }

        // GET: api/Roupas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roupa>> GetRoupa(long id)
        {
            var roupa = await _context.Roupa.FindAsync(id);

            if (roupa == null)
            {
                return NotFound();
            }

            return roupa;
        }
        

        // PUT: api/Roupas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoupa(long id, Roupa roupa)
        {
            if (id != roupa.Id)
            {
                return BadRequest();
            }

            _context.Entry(roupa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoupaExists(id))
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

        // PUT: api/roupa/desconto
        [HttpPut("desconto")]
        public async Task<IActionResult> PutDescontoRoupa(long id, int quantidade)
        {

            var roupa = await _context.Roupa.FindAsync(id);

            if (roupa == null)
            {
                return NotFound();
            }

            roupa.Quantidade = quantidade;
            _context.Entry(roupa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoupaExists(id))
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
        // POST: api/Roupas
        [HttpPost]
        public async Task<ActionResult<Roupa>> PostRoupa(Roupa roupa)
        {
            _context.Roupa.Add(roupa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoupa", new { id = roupa.Id }, roupa);
        }

        // DELETE: api/Roupas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Roupa>> DeleteRoupa(long id)
        {
            var roupa = await _context.Roupa.FindAsync(id);
            if (roupa == null)
            {
                return NotFound();
            }

            _context.Roupa.Remove(roupa);
            await _context.SaveChangesAsync();

            return roupa;
        }

        private bool RoupaExists(long id)
        {
            return _context.Roupa.Any(e => e.Id == id);
        }
    }
}
