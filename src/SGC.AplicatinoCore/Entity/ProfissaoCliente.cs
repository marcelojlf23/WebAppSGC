using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.AplicatinoCore.Entity
{
    public class ProfissaoCliente
    {
        public ProfissaoCliente()
        {

        }

        public int ProfissaoClienteId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int ProfissaoId { get; set; }
        public Profissao Profissao { get; set; }
    }
}
