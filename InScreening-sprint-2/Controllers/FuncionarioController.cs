using InScreening_sprint_2.Data;
using InScreening_sprint_2.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
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

        public IActionResult CadastroPage()
        {
            return View();
        }


        public IActionResult DadosFuncionario()
        {
            // Busca o funcionário pelo ID
            var id = HttpContext.Session.GetInt32("_Id");
            var funcionario = _dataContext.Funcionario.Find(id);

            if (funcionario == null)
            {
                return BadRequest("Id do Funcionario para puxar os dados foram perdidos, no momentos ainda a session nao foi implementada");
            }

            ViewBag.funcionario = funcionario;
            // Passa o funcionário encontrado para a view
            return View(funcionario);
        }

        public IActionResult CadastrarFuncionario(CadastroFuncionarioDTO request)
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
            return View("~/Views/Hospital/Index.cshtml");
        }



        public IActionResult LoginPage()
        {
            return View();
        }


        public IActionResult LogarFuncionario(LoginFuncionarioDTO request)
        {
            var funcionario = _dataContext.Funcionario.FirstOrDefault(x => x.Email == request.Email);

            if (funcionario == null)
            {
                return BadRequest("Email inválido");
            }

            if (funcionario.Cpf != request.Cpf)
            {
                return BadRequest("CPF inválido");
            }

            HttpContext.Session.SetInt32("_Id", funcionario.Id);

            return View("Index");
        }
        public async Task<IActionResult> ListaFuncionario()
        {
            var funcionario = await _dataContext.Funcionario.ToListAsync();

            return View(funcionario);
        }


        public IActionResult DeletarFuncionario(int id)
        {
            var funcionario = _dataContext.Funcionario.Find(id);

            _dataContext.Remove(funcionario);
            _dataContext.SaveChanges();
            return RedirectToAction("ListaFuncionario");
        }


        public async Task<IActionResult> EditarPage(int id)
        {

            var funcionario = await _dataContext.Funcionario.FindAsync(id);

            return View(funcionario);
        }


        public IActionResult AlterarFuncionario(int id,  CadastroFuncionarioDTO request)
        {
            var funcionario= _dataContext.Funcionario.Find(id);


            funcionario.Nome = request.Nome;
            funcionario.Cpf = request.Cpf;
            funcionario.Email = request.Email;
           

            _dataContext.Update(funcionario);
            _dataContext.SaveChanges();

            return RedirectToAction("ListaFuncionario", "Funcionario");
        }


            
        }
    }
