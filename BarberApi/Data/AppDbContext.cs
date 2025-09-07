using BarberApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberApi.Data
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {
        }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        
    }
}
