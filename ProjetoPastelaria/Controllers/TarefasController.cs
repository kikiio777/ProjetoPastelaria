using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProjetoPastelaria.Data;
using ProjetoPastelaria.Filters;
using ProjetoPastelaria.Helpers;
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
        private readonly IEmail _email;
        //injetando a tarefarepositorio
        public TarefasController(ITarefasRepositorio tarefasRepositorio, BancoContext context, IEmail email)
        {
            _tarefasRepositorio = tarefasRepositorio;
            _context = context; // Inicializando o contexto
            _email = email;
        }


        //INDEX
        // INDEX
        // INDEX
        public IActionResult Index()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");
            FuncionarioModel funcionario = JsonConvert.DeserializeObject<FuncionarioModel>(sessaoUsuario);
            ViewBag.PerfilUsuarioLogado = funcionario?.Perfil;

            // Filtra as tarefas apenas para o funcionário logado
            var tarefas = _context.Tarefas
                                  .Where(t => t.IdFuncionario == funcionario.IdFuncionario) // Filtra pelas tarefas atribuídas ao funcionário
                                  .ToList();

            var funcionarios = _context.Funcionarios.ToList(); // Obtém a lista de funcionários

            // Criar um dicionário para mapear ID do funcionário ao nome
            var funcionarioDict = funcionarios.ToDictionary(f => f.IdFuncionario, f => f.Nome);

            ViewBag.FuncionarioDict = funcionarioDict; // Passar o dicionário para a view
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

        // POST CRIAR
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

                // Enviar e-mail para o funcionário responsável
                var funcionarioResponsavel = _context.Funcionarios.Find(tarefa.IdFuncionario);
                if (funcionarioResponsavel != null)
                {
                    string assunto = "Nova Tarefa Atribuída";
                    string mensagem = $"Olá {funcionarioResponsavel.Nome},<br><br>Uma nova tarefa foi criada para você: {tarefa.Descricao}.<br><br>Atenciosamente,<br>Equipe da Pastelaria.";

                    _email.Enviar(funcionarioResponsavel.Email, assunto, mensagem);
                }

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
                // Recupera a tarefa para obter o criador
                TarefasModel tarefa = _tarefasRepositorio.ListarPorId(id);
                if (tarefa == null)
                {
                    TempData["MensagemErro"] = "Tarefa não encontrada.";
                    return RedirectToAction("Index");
                }

                // Conclui a tarefa (ou você pode ter um método separado para marcar a tarefa como concluída)
                bool apagado = _tarefasRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Tarefa concluída com sucesso!";

                    // Enviar e-mail ao criador da tarefa
                    var criador = _context.Funcionarios.Find(tarefa.IdCriadorTarefa);
                    if (criador != null)
                    {
                        string assunto = "Tarefa Concluída";
                        string mensagem = $"Olá {criador.Nome},<br><br>A tarefa '{tarefa.Descricao}' foi concluída pelo funcionário responsável.<br><br>Atenciosamente,<br>Equipe da Pastelaria.";
                        _email.Enviar(criador.Email, assunto, mensagem);
                    }
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar a tarefa!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos concluir a tarefa! Mais detalhes: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}