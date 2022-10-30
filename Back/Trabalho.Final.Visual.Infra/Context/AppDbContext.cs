using Microsoft.EntityFrameworkCore;
using Trabalho.Final.Visual.Dominio.Entidades;

namespace Trabalho.Final.Visual.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

        public DbSet<Pet> Pets { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options) { }

        public AppDbContext()
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=postgres;User Id=postgres;Password=p@ssw0rd;Pooling=true;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Cliente>().HasKey(p => p.Id);
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Agendas)
                .WithOne(e => e.Cliente);

            modelBuilder.Entity<Agenda>().ToTable("Agendas");
            modelBuilder.Entity<Agenda>().HasKey(p => p.Id);
            modelBuilder.Entity<Agenda>()
                .HasOne(e => e.Cliente)
                .WithMany(c => c.Agendas);
            modelBuilder.Entity<Agenda>()
                .HasOne(e => e.Pet)
                .WithMany(c => c.Agendas);

            modelBuilder.Entity<Pet>().ToTable("Pet");
            modelBuilder.Entity<Pet>().HasKey(p => p.Id);
            modelBuilder.Entity<Pet>()
                .HasMany(c => c.Agendas)
                .WithOne(e => e.Pet);
        }
    }
}
