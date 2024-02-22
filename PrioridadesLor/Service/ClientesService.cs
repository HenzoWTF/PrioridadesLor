using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PrioridadesLor.DAL;
using PrioridadesLor.Models;

namespace PrioridadesLor.BLL
{
    public class ClientesService
    {
        private readonly Contexto _contexto;

        public ClientesService(Contexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<bool> Existe(int ClientesID)
        {
            return await _contexto.clientes
                .AnyAsync(c => c.ClientesID == ClientesID);
        }

        public async Task<bool> Modificar(Clientes cliente)
        {
            _contexto.Update(cliente);
            var modificar = await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(cliente).State = EntityState.Detached;
            return modificar;
        }
        private async Task<bool> Insertar(Clientes clientes)
        {
            _contexto.clientes.Add(clientes);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Clientes clientes)
        {
            if (!await Existe(clientes.ClientesID))
                return await Insertar(clientes);
            else
                return await Modificar(clientes);
        }

        public async Task<bool> Eliminar(Clientes clientes)
        {
            var cantidad = await _contexto.clientes
                .Where(c => c.ClientesID == clientes.ClientesID)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }


        public async Task<Clientes?> BuscarClientes(string nombres)
        {
            return await _contexto.clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.NombresClientes.ToLower() == nombres.ToLower());
        }

        public async Task<Clientes?> Buscar(int ClientesID)
        {
            return await _contexto.clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClientesID == ClientesID);
        }

        public async Task <List<Clientes>> Listar (Expression<Func<Clientes, bool>> criterio)
        {
            return await _contexto.clientes.AsNoTracking().Where(criterio).ToListAsync();
        }


        public bool ExisteD(Clientes clientes)
        {
            var mismosDatos = _contexto.clientes.Any(c => c.NombresClientes == clientes.NombresClientes || c.RNC == clientes.RNC);
            if (mismosDatos)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}

