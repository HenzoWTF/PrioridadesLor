using PrioridadesLor.DAL;
using Microsoft.EntityFrameworkCore;
using PrioridadesLor.Models;
using System.Linq.Expressions;
using System;

namespace PrioridadesLor.BLL
{
    public class SistemasService
    {
        private readonly Contexto _contexto;

        public SistemasService(Contexto contexto)
        {
            _contexto = contexto;
        }
        
        public async Task<bool> Existe(int IdSistemas)
        {
            return await _contexto.sistemas.AnyAsync(p => p.SistemasId == IdSistemas);
            
        }

        public async Task<bool> NombreRepetido(string Nombres)
        {
            return await _contexto.sistemas.AnyAsync(p => p.SistemasNombres == Nombres);
        }

        private async Task<bool> Insertar(Sistemas sistemas)
        {
            _contexto.sistemas.Add(sistemas);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Sistemas sistemas)
        {
            _contexto.Update(sistemas);
            var modificar = await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(sistemas).State = EntityState.Detached;
            return modificar;
        }

        public async Task<bool> Guardar(Sistemas sistemas)
        {
            if (!await Existe(sistemas.SistemasId) && !await NombreRepetido(sistemas.SistemasNombres))
            {
                return await Insertar(sistemas);
            }
            else
            {
                return await Modificar(sistemas);
            }
        }

        public async Task<bool> Eliminar(Sistemas sistemas)
        {
            var entidad = await _contexto.sistemas
                .Where(s => s.SistemasId == sistemas.SistemasId)
                .ExecuteDeleteAsync();

            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Sistemas?> Buscar(int sistemasID)
        {
            return await _contexto.sistemas
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.SistemasId == sistemasID);
        }

        public async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> criterio)
        {
            return await _contexto.sistemas
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
        public bool Validar()
        {
            return _contexto.sistemas != null;
        }

    }
}
