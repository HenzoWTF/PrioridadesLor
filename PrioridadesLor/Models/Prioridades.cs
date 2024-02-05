
using System.ComponentModel.DataAnnotations;

namespace PrioridadesLor.Models
{
    public class Prioridades
    {

        [Range(1, int.MaxValue, ErrorMessage = "Debe ser mayor que 0")]
        [Key]
        public int IdPrioridades { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        public string? Descripcion { get; set; }

        [Range(1, 31, ErrorMessage = "Debe de insertar un dia de compromiso dentro del rango [1-31]")]
        [Required(ErrorMessage = "El campo Dias Compromiso es obligatorio")]
        public int DiasCompromiso { get; set; }
    }
}
