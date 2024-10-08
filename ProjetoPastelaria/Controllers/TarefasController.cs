using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoPastelaria.Data;
using ProjetoPastelaria.Models;
using ProjetoPastelaria.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ITarefasRepositorio _tarefasRepositorio;
        private readonly BancoContext _context;
        //injetando a tarefarepositorio
        public TarefasController(ITarefasRepositorio tarefasRepositorio, BancoContext context)
        {
            _tarefasRepositorio = tarefasRepositorio;
            _context = context; // Inicializando o contexto
        }
        public IActionResult Index()
        {
            List<TarefasModel> tarefas = _tarefasRepositorio.BuscarTodos();
            return View(tarefas);
        }

        public IActionResult Criar()
        {
            var model = new TarefasModel();

            // Aqui você busca os funcionários do banco de dados
            var funcionarios = _context.Funcionarios.ToList();

            // Popular a lista de SelectListItem
            model.Funcionarios = funcionarios.Select(f => new SelectListItem
            {
                Value = f.IdFuncionario.ToString(),
                Text = f.Nome // Atributo que você quer mostrar no dropdown
            }).ToList();

            return View(model);
        }



        [HttpPost]
        public IActionResult Criar(TarefasModel tarefas)
        {
            if (ModelState.IsValid)
            {
                _tarefasRepositorio.Adicionar(tarefas);
                return RedirectToAction("Index");
            }

            // Se o modelo não é válido, precisamos repopular a lista de funcionários
            var funcionarios = _context.Funcionarios.ToList();
            tarefas.Funcionarios = funcionarios.Select(f => new SelectListItem
            {
                Value = f.IdFuncionario.ToString(),
                Text = f.Nome
            }).ToList();

            return View(tarefas);
        }
    }
}
