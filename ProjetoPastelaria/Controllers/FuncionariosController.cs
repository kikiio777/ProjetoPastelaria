using Microsoft.AspNetCore.Mvc;
using ProjetoPastelaria.Filters;
using ProjetoPastelaria.Models;
using ProjetoPastelaria.Repositorio;
using System.Collections.Generic;

namespace ProjetoPastelaria.Controllers
{
    [PaginaAdmin]

    public class FuncionariosController : Controller
    {
        //injeção de dependencia de ifuncionario
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        //injetando o ifuncionariorepositorio
        public FuncionariosController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }
        //quando nao estiver informando o time sao metodos get automaticamente servem so pra pegar algo
        public IActionResult Index()
        {
           List<FuncionarioModel>funcionarios = _funcionarioRepositorio.BuscarTodos();
            return View(funcionarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarPorId(id);
            return View(funcionario);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            //buscando pelo id
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarPorId(id);
            return View(funcionario);
           
        }
        public IActionResult Apagar(int id)
        {
            try
            {
              bool apagado = _funcionarioRepositorio.Apagar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Funcionario apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar  funcionario !";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro )
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar  funcionario ! mais detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        //pos ja serve pra atualizar  receber e cadastrar ai esse criar vai pegar dados de funcionariomodel 
        public IActionResult Criar(FuncionarioModel funcionario)
        {                          
                    _funcionarioRepositorio.Adicionar(funcionario);
                    return RedirectToAction("Index");            
        }

        [HttpPost]
        //pos ja serve pra atualizar  receber e cadastrar ai esse criar vai pegar dados de funcionariomodel 
        public IActionResult Alterar(FuncionarioModel funcionario)
        {
            //if (!ModelState.IsValid)
            // {
            _funcionarioRepositorio.Atualizar(funcionario);
            return RedirectToAction("Index");
            // }     

        }
    }
}
