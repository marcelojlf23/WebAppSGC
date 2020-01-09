using SGC.AplicatinoCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGC.Infra2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ClienteContexto context)
        {
            if (context.Clientes.Any())
            {
                return;
            }

            var clientes = new Cliente[]
            {
                new Cliente
                {
                    Nome = "Marcelo",
                    CPF = "1111111111"
                },
                new Cliente
                {
                    Nome="Vanessa",
                    CPF="222222"
                }
            };

            context.AddRange(clientes);

            var contatos = new Contato[]
            {
                new Contato
                {
                    Nome = "Albert",
                    Email = "alb@gmail.com",
                    Telefone="3333444",
                    Cliente = clientes[0]
                },
                new Contato
                {
                    Nome="Marcio",
                    Email="marcio@gmail.com",
                    Telefone="44445555",
                    Cliente = clientes[1]
                }
            };

            context.AddRange(contatos);

            context.SaveChanges();
        }
    }
}
