using Microsoft.AspNetCore.Mvc;

namespace InScreening_sprint_2.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro() 
        {
            return View();
        }

        public IActionResult Lista()
        {
            return View();
        }
    }
}
