using Microsoft.AspNetCore.Mvc.Rendering;
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
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TarefasModel>()
            .HasOne<FuncionarioModel>()
            .WithMany(f => f.Tarefas)
            .HasForeignKey(t => t.IdFuncionario)
            .OnDelete(DeleteBehavior.Cascade); // Define o comportamento de exclusão

            modelBuilder.Entity<SelectListGroup>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<TarefasModel> Tarefas { get; set; }
    }
}
