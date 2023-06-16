using Microsoft.EntityFrameworkCore;
using ProEventos.Application.Models;

namespace ProEventos.Application.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts):base(opts)
        {
            
        }
        public DbSet<Evento> Eventos { get; set; }
    }
}
