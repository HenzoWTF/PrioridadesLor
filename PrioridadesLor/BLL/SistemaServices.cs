using PrioridadesLor.DAL;
using Microsoft.EntityFrameworkCore;
using PrioridadesLor.Models;
using System.Linq.Expressions;
using System;

namespace PrioridadesLor.BLL
{
    public class SistemaServices
    {
        private readonly Contexto _contexto;

        public SistemaServices(Contexto contexto)
        {
            _contexto = contexto;
        }
        
        public async Task<bool> Existe(int IdSistema)
        {
            return await _contexto.sistema.AnyAsync(p => p.SistemaId == IdSistema);
            
        }

        public async Task<bool> NombreRepetido(string Nombre)
        {
            return await _contexto.sistema.AnyAsync(p => p.SistemaNombre == Nombre);
        }

        private async Task<bool> Insertar(Sistema sistema)
        {
            _contexto.sistema.Add(sistema);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Sistema sistema)
        {
            _contexto.Update(sistema);
            return await _contexto.SaveChangesAsync() > 0;

        }

        public async Task<bool> Guardar(Sistema sistema)
        {
            if (!await Existe(sistema.SistemaId) && !await NombreRepetido(sistema.SistemaNombre))
            {
                return await Insertar(sistema);
            }
            else
            {
                return await Modificar(sistema);
            }
        }

        public async Task<bool> Eliminar(Sistema sistema)
        {
            var entidad = await _contexto.sistema
                .Where(s => s.SistemaId == sistema.SistemaId)
                .ExecuteDeleteAsync();

            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Sistema?> Buscar(int sistemaID)
        {
            return await _contexto.sistema
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.SistemaId == sistemaID);
        }

        public async Task<List<Sistema>> Listar(Expression<Func<Sistema, bool>> criterio)
        {
            return await _contexto.sistema
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
        public bool Validar()
        {
            return _contexto.sistema != null;
        }

    }
}
