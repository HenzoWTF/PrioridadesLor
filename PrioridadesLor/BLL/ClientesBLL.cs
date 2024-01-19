using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PrioridadesLor.DAL;
using PrioridadesLor.Models;

namespace PrioridadesLor.BLL
{
    public class ClientesBLL
    {
        private readonly Contexto _contexto;

        public ClientesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int ClienteID)
        {
            return _contexto.cliente.Any( c => c.ClienteID == ClienteID );
        }

        public bool Insertar(Clientes clientes)





    }
}