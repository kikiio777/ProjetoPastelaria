using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using ProjetoPastelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Filters
{
    public class PaginaUserLogado : ActionFilterAttribute
    {//verficar se  o suario esta logado  se ele estiver seguira com esse action
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controler", "Login" }, { "action", "Index" } });
            }
            else
            {
                FuncionarioModel funcionario = JsonConvert.DeserializeObject<FuncionarioModel>(sessaoUsuario);

                if (sessaoUsuario == null)
                { 
                      context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controler", "Login" }, { "action", "Index" } });
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
