using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Repositories
{
    public interface ICajasRepository
    {
        List<Cajas> GetCajasByComercio(int idComercio);
        Cajas GetCajaById(int idCaja);

        bool ExisteNombrePorComercio(int idComercio, string nombre, int idCaja);
        bool ExisteTelefonoActivo(string telefonoSINPE, int idCaja);

        void AddCaja(Cajas caja);
        void UpdateCaja(Cajas caja);
    }
}