using System;
using System.Collections.Generic;

#nullable disable

namespace HouseOfShows.WebMVC.Models
{
    public partial class TipoIngresso
    {
        public TipoIngresso()
        {
            Venda = new HashSet<Venda>();
        }

        public string TipoIngresso1 { get; set; }

        public virtual ICollection<Venda> Venda { get; set; }
    }
}
