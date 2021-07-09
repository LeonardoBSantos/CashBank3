using Microsoft.EntityFrameworkCore;

namespace CashBank3.Models
{
    public class ClienteContext: DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> ClienteItems { get; set; }
    }
}
