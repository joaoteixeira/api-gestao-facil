using ApiGestaoFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoFacil.DataContexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Servidor> Servidores { get; set; }
        public DbSet<Campus> Campus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servidor>()
                .HasOne(e => e.Campus)
                .WithMany(e => e.Servidores)
                .HasForeignKey(e => e.CampusId);
                
        }
    }
}
