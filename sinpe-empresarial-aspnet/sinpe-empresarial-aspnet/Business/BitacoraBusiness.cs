using System.Text.Json;
using sinpe_empresarial_aspnet.Models;
using sinpe_empresarial_aspnet.Repositories;

namespace sinpe_empresarial_aspnet.Business
{
    public class BitacoraBusiness 
    {
        private readonly IBitacoraRepository _bitacoraRepository;

        public BitacoraBusiness(IBitacoraRepository bitacoraRepository)
        {
            _bitacoraRepository = bitacoraRepository;
        }

        public void RegistrarEvento(
            string tablaDeEvento,
            string tipoDeEvento,
            string descripcion,
            string? datosAnteriores = null,
            string? datosPosteriores = null)
        {
            var evento = new BitacoraEventos
            {
                TablaDeEvento = tablaDeEvento,
                TipoDeEvento = tipoDeEvento,
                FechaDeEvento = DateTime.Now,
                DescripcionDeEvento = descripcion,
                StackTrace = string.Empty,
                DatosAnteriores = datosAnteriores,
                DatosPosteriores = datosPosteriores
            };

            _bitacoraRepository.RegistrarEvento(evento);
        }

        public void RegistrarError(
            string tablaDeEvento,
            string descripcion,
            string stackTrace)
        {
            var evento = new BitacoraEventos
            {
                TablaDeEvento = tablaDeEvento,
                TipoDeEvento = "Error",
                FechaDeEvento = DateTime.Now,
                DescripcionDeEvento = descripcion,
                StackTrace = stackTrace ?? string.Empty,
                DatosAnteriores = null,
                DatosPosteriores = null
            };

            _bitacoraRepository.RegistrarEvento(evento);
        }

        public List<Models.BitacoraEventos> GetAllEventos()
        {
            return _bitacoraRepository.GetAllEventos();
        }
    }
}