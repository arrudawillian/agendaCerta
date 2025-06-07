using AgendaCerta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaCerta.Data.Context
{
    public class AgendaCertaContext(DbContextOptions<AgendaCertaContext> options) : DbContext(options)
    {
        public required DbSet<Cliente> Clientes { get; set; }
        public required DbSet<Atendente> Atendentes { get; set; }
        public required DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Agendamentos)
                .WithOne(a => a.Cliente)
                .HasForeignKey(a => a.ClienteId);

            modelBuilder.Entity<Atendente>()
                .HasMany(a => a.Agendamentos)
                .WithOne(a => a.Atendente)
                .HasForeignKey(a => a.AtendenteId);
        }
    }
}