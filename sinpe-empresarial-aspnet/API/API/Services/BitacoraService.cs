using API.Data;
using API.Model;

namespace API.Services
{
    public class BitacoraService
    {
        private readonly AppDbContext _context;

        public BitacoraService(AppDbContext context)
        {
            _context = context;
        }

        public List<BitacoraEventosModel> GetAllEventos()
        {
            return _context.BitacoraEventos
                .OrderByDescending(e => e.FechaDeEvento)
                .ToList();
        }
    }
}