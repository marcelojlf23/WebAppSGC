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
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Contato>().ToTable("Contato");

            #region Configurações de Cliente
            modelBuilder.Entity<Cliente>().Property(c => c.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            modelBuilder.Entity<Cliente>().Property(c => c.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            #endregion

            #region Configurações de Contato
            modelBuilder.Entity<Contato>().Property(c => c.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Contato>().Property(c => c.Telefone)
                .HasColumnType("varchar(15)");
            #endregion
        }
    }
}
