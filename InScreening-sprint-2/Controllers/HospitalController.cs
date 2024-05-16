using Microsoft.AspNetCore.Mvc;

namespace InScreening_sprint_2.Controllers
{
    public class HospitalController : Controller
    {

        private readonly ILogger<HospitalController> _logger;

        public HospitalController(ILogger<HospitalController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
