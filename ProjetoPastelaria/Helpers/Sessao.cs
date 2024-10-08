﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjetoPastelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Helpers
{
    public class Sessao : ISessao
    {
        //injeção de dependencia  usando esse http pra fazer uma sessao
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public FuncionarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            //se a string for vazia ou nul  return null
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<FuncionarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(FuncionarioModel funcionario)
        {
            string valor = JsonConvert.SerializeObject(funcionario);

            //SETAR UMA STRING PRA SESSAO ela recebe uma chave e um valor 
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
