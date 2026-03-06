using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Repositories
{
    public interface IBitacoraRepository
    {
        void RegistrarEvento(BitacoraEventos evento);
        List<BitacoraEventos> GetAllEventos();
    }
}