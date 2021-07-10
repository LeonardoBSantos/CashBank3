using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: api/Carteiras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carteira>>> GetCarteiraItems()
        {
            return await _context.CarteiraItems.Include(x => x.Cliente).ToListAsync();
        }

        // GET: api/Carteiras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carteira>> GetCarteira(string id)
        {
            var carteira = await _context.CarteiraItems.FindAsync(id);

            if (carteira == null)
            {
                return NotFound();
            }

            return carteira;
        }

        // PUT: api/Carteiras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarteira(int id, Carteira carteira)
        {
            if (id != carteira.id_carteira)
            {
                return BadRequest();
            }

            _context.Entry(carteira).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarteiraExists(id))
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

        // POST:    
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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

        // DELETE: api/Carteiras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Carteira>> DeleteCarteira(string id)
        {
            var carteira = await _context.CarteiraItems.FindAsync(id);
            if (carteira == null)
            {
                return NotFound();
            }

            _context.CarteiraItems.Remove(carteira);
            await _context.SaveChangesAsync();

            return carteira;
        }

        private bool CarteiraExists(int id)
        {
            return _context.CarteiraItems.Any(e => e.id_carteira == id);
        }
    }
}
