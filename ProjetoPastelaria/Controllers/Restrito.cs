using Microsoft.AspNetCore.Mvc;
using ProjetoPastelaria.Filters;


namespace ProjetoPastelaria.Controllers
{
    [PaginaUserLogado]
    public class Restrito : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
