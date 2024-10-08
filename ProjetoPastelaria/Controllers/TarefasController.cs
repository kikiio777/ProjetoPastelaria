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
    //fazendo injeção de dependncias
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
        //INDEX
        public IActionResult Index()
        {
            List<TarefasModel> tarefas = _tarefasRepositorio.BuscarTodos();
            return View(tarefas);
        }
        // MEU GET CRIAR
        public IActionResult Criar()
        {
            var model = new TarefasModel();

            // Aqui estou buscando os funcionários do banco de dados
            var funcionarios = _context.Funcionarios.ToList();

            // Prenchendo a lista de SelectListItem
            model.Funcionarios = funcionarios.Select(f => new SelectListItem
            {
                Value = f.IdFuncionario.ToString(),
                Text = f.Nome // o que eu quero mostrar o nome
            }).ToList();

            return View(model);
        }

        //MEU GET EDITAR
        public IActionResult Editar(int id)
        {
            //buscar a tarefa
            TarefasModel tarefa = _tarefasRepositorio.ListarPorId(id);
            return View(tarefa);
        }
        // MEU POST EDITAR

        [HttpPost]
        //pos ja serve pra atualizar  receber e cadastrar ai esse criar vai pegar dados de funcionariomodel 
        public IActionResult Editar(TarefasModel tarefa)
        {
           
            _tarefasRepositorio.Atualizar(tarefa);
            TempData["MensagemSucesso"] = "tarefa alterada com sucesso";
            return RedirectToAction("Index");
               

        }
        //MEU GET APAGARCONFIRN
        public IActionResult ApagarConfirmacao(int id)
        {
            //buscando pelo id
            TarefasModel tarefas = _tarefasRepositorio.ListarPorId(id);
            return View(tarefas);

        }
        //GET APAGAR
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _tarefasRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "tarefa apagada com sucesso !";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar a tarefa !";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar  a tarefa ! mais detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //POST CRIAR
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
