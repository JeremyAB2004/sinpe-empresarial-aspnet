using API.Model;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : ControllerBase
    {
        private readonly BitacoraService _bitacoraService;

        public BitacoraController(BitacoraService bitacoraService)
        {
            _bitacoraService = bitacoraService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BitacoraEventosModel>> GetAllEventos()
        {
            return _bitacoraService.GetAllEventos();
        }
    }
}