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
            #region retirando pluralizing table name
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Contato>().ToTable("Contato");
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Profissao>().ToTable("Profissao");
            modelBuilder.Entity<ProfissaoCliente>().ToTable("ProfissaoCliente");
            #endregion

            #region #region configuracao de cliente
            modelBuilder.Entity<Cliente>().HasKey(c => c.ClienteId);
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Contatos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(c => c.ClienteId)
                .HasPrincipalKey(c => c.ClienteId);
            #endregion

            #region configuracao contato
            modelBuilder.Entity<Contato>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Contatos)
                .HasForeignKey(c => c.ClienteId)
                .HasPrincipalKey(c => c.ClienteId);
            #endregion

            #region configuracao menu
            modelBuilder.Entity<Menu>()
                .HasMany(c => c.SubMenu)
                .WithOne()
                .HasForeignKey(c => c.MenuId);
            #endregion

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
