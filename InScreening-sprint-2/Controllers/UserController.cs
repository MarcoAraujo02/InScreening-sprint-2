

using InScreening_sprint_2.Data;
using Microsoft.AspNetCore.Mvc;

namespace InScreening_sprint_2.Controllers
{
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;

        private readonly DataContext _dataContext;
        public UserController(ILogger<UserController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Cadastrar(User request) {
            return View();
        }
    }
}
