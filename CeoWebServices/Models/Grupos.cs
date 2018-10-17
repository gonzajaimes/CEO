using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Grupos
    {
        public Grupos()
        {
            ContactosEme = new HashSet<ContactosEme>();
        }

        public decimal GruIdGrupo { get; set; }
        public string GruDescripcion { get; set; }

        public ICollection<ContactosEme> ContactosEme { get; set; }
    }
}
