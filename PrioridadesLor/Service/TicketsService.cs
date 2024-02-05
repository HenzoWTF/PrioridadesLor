using PrioridadesLor.DAL;
using Microsoft.EntityFrameworkCore;
using PrioridadesLor.Models;
using System.Linq.Expressions;
using System;

namespace PrioridadesLor.BLL
{
    public class TicketsService
    {
        private readonly Contexto _context;

        public TicketsService(Contexto context)
        {
            _context = context;
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
            _context.tickets.Add(tickets);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Tickets tickets)
        {
            _context.Update(tickets);
            var modifico = await _context.SaveChangesAsync() > 0;
            _context.Entry(tickets).State = EntityState.Detached;
            return modifico;
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.tickets.AnyAsync(t => t.TicketsId == id);
        }

        public async Task<bool> Eliminar(Tickets tickets)
        {
            var cantidad = await _context.tickets
                .Where(t => t.TicketsId == tickets.TicketsId)
                .ExecuteDeleteAsync();
            return cantidad > 0;
        }

        public async Task<Tickets?> Buscar(int Id)
        {
            return await _context.tickets
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TicketsId == Id);
        }

        public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
        {
            return await _context.tickets.AsNoTracking().Where(criterio).ToListAsync();
        }
    }
}
