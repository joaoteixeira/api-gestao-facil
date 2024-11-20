using ApiGestaoFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoFacil.DataContexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Servidor> Servidores { get; set; }
    }
}
