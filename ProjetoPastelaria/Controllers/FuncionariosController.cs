using Microsoft.AspNetCore.Mvc;
using ProjetoPastelaria.Filters;
using ProjetoPastelaria.Models;
using ProjetoPastelaria.Repositorio;
using System.Collections.Generic;

namespace ProjetoPastelaria.Controllers
{
    //pagina admin usado para especificar que somente o user admin tem acesso a ela
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
        // aqui esta buscando todos os funcionarios atraves do  BuscarTodos
        // e enviando pra uma lista de funcionarios
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
            //editar com parametro int id 
            //aqui estou buscando um funcionario pelo id dele e atribindo ao funcionario volando para a view 
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarPorId(id);
            return View(funcionario);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            //buscando pelo id
            //para confirmar se ele sera apagado
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarPorId(id);
            return View(funcionario);
           
        }
        public IActionResult Apagar(int id)
        {
            try
            {
              bool apagado = _funcionarioRepositorio.Apagar(id);
                //se apagado mostra o tempdata de sucesso senao mostra de erro e volta pra index

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
            //atualizando o funcionario e voltando para a index
            _funcionarioRepositorio.Atualizar(funcionario);
            return RedirectToAction("Index");
                

        }
    }
}
