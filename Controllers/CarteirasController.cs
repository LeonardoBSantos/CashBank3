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
    public class CarteirasController : ControllerBase
    {
        private readonly ClienteContext _context;

        public CarteirasController(ClienteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carteira>>> GetCarteiraItems()
        {
            return await _context.CarteiraItems.Include(x => x.Cliente).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carteira>> GetCarteira(int id)
        {
            var carteira = await _context.CarteiraItems.FindAsync(id);

            if (carteira == null)
            {
                return NotFound();
            }

            return carteira;
        }

        [HttpPost]
        public async Task<ActionResult<Carteira>> PostCarteira(Carteira carteira)
        {
            _context.CarteiraItems.Add(carteira);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarteiraExists(carteira.id_carteira))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarteira", new { id = carteira.id_carteira }, carteira);
        }

        private bool CarteiraExists(int id)
        {
            return _context.CarteiraItems.Any(e => e.id_carteira == id);
        }
    }
}
