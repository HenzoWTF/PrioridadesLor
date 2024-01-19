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


        public async Task<bool> Existe(int ClienteID)
        {
            return await _contexto.clientes
                .AnyAsync(c => c.ClientesID == ClienteID);
        }

        public async Task<bool> Modificar(Cliente cliente)
        {
            _contexto.Update(cliente);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Insertar(Cliente cliente)
        {
            _contexto.clientes.Add(cliente);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Cliente cliente)
        {
            if (!await Existe(cliente.ClientesID))
                return await Insertar(cliente);
            else
                return await Modificar(cliente);
        }

        public async Task<bool> Eliminar(Cliente cliente)
        {
            var cantidad = await _contexto.clientes
                .Where(c => c.ClientesID == cliente.ClientesID)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Cliente> Buscar(int ClienteID)
        {
            return await _contexto.clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClientesID == ClienteID);
        }

        public async Task <List<Cliente>> Listar (Expression<Func<Cliente, bool>> criterio)
        {
            return await _contexto.clientes.AsNoTracking().Where(criterio).ToListAsync();
        }


    }
}

