using InScreening_sprint_2.Data;
using InScreening_sprint_2.DTOs;
using Microsoft.AspNetCore.Mvc;
using InScreening_sprint_2.Models;
using Microsoft.EntityFrameworkCore;

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


        public IActionResult CadastrarTriagem(CadastroTriagemDTO request)
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



        public async Task<IActionResult> ListaTriagem()
        {
            var triagem = await _dataContext.Triagem.ToListAsync();

            return View(triagem);
        }


        public IActionResult DeletarTriagem(int id)
        {
            var triagem = _dataContext.Triagem.Find(id);

             _dataContext.Remove(triagem);
            _dataContext.SaveChanges();
            return RedirectToAction("ListaTriagem");
        }

        public async Task<IActionResult> EditarPage(int id)
        {

            var triagem = await _dataContext.Triagem.FindAsync(id);

            return View(triagem);
        }


        public IActionResult AlterarTriagem(int id, CadastroTriagemDTO request)
        {
            var triagem = _dataContext.Triagem.Find(id);

            triagem.DataInicio = request.Datainicio;
            triagem.DataFim = request.Datafim;
            triagem.Sintomas = request.Sintomas;
            triagem.Prioridade = request.Prioridade;


            _dataContext.Update(triagem);
            _dataContext.SaveChanges();

            return RedirectToAction("ListaTriagem", "Triagem");
        }
    }
}
