
using InScreening_sprint_2.DTOs;
using InScreening_sprint_2.Models;
using InScreening_sprint_2.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Logar(LoginPacienteDTO request)
        {
            var find = _dataContext.Usuarios.FirstOrDefault(x => x.Email == request.Email);
            if (find == null)
            {
                return BadRequest("Email Invalido");
            }

            if (find.Senha != request.Senha)
            {
                return BadRequest("Senha inválida");
            }

        
            return View("~/Views/Triagem/index.cshtml");
        }


        public IActionResult Cadastro()
        {
            return View();
        }


        public async Task<IActionResult> Lista()
        {
            var usuarios = await _dataContext.Usuarios.ToListAsync();

            return View(usuarios);
        }

        public IActionResult Cadastrar(CadastroPacienteDTO request)
        {

            var usuarios = _dataContext.Usuarios.FirstOrDefault(x => x.Email == request.Email);

            if (usuarios != null)
            {
                return BadRequest("Usuário ja existe");
            }

            User novoCadastro = new User
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
                Email = request.Email,
                Senha = request.Senha,
                Rg = request.Rg,
                Orgao_emissor = request.Orgao_emissor,
                F_paterna = request.F_paterna,
                F_materna = request.F_materna,
                Nascimento = request.Nascimento,
                Sexo = request.Sexo,
                Cep = request.Cep,
                Rua = request.Rua,
                Cidade = request.Cidade,
                Complemento = request.Complemento,
                Estado = request.Estado,
                Numero = request.Numero
            };

            _dataContext.Add(novoCadastro);
            _dataContext.SaveChanges();
            return View("Login");
        
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Deletar(int id)
        {
            var usuarios = _dataContext.Usuarios.Find(id);

            _dataContext.Remove(usuarios);
            _dataContext.SaveChanges();
            return RedirectToAction("Lista");
        }


    }
}
