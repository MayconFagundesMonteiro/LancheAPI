using Microsoft.EntityFrameworkCore;

namespace LancheAPI.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
    }
}
