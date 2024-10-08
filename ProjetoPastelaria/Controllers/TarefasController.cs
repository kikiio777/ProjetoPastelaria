using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProjetoPastelaria.Data;
using ProjetoPastelaria.Filters;
using ProjetoPastelaria.Models;
using ProjetoPastelaria.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Controllers
{
    //fazendo injeção de dependncias
    //so acessa esta pagina se o usuario estiver logado
    [PaginaUserLogado]

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
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");
            FuncionarioModel funcionario = JsonConvert.DeserializeObject<FuncionarioModel>(sessaoUsuario);

            // Configurando o ViewBag com o perfil do usuário
            ViewBag.PerfilUsuarioLogado = funcionario?.Perfil;

            var tarefas = _context.Tarefas.ToList(); // Obtém a lista de tarefas
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
        public IActionResult Criar(TarefasModel tarefa)
        {
            if (ModelState.IsValid)
            {
                // Recupera a sessão do usuário logado
                string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");
                FuncionarioModel funcionarioLogado = JsonConvert.DeserializeObject<FuncionarioModel>(sessaoUsuario);

                if (funcionarioLogado != null)
                {
                    // Define o IdCriadorTarefa como o Id do funcionário logado
                    tarefa.IdCriadorTarefa = funcionarioLogado.IdFuncionario;
                }

                _tarefasRepositorio.Adicionar(tarefa);
                TempData["MensagemSucesso"] = "Tarefa criada com sucesso!";
                return RedirectToAction("Index");
            }

            // Se o modelo não é válido, repopular a lista de funcionários para o SelectList
            var funcionarios = _context.Funcionarios.ToList();
            tarefa.Funcionarios = funcionarios.Select(f => new SelectListItem
            {
                Value = f.IdFuncionario.ToString(),
                Text = f.Nome
            }).ToList();

            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Concluir(int id)
        {
            try
            {
                bool apagado = _tarefasRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "tarefa concluida com sucesso !";
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
    }
}