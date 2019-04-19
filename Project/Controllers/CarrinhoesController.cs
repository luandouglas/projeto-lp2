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
    [Route("api/carrinho")]
    [ApiController]
    public class CarrinhoesController : ControllerBase
    {
        private readonly ProjectContext _context;

        public CarrinhoesController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Carrinhoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrinho>>> GetCarrinho()
        {
            return await _context.Carrinho.ToListAsync();
        }

        // POST: api/Carrinhoes
        [HttpPost]
        public async Task<ActionResult<Carrinho>> PostCarrinho(Carrinho carrinho)
        {
            try
            {
                var loja = await _context.Loja.FirstOrDefaultAsync(e => e.Id == carrinho.LojaId);
                if (loja == null)
                {
                    return NotFound();
                }

                foreach (var a in carrinho.Camisas)
                {

                    var roupa = await _context.Roupa.FindAsync(a.RoupaId);
                    if (roupa == null)
                    {
                        return BadRequest(new Error("Erro", "Camisa invalida"));
                    }
                    if (roupa.Quantidade >= a.Quantidade)
                    {
                        var quant = roupa.Quantidade - a.Quantidade;
                        roupa.Quantidade = quant;

                        _context.Entry(roupa).State = EntityState.Modified;

                    }
                    else
                    {
                        return BadRequest(new Error("Erro", "Quantidade superior ao estoque"));
                    }

                }

                _context.Carrinho.Add(carrinho);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCarrinho", new { id = carrinho.Id }, carrinho);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }


        }
    }
}
