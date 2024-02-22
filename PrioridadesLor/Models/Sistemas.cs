using System.ComponentModel.DataAnnotations;

namespace PrioridadesLor.Models
{
    public class Sistemas
    {
        [Key]
        public int SistemasId { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$",
        ErrorMessage = "Debe de insertar un nombre valido")]
        public string? SistemasNombres { get; set;}

    }
}
