using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sinpe_empresarial_aspnet.Models
{
    [Table("BITACORA_EVENTOS")]
    public class BitacoraEventos
    {
        [Key]
        public int IdEvento { get; set; }

        [Required]
        [StringLength(20)]
        public string TablaDeEvento { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoDeEvento { get; set; }

        public DateTime FechaDeEvento { get; set; }

        [Required]
        public string DescripcionDeEvento { get; set; }

        [Required]
        public string StackTrace { get; set; }

        public string? DatosAnteriores { get; set; }

        public string? DatosPosteriores { get; set; }
    }
}