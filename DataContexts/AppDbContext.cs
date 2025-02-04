using ApiGestaoFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoFacil.DataContexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Servidor> Servidores { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Campus>()
            //    .HasMany(e => e.Servidores)
            //    .WithOne(e => e.Campus)
            //    .HasForeignKey(e => e.CampusId)
            //    .IsRequired(false);

            modelBuilder.Entity<Servidor>()
                .HasOne(e => e.Campus)
                .WithMany(e => e.Servidores)
                .HasForeignKey(e => e.CampusId)
                .IsRequired(false);

            modelBuilder.Entity<Servidor>()
                .HasMany(s => s.Funcoes) // Um servidor tem muitas funções
                .WithMany(f => f.Servidores) // Uma função tem muitos servidores
                .UsingEntity<Dictionary<string, object>>(
                    "servidor_funcao", // Nome da tabela de junção
                    j => j.HasOne<Funcao>().WithMany().HasForeignKey("funcao_id"), // Chave estrangeira para Funcao
                    j => j.HasOne<Servidor>().WithMany().HasForeignKey("servidor_id"), // Chave estrangeira para Servidor
                    j => j.ToTable("servidor_funcao") // Nome da tabela de junção
        );
        }
    }
}
