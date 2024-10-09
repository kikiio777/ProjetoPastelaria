using Microsoft.AspNetCore.Mvc;
using ProjetoPastelaria.Helpers;
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
        private readonly ISessao _sessao;
        public LoginController(IFuncionarioRepositorio funcionarioRepositorio, ISessao sessao)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //se o usuario ja tiver logado  , redirecionar paraa a home
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
                               
            return View();
        }


        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
         public IActionResult Entrar(LoginModel loginmodel)
         {
            try
            {
                //se valido entre no sistemaa
                if(ModelState.IsValid)
                {
                    //buscando o func pelo email iformado no modllogin
                   FuncionarioModel  funcionario =  _funcionarioRepositorio.BuscarPLogin(loginmodel.Email);
                    //se ele existir 
                    if(funcionario != null)
                    {
                        // se a senha for valida vai entrar aqui no if
                     if(funcionario.SenhaValida(loginmodel.Senha))
                        {//criando sessao do usuario como paramentro o usuario que esta sendo logado
                            _sessao.CriarSessaoDoUsuario(funcionario);
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
