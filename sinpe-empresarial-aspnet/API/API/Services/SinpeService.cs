using API.Data;
using API.Model;

namespace API.Services
{
    public class SinpeService
    {
        private readonly AppDbContext _context;

        public SinpeService(AppDbContext context)
        {
            _context = context;
        }

        public List<SinpeModel> GetSinpeByTelefonoDestinatario(string telefonoDestinatario)
        {
            return _context.Sinpe
                .Where(s => s.TelefonoDestinatario == telefonoDestinatario)
                .OrderByDescending(s => s.FechaDeRegistro)
                .ToList();
        }

        public SinpeModel PostSinpe(SinpeModel sinpe)
        {
            sinpe.FechaDeRegistro = DateTime.Now;
            sinpe.Estado = false;
            _context.Sinpe.Add(sinpe);
            _context.SaveChanges();
            return sinpe;
        }
    }
}