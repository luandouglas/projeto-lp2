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
    [Route("api/loja")]
    [ApiController]
    public class LojasController : ControllerBase
    {
        private readonly ProjectContext _context;

        public LojasController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Lojas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loja>>> GetLoja()
        {
            return await _context.Loja.Include(r => r.Roupas).Include(l => l.Compras).ThenInclude(c => c.Camisas).ThenInclude(lr => lr.Roupa).ToListAsync();
        }

        // GET: api/Lojas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loja>> GetLoja(long id)
        {
            var loja = await _context.Loja.Include(r => r.Roupas).Include(l => l.Compras).ThenInclude(c => c.Camisas).ThenInclude(lr => lr.Roupa).FirstOrDefaultAsync(d=> d.Id == id);

            if (loja == null)
            {
                return NotFound();
            }

            return loja;
        }

        // PUT: api/Lojas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoja(long id, Loja loja)
        {
            if (id != loja.Id)
            {
                return BadRequest();
            }

            _context.Entry(loja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LojaExists(id))
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

        // POST: api/Lojas
        [HttpPost]
        public async Task<ActionResult<Loja>> PostLoja(Loja loja)
        {
            _context.Loja.Add(loja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoja", new { id = loja.Id }, loja);
        }

        // DELETE: api/Lojas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loja>> DeleteLoja(long id)
        {
            var loja = await _context.Loja.FindAsync(id);
            if (loja == null)
            {
                return NotFound();
            }

            _context.Loja.Remove(loja);
            await _context.SaveChangesAsync();

            return loja;
        }

        private bool LojaExists(long id)
        {
            return _context.Loja.Any(e => e.Id == id);
        }
    }
}
