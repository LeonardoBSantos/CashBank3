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
        public DbSet<Carteira> CarteiraItems { get; set; }
        public DbSet<Carteira> TransacaoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().HasKey(p => p.email_proprietario);
            modelBuilder.Entity<Cliente>().Property(p => p.email_proprietario).IsRequired();

            modelBuilder.Entity<Carteira>().HasKey(p => p.id_carteira);
            modelBuilder.Entity<Carteira>().Property(p => p.fk_email_proprietario).IsRequired();
            modelBuilder.Entity<Carteira>().HasIndex(p => p.fk_email_proprietario).IsUnique();
            modelBuilder.Entity<Carteira>().Property(p => p.id_carteira).ValueGeneratedOnAdd();
            modelBuilder.Entity<Carteira>().Property(p => p.saldo).HasDefaultValue(0);
            modelBuilder.Entity<Carteira>()
                .HasOne(p => p.Cliente)
                .WithOne(p => p.Carteira)
                .HasForeignKey<Carteira>(p => p.fk_email_proprietario);

            modelBuilder.Entity<Transacao>()
                .HasOne(p => p.Carteira)
                .WithMany(p => p.Transacao);
        }

        public DbSet<CashBank3.Models.Transacao> Transacao { get; set; }
    }
}
