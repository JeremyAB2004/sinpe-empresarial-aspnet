using sinpe_empresarial_aspnet.Data;
using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Repositories
{
    public class SinpeRepository : ISinpeRepository
    {
        private readonly AppDbContext _context;

        public SinpeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Sinpe> GetSinpeByTelefonoDestinatario(string telefonoDestinatario)
        {
            return _context.Sinpe
                .Where(s => s.TelefonoDestinatario == telefonoDestinatario)
                .OrderByDescending(s => s.FechaDeRegistro)
                .ToList();
        }

        public void AddSinpe(Sinpe sinpe)
        {
            _context.Sinpe.Add(sinpe);
            _context.SaveChanges();
        }
    }
}