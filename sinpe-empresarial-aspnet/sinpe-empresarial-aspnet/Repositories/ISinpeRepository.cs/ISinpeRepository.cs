using sinpe_empresarial_aspnet.Models;
using sinpe_empresarial_aspnet.Repositories;

namespace sinpe_empresarial_aspnet.Repositories
{
    public interface ISinpeRepository
    {
        List<Sinpe> GetSinpeByTelefonoDestinatario(string telefonoDestinatario);
    }
}
