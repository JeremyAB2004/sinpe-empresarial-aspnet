using Microsoft.AspNetCore.Mvc;

namespace sinpe_empresarial_aspnet.Controllers
{
    public class ComerciosController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Create() => View();
        public IActionResult Edit(int id) => View();
        public IActionResult Details(int id) => View();
    }
}