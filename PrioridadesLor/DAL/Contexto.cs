﻿using Microsoft.EntityFrameworkCore;
using PrioridadesLor.Models;
using System.Collections.Generic;
namespace PrioridadesLor.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Prioridades> prioridades { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Sistema> sistema { get; set; }
        public DbSet<Tickets> tickets { get; set; }
    }
}