using PrioridadesLor.DAL;
using Microsoft.EntityFrameworkCore;
using PrioridadesLor.Models;
using System.Linq.Expressions;
using System;

namespace PrioridadesLor.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexto _contexto;

        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int IdPrioridad)
        {
            return await _contexto.prioridades.AnyAsync(p => p.IdPrioridad == IdPrioridad);
            
        }

        public async Task<bool>DescripcionRepetida(string descripcion)
        {
            return await _contexto.prioridades.AnyAsync(p => p.Descripcion == descripcion);
        }

        private async Task<bool> Insertar(Prioridades prioridad)
        {
            _contexto.prioridades.Add(prioridad);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Prioridades prioridad)
        {
           _contexto.Update(prioridad);
            return await _contexto.SaveChangesAsync() > 0;

        }

        public async Task<bool> Guardar(Prioridades prioridad)
        {
            if (! await Existe(prioridad.IdPrioridad) && ! await DescripcionRepetida(prioridad.Descripcion))
            {
                return await Insertar(prioridad);
            }
            else
            {
                return await Modificar(prioridad);
            }
        }

        public async Task<bool> Eliminar(Prioridades prioridad)
        {
            var entidad = await _contexto.prioridades
                .Where(p => p.IdPrioridad == prioridad.IdPrioridad)
                .ExecuteDeleteAsync();
            
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Prioridades?> Buscar(int IdPrioridad)
        {
            return await _contexto.prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.IdPrioridad ==IdPrioridad);
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
