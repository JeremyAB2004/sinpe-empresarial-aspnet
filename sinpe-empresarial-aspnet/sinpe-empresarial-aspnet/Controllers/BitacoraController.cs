using Microsoft.AspNetCore.Mvc;

namespace sinpe_empresarial_aspnet.Controllers
{
    public class BitacoraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}