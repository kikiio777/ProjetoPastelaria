using Microsoft.EntityFrameworkCore;
using ProjetoPastelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Data
{
    public class BancoContext : DbContext
    {
        //injetando como paramentro de entrada o dbcontextoptions para o bancocontext
        //passando a informação que esta vindo de options pra dentro de dbcontext
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        //Informar a classe que vai representar a table dentro do BD
        //configuração do contexto esta configurada
        //e avisar no startup que quando o sistema rodar ele precisa conhecer o BancoContext
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<TarefasModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir relacionamento 1:N (Um Funcionário tem várias Tarefas)
            modelBuilder.Entity<TarefasModel>()
                .HasOne(t => t.Funcionario)       // Uma tarefa tem um funcionário
                .WithMany(f => f.Tarefas)          // Um funcionário tem várias tarefas
                .HasForeignKey(t => t.Id); // A chave estrangeira é FuncionarioId
        }
    }
}
