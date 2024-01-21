using System.ComponentModel.DataAnnotations;

namespace PrioridadesLor.Models
{
    public class Cliente
    {
        [Range(1, int.MaxValue, ErrorMessage = "Debe ser mayor que 0")]
        [Key]
        public int ClientesID { get; set; }

        [Required(ErrorMessage = "Debe de insertar un nombre")]
        [RegularExpression(@"^[a-zA-Z\s]+$",
        ErrorMessage = "Debe de insertar un nombre valido")]
        public string? NombreCliente { get; set; }


        [Required(ErrorMessage = "Debe de insertar un numero telefonico")]
        [RegularExpression(@"^[0-9- \s]{10,12}$",
        ErrorMessage = "Debe de insertar un numero telefonico con el formato correcto")]
        [Phone]
        public string? CelularCliente { get; set; }

        [Required(ErrorMessage = "Debe de insertar un numero de celular")]
        [RegularExpression(@"^[0-9- \s]{10,12}$",
        ErrorMessage = "Debe de insertar un numero celular con el formato correcto")]
        [Phone]
        public string? TelefonoCliente { get; set; }

        [Required(ErrorMessage = "Debe de insertar un RNC")]
        [StringLength(11, ErrorMessage = "El RNC debe de tener 11 caracteres")]
        public string? RNC {  get; set; }

        [Required(ErrorMessage = "El campo Correo Electronico es obligatorio")]
        [EmailAddress]
        public string? EmailCliente { get; set; }

        [Required(ErrorMessage = "Debe de insertar una direccion")]
        public string? DireccionCliente { get; set;}


    }
}
