using System;
using System.Collections.Generic;

#nullable disable

namespace HouseOfShows.WebMVC.Models
{
    public partial class Status
    {
        public Status()
        {
            Eventos = new HashSet<Evento>();
        }

        public string NomeStatus { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
