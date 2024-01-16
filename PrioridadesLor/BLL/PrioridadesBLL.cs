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

        public bool Existe(int IdPrioridad)
        {
            return _contexto.Prioridades.Any(p => p.IdPrioridad == IdPrioridad);
        }

        public bool DescripcionRepetida(string descripcion)
        {
            return _contexto.Prioridades.Any(p => p.Descripcion == descripcion);
        }

        private bool Insertar(Prioridades prioridad)
        {
            _contexto.Prioridades.Add(prioridad);
            return _contexto.SaveChanges() > 0;
        }

        public bool Modificar(Prioridades prioridad)
        {
            var Existe = _contexto.Prioridades.Find(prioridad.IdPrioridad);

            if (Existe != null)
            {
                _contexto.Entry(Existe).CurrentValues.SetValues(prioridad);

                return _contexto.SaveChanges() > 0;
            }

            return false; 

        }

        public bool Guardar(Prioridades prioridad)
        {
            if (!Existe(prioridad.IdPrioridad) && !DescripcionRepetida(prioridad.Descripcion))
            {
                return this.Insertar(prioridad);
            }
            else
            {
                return this.Modificar(prioridad);
            }
        }

        public bool Eliminar(Prioridades prioridad)
        {
            var entidad = _contexto.Prioridades.Find(prioridad.IdPrioridad);
            if (entidad == null)
            {
                return false;
            }
            _contexto.Entry(entidad).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        public Prioridades? Buscar(int IdPrioridad)
        {
            return _contexto.Prioridades
                .Where(p => p.IdPrioridad == IdPrioridad)
                .AsNoTracking()
                .SingleOrDefault();
        }

        
        public async Task<List<Prioridades>> GetList(Expression<Func<Prioridades, bool>> Criterio)
        {
            return _contexto.Prioridades
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

        public bool Validar()
        {
            return _contexto.Prioridades != null;
        }
    }
}
