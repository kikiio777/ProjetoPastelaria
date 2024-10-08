using Microsoft.AspNetCore.Mvc;
using ProjetoPastelaria.Models;
using ProjetoPastelaria.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Controllers
{
    public class LoginController : Controller
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public LoginController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
         public IActionResult Entrar(LoginModel loginmodel)
         {
            try
            {
                //se valido entre no sistemaa
                if(ModelState.IsValid)
                {
                   FuncionarioModel  funcionario =  _funcionarioRepositorio.BuscarPLogin(loginmodel.Email);

                    if(funcionario != null)
                    {
                     if(funcionario.SenhaValida(loginmodel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = "Senha usuario invalida !";

                    }
                    TempData["MensagemErro"] = "Usuario ou senha invalidos. tente novamente.";
                }
                //se n volta para propria index de login
                return View("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"ops, nao conseguimos realizar se login tente novamente  , detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
         }
    }
}
