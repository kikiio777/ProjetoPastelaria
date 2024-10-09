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

        //adicionar servicos ao container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();//suporte pra controladores e as view
            //setar aqui pra que conheça o caminho do bd e falar qual o context e qual o db context
            //ou seja vou usar sqlserver o contexto que vou mandar e o bancocontext e adicionar a string de conexão no appsettings.json

            services.AddEntityFrameworkSqlServer() //configuracao do bando de dados
                //sistema lamba e use sql server e dentro espera uma string conection o get ´pra pegar a conceton e o nome dela

                .AddDbContext<BancoContext>(o =>o.UseSqlServer(Configuration.GetConnectionString("DataBase")));


            //toda vez que a injeção de dependencia  IFuncionarioRepositorio for chamada vai resolver vai usar tudo  da parte generica
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
            services.AddScoped<ISessao, Sessao>();
            services.AddScoped<ITarefasRepositorio, TarefasRepositorio>();
            services.AddScoped<IEmail, Email>();

            //adicionando sessao estudar como isso funciona depois
            //config da  sessao
            services.AddSession(o =>//suporte pra sessao
            {
                o.Cookie.HttpOnly = true; //cookie da sessao como http only
                o.Cookie.IsEssential = true; //essencial para o app
            });

        }

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
            app.UseStaticFiles();//permite arquivos estaticos

            app.UseRouting();//permite roteamento

            app.UseAuthorization(); //add  um middleware de atuorizacao
            //usar sesseion
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(//rota que sera seguida
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
