using Microsoft.EntityFrameworkCore;
using PrioridadesLor.Models;
using System.Collections.Generic;
namespace PrioridadesLor.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Prioridades> Prioridades { get; set; }
    }
}