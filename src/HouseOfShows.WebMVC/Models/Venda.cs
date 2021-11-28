using System;
using System.Collections.Generic;

#nullable disable

namespace HouseOfShows.WebMVC.Models
{
    public partial class Venda
    {
        public int IdVenda { get; set; }
        public int IdEvento { get; set; }
        public string CpfCliente { get; set; }
        public string TipoIngresso { get; set; }
        public int QtdIngresso { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual Cliente CpfClienteNavigation { get; set; }
        public virtual Evento IdEventoNavigation { get; set; }
        public virtual TipoIngresso TipoIngressoNavigation { get; set; }
    }
}
