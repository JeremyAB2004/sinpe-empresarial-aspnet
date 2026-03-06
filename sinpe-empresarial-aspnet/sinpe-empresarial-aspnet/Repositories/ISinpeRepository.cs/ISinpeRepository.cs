using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Repositories
{
    public interface ISinpeRepository
    {
        List<Sinpe> GetSinpeByTelefonoDestinatario(string telefonoDestinatario);
        void AddSinpe(Sinpe sinpe);
    }
}