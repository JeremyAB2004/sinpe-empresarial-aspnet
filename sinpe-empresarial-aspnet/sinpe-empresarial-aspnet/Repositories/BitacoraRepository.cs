using sinpe_empresarial_aspnet.Data;
using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Repositories
{
    public class BitacoraRepository : IBitacoraRepository
    {
        private readonly AppDbContext _context;

        public BitacoraRepository(AppDbContext context)
        {
            _context = context;
        }

        public void RegistrarEvento(BitacoraEventos evento)
        {
            _context.BitacoraEventos.Add(evento);
            _context.SaveChanges();
        }

        public List<BitacoraEventos> GetAllEventos()
        {
            return _context.BitacoraEventos
                .OrderByDescending(e => e.FechaDeEvento)
                .ToList();
        }
    }
}