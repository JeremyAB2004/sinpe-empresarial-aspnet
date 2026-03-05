using Microsoft.AspNetCore.Mvc;
using sinpe_empresarial_aspnet.Business;
using sinpe_empresarial_aspnet.Data;
using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Controllers
{
    public class SinpeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SinpeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Sinpe model)
        {
            if (ModelState.IsValid)
            {
                var caja = _appDbContext.Cajas  
                    .FirstOrDefault(c => c.TelefonoSINPE == model.TelefonoDestinatario);
                if (caja == null)
                {
                    ModelState.AddModelError("", "No se encontró una caja con el teléfono destinatario.");
                    return View(model);
                }

                model.FechaDeRegistro = DateTime.Now;
                model.Estado = false;
                _appDbContext.Sinpe.Add(model);
                _appDbContext.SaveChanges();

                return RedirectToAction("Registrar");

            }

            return View(model);
        }

        
    }
}
