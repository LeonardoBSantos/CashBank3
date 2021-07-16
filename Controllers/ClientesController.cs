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
    public class ClientesController : ControllerBase
    {
        private readonly ClienteContext _context;

        public ClientesController(ClienteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClienteItems()
        {
            return await _context.ClienteItems.Include(x => x.Carteira).ToListAsync();
        }

        [HttpGet("{email_proprietario}")]
        public async Task<ActionResult<Cliente>> GetCliente(string email_proprietario)
        {
            var cliente = await _context.ClienteItems.FindAsync(email_proprietario);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPut("{email_proprietario}")]
        public async Task<IActionResult> PutCliente(string email_proprietario, Cliente cliente)
        {
            if (email_proprietario != cliente.email_proprietario)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(email_proprietario))
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

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.ClienteItems.Add(cliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClienteExists(cliente.email_proprietario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCliente", new { email_proprietario = cliente.email_proprietario }, cliente);
        }

        private bool ClienteExists(string email_proprietario)
        {
            return _context.ClienteItems.Any(e => e.email_proprietario == email_proprietario);
        }
    }
}
