using Microsoft.EntityFrameworkCore;
using BibliotecaISLA.Models;

namespace BibliotecaISLA.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Membro> Membro { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>().ToTable("Autor");
            modelBuilder.Entity<Livro>().ToTable("Livro");
            modelBuilder.Entity<Membro>().ToTable("Membro");
            modelBuilder.Entity<Emprestimo>().ToTable("Emprestimo");
        }
    }
}