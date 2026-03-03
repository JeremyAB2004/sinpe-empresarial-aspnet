using sinpe_empresarial_aspnet.Models;
using sinpe_empresarial_aspnet.Repositories;

namespace sinpe_empresarial_aspnet.Business
{
    public class SinpeBusiness
    {
        private readonly ISinpeRepository _sinpeRepository;

        public SinpeBusiness(ISinpeRepository sinpeRepository)
        {
            _sinpeRepository = sinpeRepository;
        }

        public List<Sinpe> GetSinpeByTelefonoDestinatario(string telefonoDestinatario)
        {
            return _sinpeRepository.GetSinpeByTelefonoDestinatario(telefonoDestinatario);
        }
    }
}
