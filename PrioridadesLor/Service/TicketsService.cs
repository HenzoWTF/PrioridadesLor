using PrioridadesLor.DAL;
using Microsoft.EntityFrameworkCore;
using PrioridadesLor.Models;
using System.Linq.Expressions;
using System;

namespace PrioridadesLor.BLL
{
    public class TicketsService
    {
        private readonly Contexto _contexto;

        public TicketsService(Contexto context)
        {
            _contexto = context;
        }

        public async Task<bool> Guardar(Tickets tickets)
        {
            if (!await Existe(tickets.TicketsId))
                return await Insertar(tickets);
            else
                return await Modificar(tickets);
        }

        public async Task<bool> Insertar(Tickets tickets)
        {
            _contexto.tickets.Add(tickets);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Tickets tickets)
        {
            _contexto.Update(tickets);
            var modificar = await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(tickets).State = EntityState.Detached;
            return modificar;
        }

        public async Task<bool> Existe(int id)
        {
            return await _contexto.tickets.AnyAsync(t => t.TicketsId == id);
        }

        public async Task<bool> Eliminar(Tickets tickets)
        {
            var cantidad = await _contexto.tickets
                .Where(t => t.TicketsId == tickets.TicketsId)
                .ExecuteDeleteAsync();
            return cantidad > 0;
        }

        public async Task<Tickets?> Buscar(int Id)
        {
            return await _contexto.tickets
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TicketsId == Id);
        }

        public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
        {
            return await _contexto.tickets.AsNoTracking().Where(criterio).ToListAsync();
        }
    }
}
