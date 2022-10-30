using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Trabalho.Final.Visual.Infra.Context;

namespace Trabalho.Final.Visual.Api
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Criando o DbContextOptionsBuilder manualmente
            var builder = new DbContextOptionsBuilder<AppDbContext>();

            builder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;User Id=postgres;Password=p@ssw0rd;Pooling=true;");

            // Cria o contexto
            return new AppDbContext(builder.Options);
        }
    }
}
