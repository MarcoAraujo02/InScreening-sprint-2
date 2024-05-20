
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

        
        public IActionResult LoginPage()
        {
            return View();
        }



        public IActionResult index()
        {
            return View("~/ Views/User/index.cshtml");
        }


        public IActionResult DadosPaciente(int id)
        {
            var usuario = _dataContext.Usuarios.Find(id);

            if (usuario == null)
            {
                return BadRequest("Id do Paciente para puxar os dados foram perdidos, no momentos ainda a session nao foi implementada");
            }
            return View(usuario);
        }

   
        public IActionResult LogarPaciente(LoginPacienteDTO request)
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

            ViewBag.UsuarioId = find.Id;

            return View("~/Views/User/index.cshtml");
        }



    


        public IActionResult CadastroPage()
        {
            return View();
        }



        public async Task<IActionResult> ListaPaciente()
        {
            var usuarios = await _dataContext.Usuarios.ToListAsync();

            return View(usuarios);
        }



        public IActionResult CadastrarPaciente(CadastroPacienteDTO request)
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
            return View("LoginPage");
        
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult DeletarPaciente(int id)
        {
            var usuarios = _dataContext.Usuarios.Find(id);

            _dataContext.Remove(usuarios);
            _dataContext.SaveChanges();
            return RedirectToAction("ListaPaciente");
        }


        public async Task<IActionResult> EditarPage(int id)
        {

            var User = await _dataContext.Usuarios.FindAsync(id);

            return View(User);
        }


        public IActionResult AlterarPaciente(int id, CadastroPacienteDTO request)
        {
            var user = _dataContext.Usuarios.Find(id);
            
            user.Nome = request.Nome;
            user.Cpf = request.Cpf;
            user.Email = request.Email;
            user.Senha = request.Senha;
            user.Rg = request.Rg;
            user.Orgao_emissor = request.Orgao_emissor;
            user.F_paterna = request.F_paterna;
            user.F_materna = request.F_materna;
            user.Nascimento = request.Nascimento;
            user.Sexo = request.Sexo;
            user.Cep = request.Cep;
            user.Rua = request.Rua;
            user.Cidade = request.Cidade;
            user.Complemento = request.Complemento;
            user.Estado = request.Estado;
            user.Numero = request.Numero;


            _dataContext.Update(user);
            _dataContext.SaveChanges();

            return RedirectToAction("ListaPaciente", "User");
        }
    }
}
