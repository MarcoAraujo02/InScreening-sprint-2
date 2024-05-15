using InScreening_sprint_2.Data;
using InScreening_sprint_2.DTOs;
using Microsoft.AspNetCore.Mvc;
using InScreening_sprint_2.Models;

namespace InScreening_sprint_2.Controllers
{
    public class TriagemController : Controller
    {


        private readonly ILogger<TriagemController> _logger;



        private readonly DataContext _dataContext;


        public TriagemController(ILogger<TriagemController> logger, DataContext dataContext)


        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Cadastrar(CadastroTriagemDTO request)
        {

            Triagem novaTriagem = new Triagem
            {
                DataInicio = request.Datainicio,
                DataFim = request.Datafim,
                Sintomas = request.Sintomas,
                Prioridade = request.Prioridade,

            };

            _dataContext.Add(novaTriagem);
            _dataContext.SaveChanges();
            return View("~/Views/Triagem/index.cshtml");

        }


        public IActionResult Triagem()
        {
            return View();
        }

        public IActionResult ListaTr()
        {
            return View();
        }
    }
}
