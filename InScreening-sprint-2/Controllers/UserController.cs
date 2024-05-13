
using InScreening_sprint_2.DTOs;
using InScreening_sprint_2.Models;
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


        public IActionResult Cadastro(CadastroPacienteDTO request)
        {

            var user = _dataContext.Usuarios.FirstOrDefault(x => x.Email == request.Email);
            if (user != null)
            {
                return BadRequest("Usuário ja existe");
            }

            User novoCadastro = new User
            {
                Nome = request.Name,
                Cpf = request.Cpf,
                Email = request.Email,
                Senha = request.Senha,
                Rg = request.Rg,
                Orgao_emissor = request.Orgao_Emissor,
                F_paterna = request.F_Paterna,
                F_materna = request.F_Materna,
                Nascimento = request.Dt_Nascimento,
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

        public IActionResult Cadastrar(User request) {
            return View();
        }
    }
}
