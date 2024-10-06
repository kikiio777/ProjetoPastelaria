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
            _funcionarioRepositorio.Apagar(id);
            return RedirectToAction("Index");
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
            _funcionarioRepositorio.Atualizar(funcionario);
            return RedirectToAction("Index");
        }
    }
}
