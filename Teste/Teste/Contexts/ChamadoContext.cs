using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Teste.Models;

namespace Teste.Contexts
{
    public class ChamadoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Chamado> Chamados { get; set; }

        public ChamadoContext()
            : base("Chamado")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}