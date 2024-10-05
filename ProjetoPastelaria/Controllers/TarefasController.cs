using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Controllers
{
    public class TarefasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
