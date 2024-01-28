using PrioridadesLor.DAL;

namespace PrioridadesLor.BLL
{
    public class TicketsServices
    {
        private readonly Contexto _contexto;
        public TicketsServices(Contexto contexto)
        {
            _contexto = contexto;
        }
    }
}
