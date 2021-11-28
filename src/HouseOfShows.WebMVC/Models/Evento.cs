using System;
using System.Collections.Generic;

#nullable disable

namespace HouseOfShows.WebMVC.Models
{
    public partial class Evento
    {
        public Evento()
        {
            Venda = new HashSet<Venda>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataEvento { get; set; }
        public string CpfResponsavel { get; set; }
        public decimal ValorInteira { get; set; }
        public decimal ValorMeia { get; set; }
        public string NomeStatus { get; set; }

        public virtual Responsavei CpfResponsavelNavigation { get; set; }
        public virtual Status NomeStatusNavigation { get; set; }
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
