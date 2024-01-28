using System.ComponentModel.DataAnnotations;

namespace PrioridadesLor.Models
{
    public class Sistema
    {
        [Key]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$",
        ErrorMessage = "Debe de insertar un nombre valido")]
        public string? SistemaNombre { get; set;}

    }
}
