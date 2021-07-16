using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashBank3.Models;

namespace CashBank3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaosController : ControllerBase
    {
        private readonly ClienteContext _context;

        public TransacaosController(ClienteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetTransacao()
        {
            return await _context.Transacao.ToListAsync();
        }

        [HttpGet("{fk_id_carteira}")]
        public async Task<ActionResult<List<Transacao>>> GetTransacao(int fk_id_carteira)
        {
            var transacao = await _context.Transacao.Where(e => e.fk_id_carteira == fk_id_carteira).ToListAsync();

            if (transacao == null)
            {
                return NotFound();
            }

            return transacao;
        }

        [HttpPost]
        public async Task<ActionResult<Transacao>> PostTransacao(Transacao transacao)
        {
            _context.Transacao.Add(transacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransacao", new { id = transacao.id }, transacao);
        }

        [HttpDelete]
        public async Task<ActionResult<Transacao>> DeleteTransacao(Transacao transacao)
        {
            _context.Transacao.Add(transacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransacao", new { id = transacao.id }, transacao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransacao(int id)
        {
            var transacao = await _context.Transacao.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }

            _context.Transacao.Add(transacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransacaoExists(int id)
        {
            return _context.Transacao.Any(e => e.id == id);
        }
    }
}
