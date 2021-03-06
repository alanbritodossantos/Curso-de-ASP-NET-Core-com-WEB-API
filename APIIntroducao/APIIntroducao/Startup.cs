using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIIntroducao.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace APIIntroducao
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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("produtoDB")
            );
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            if (!context.Categorias.Any())
            {
                context.Categorias.AddRange(new List<Categoria>() {
                    new Categoria(){Nome = "Alimentos"},
                    new Categoria(){Nome = "Bebidas"},
                    new Categoria(){Nome = "Limpeza"}
                });

                context.SaveChanges();
            }
        }
    }
}
