using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoPastelaria.Data;
using ProjetoPastelaria.Helpers;
using ProjetoPastelaria.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //atraves desse cara configuration consigo pegar tudo que esta dentro de appsettings
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //setar aqui pra que conheça o caminho do bd e falar qual o context e qual o db context
            //ou seja vou usar sqlserver o contexto que vou mandar e o bancocontext e adicionar a string de conexão no appsettings.json
            services.AddEntityFrameworkSqlServer()
                //sistema lamba e use sql server e dentro espera uma string conection o get ´pra pegar a conceton e o nome dela
                .AddDbContext<BancoContext>(o =>o.UseSqlServer(Configuration.GetConnectionString("DataBase")));
            //toda vez que a injeção de dependencia  IFuncionarioRepositorio for chamada vai resolver vai usar tudo  de funcionariorepositorio
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
            services.AddScoped<ISessao, Sessao>();
            services.AddScoped<ITarefasRepositorio, TarefasRepositorio>();
            services.AddScoped<IEmail, Email>();

            //adicionando sessao
            services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //usar sesseion
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
