using Microsoft.EntityFrameworkCore;
using SGC.AplicatinoCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infra2.Data
{
    public class ClienteContexto : DbContext
    {
        public ClienteContexto(DbContextOptions<ClienteContexto> options)
            :base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
        }
    }
}
