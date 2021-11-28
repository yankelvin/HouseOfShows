using System;
using System.Collections.Generic;

#nullable disable

namespace HouseOfShows.WebMVC.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venda = new HashSet<Venda>();
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int? Idade { get; set; }

        public virtual ICollection<Venda> Venda { get; set; }
    }
}
