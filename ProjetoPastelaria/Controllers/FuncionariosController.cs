using Microsoft.AspNetCore.Mvc;
using ProjetoPastelaria.Models;
using ProjetoPastelaria.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Controllers
{
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
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }
        public IActionResult Apagar()
        {
            return View();
        }

        [HttpPost]
        //pos ja serve pra atualizar  receber e cadastrar ai esse criar vai pegar dados de funcionariomodel 
        public IActionResult Criar(FuncionarioModel funcionario)
        {
            _funcionarioRepositorio.Adicionar(funcionario);
            return RedirectToAction("Index");
        }
    }
}
