using Microsoft.AspNetCore.Mvc;

namespace sinpe_empresarial_aspnet.Controllers
{
    public class CajasController : Controller
    {
        public IActionResult Index(int id) => View();
        public IActionResult Create(int id) => View();
        public IActionResult Edit(int id) => View();
        public IActionResult VerSinpe(int id) => View();
    }
}