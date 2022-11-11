using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.DomainService;
using Trabalho.Final.Visual.Dominio.Interface.Repository;
using Trabalho.Final.Visual.Dominio.Interface.Services;
using Trabalho.Final.Visual.Infra.Context;
using Trabalho.Final.Visual.Infra.Repository;
using Trabalho.Final.Visual.Infra.Repository.Agenda;
using Trabalho.Final.Visual.Infra.Repository.Cliente;
using Trabalho.Final.Visual.Infra.Repository.Pet;

namespace Trabalho.Final.Visual.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AppDbContext>(
            opts =>
            {
                opts.UseNpgsql(@"Host=localhost;Port=5432;Database=postgres;User Id=postgres;Password=p@ssw0rd;Pooling=true;");
            });

            services.AddCors(o => o.AddPolicy("Pet" +
                "Policy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //servicos
            services.AddTransient<IClienteServices, ClienteServices>();
            services.AddTransient<IPetServices, PetServices>();
            services.AddTransient<IAgendaServices, AgendaServices>();

            //repository 
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPetRepository, PetRepository>();
            services.AddTransient<IAgendaRepository, AgendaRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trabalho.Final.Visual.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trabalho.Final.Visual.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
