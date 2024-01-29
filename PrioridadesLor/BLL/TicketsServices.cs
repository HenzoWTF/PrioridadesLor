using PrioridadesLor.DAL;
using Microsoft.EntityFrameworkCore;
using PrioridadesLor.Models;
using System.Linq.Expressions;
using System;

namespace PrioridadesLor.BLL
{
    public class TicketsServices
    {
        private readonly Contexto _context;

        public TicketsServices(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Guardar(Tickets tickets)
        {
            if (!await Existe(tickets.TicketdId))
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
            return await _context.tickets.AnyAsync(t => t.TicketdId == id);
        }

        public async Task<bool> Eliminar(Tickets tickets)
        {
            var cantidad = await _context.tickets
                .Where(t => t.TicketdId == tickets.TicketdId)
                .ExecuteDeleteAsync();
            return cantidad > 0;
        }

        public async Task<Tickets?> Buscar(int Id)
        {
            return await _context.tickets
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TicketdId == Id);
        }

        public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
        {
            return await _context.tickets.AsNoTracking().Where(criterio).ToListAsync();
        }
    }
}
