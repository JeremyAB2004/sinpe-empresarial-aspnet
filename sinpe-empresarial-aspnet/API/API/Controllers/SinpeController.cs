using API.Model;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinpeController : ControllerBase
    {
        private readonly SinpeService _sinpeService;

        public SinpeController(SinpeService sinpeService)
        {
            _sinpeService = sinpeService;
        }

        [HttpGet("{telefonoDestinatario}")]
        public ActionResult<IEnumerable<SinpeModel>> GetByTelefono(string telefonoDestinatario)
        {
            return _sinpeService.GetSinpeByTelefonoDestinatario(telefonoDestinatario);
        }

        [HttpPost]
        public ActionResult PostSinpe(SinpeModel sinpe)
        {
            var nuevo = _sinpeService.PostSinpe(sinpe);
            return CreatedAtAction(nameof(GetByTelefono),
                new { telefonoDestinatario = nuevo.TelefonoDestinatario }, nuevo);
        }
    }
}