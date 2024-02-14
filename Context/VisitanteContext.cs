using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Santi.Models;

namespace Santi.Context
{
    public class VisitanteContext : DbContext
    {

        public VisitanteContext(DbContextOptions<VisitanteContext> options) : base(options)
        {

        }

        public DbSet<Visitante> VisitanteDb { get; set; }

    }
}