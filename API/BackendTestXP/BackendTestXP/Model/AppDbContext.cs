using Microsoft.EntityFrameworkCore;
using XPTesteAPI.Entities;

namespace BackendTestXP.Model
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Email> Email { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Enderecos)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Emails)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId);
        }
    }
}
