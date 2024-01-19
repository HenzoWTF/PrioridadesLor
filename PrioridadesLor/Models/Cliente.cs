using System.ComponentModel.DataAnnotations;

namespace PrioridadesLor.Models
{
    public class Cliente
    {
        [Key]
        public int ClientesID { get; set; }
        public string? NombreCliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string? CelularCliente { get; set; }
        public string? RNC {  get; set; }
        public string? EmailCliente { get; set; }
        public string? DireccionCliente { get; set;}


    }
}
