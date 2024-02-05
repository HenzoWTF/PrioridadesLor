using PrioridadesLor.DAL;
using Microsoft.EntityFrameworkCore;
using PrioridadesLor.Models;
using System.Linq.Expressions;
using System;

namespace PrioridadesLor.BLL
{
    public class PrioridadesService
    {
        private readonly Contexto _contexto;

        public PrioridadesService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int IdPrioridades)
        {
            return await _contexto.prioridades.AnyAsync(p => p.IdPrioridades == IdPrioridades);
            
        }

        public async Task<bool>DescripcionRepetida(string descripcion)
        {
            return await _contexto.prioridades.AnyAsync(p => p.Descripcion == descripcion);
        }

        private async Task<bool> Insertar(Prioridades prioridades)
        {
            _contexto.prioridades.Add(prioridades);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Prioridades prioridades)
        {
           _contexto.Update(prioridades);
            return await _contexto.SaveChangesAsync() > 0;

        }

        public async Task<bool> Guardar(Prioridades prioridades)
        {
            if (! await Existe(prioridades.IdPrioridades) && ! await DescripcionRepetida(prioridades.Descripcion))
            {
                return await Insertar(prioridades);
            }
            else
            {
                return await Modificar(prioridades);
            }
        }

        public async Task<bool> Eliminar(Prioridades prioridades)
        {
            var entidad = await _contexto.prioridades
                .Where(p => p.IdPrioridades == prioridades.IdPrioridades)
                .ExecuteDeleteAsync();
            
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Prioridades?> BuscarDescripcion(string descripcion)
        {
            return await _contexto.prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Descripcion.ToLower() == descripcion.ToLower());
        }
        public async Task<Prioridades?> Buscar(int IdPrioridades)
        {
            return await _contexto.prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.IdPrioridades ==IdPrioridades);
        }

        
        public async Task<List<Prioridades>> GetList(Expression<Func<Prioridades, bool>> Criterio)
        {
            return await _contexto.prioridades
                .AsNoTracking()
                .Where(Criterio)
                .ToListAsync();
        }

        public bool Validar()
        {
            return _contexto.prioridades != null;
        }
    }
}
