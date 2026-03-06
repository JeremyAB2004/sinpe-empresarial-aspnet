using System.Text.Json;
using sinpe_empresarial_aspnet.Models;
using sinpe_empresarial_aspnet.Repositories;

namespace sinpe_empresarial_aspnet.Business
{
    public class SinpeBusiness
    {
        private readonly ISinpeRepository _sinpeRepository;
        private readonly BitacoraBusiness _bitacora;

        private const string TABLA = "SINPE";

        public SinpeBusiness(ISinpeRepository sinpeRepository, BitacoraBusiness bitacora)
        {
            _sinpeRepository = sinpeRepository;
            _bitacora = bitacora;
        }

        public List<Sinpe> GetSinpeByTelefonoDestinatario(string telefonoDestinatario)
        {
            return _sinpeRepository.GetSinpeByTelefonoDestinatario(telefonoDestinatario);
        }

        public void AddSinpe(Sinpe sinpe)
        {
            try
            {
                sinpe.FechaDeRegistro = DateTime.Now;
                sinpe.Estado = false;
                _sinpeRepository.AddSinpe(sinpe);

                _bitacora.RegistrarEvento(
                    tablaDeEvento: TABLA,
                    tipoDeEvento: "Registrar",
                    descripcion: $"SINPE registrado de {sinpe.NombreOrigen} a {sinpe.NombreDestinatario} por ₡{sinpe.Monto}",
                    datosAnteriores: JsonSerializer.Serialize(sinpe)
                );
            }
            catch (Exception ex)
            {
                _bitacora.RegistrarError(TABLA, ex.Message, ex.StackTrace ?? string.Empty);
                throw;
            }
        }
    }
}