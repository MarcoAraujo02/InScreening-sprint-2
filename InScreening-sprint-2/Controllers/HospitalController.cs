using Microsoft.AspNetCore.Mvc;

namespace InScreening_sprint_2.Controllers
{
    public class HospitalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
