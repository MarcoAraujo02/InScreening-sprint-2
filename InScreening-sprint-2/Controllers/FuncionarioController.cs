using InScreening_sprint_2.Data;
using InScreening_sprint_2.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InScreening_sprint_2.Controllers
{
    public class FuncionarioController : Controller
    {


        private readonly ILogger<FuncionarioController> _logger;



        private readonly DataContext _dataContext;


        public FuncionarioController(ILogger<FuncionarioController> logger, DataContext dataContext)


        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Cadastrar(CadastroFuncionarioDTO request)
        {

            var funcionario = _dataContext.Funcionario.FirstOrDefault(x => x.Email == request.Email);

            if (funcionario != null)
            {
                return BadRequest("Usuário ja existe");
            }

            Funcionario novoFuncionario = new Funcionario
            {
                Nome = request.Nome,
                Email = request.Email,
                Cpf = request.Cpf
            };

            _dataContext.Add(novoFuncionario);
            _dataContext.SaveChanges();
            return View("Login");
        }



        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logar(LoginFuncionarioDTO request)
        {
            var find = _dataContext.Funcionario.FirstOrDefault(x => x.Email == request.Email);
            if (find == null)
            {
                return BadRequest("Email invalido");
            }
            if (find.Cpf != request.Cpf)
            {
                return BadRequest("Cpf invalido");
            }
            return View("Index");
        }



        public IActionResult Exame()
        {
            return View();
        }


        public async Task<IActionResult> Lista()
        {
            var funcionarios = await _dataContext.Funcionario.ToListAsync();

            return View(funcionarios);
        }
    }
}
