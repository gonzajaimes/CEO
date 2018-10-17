using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class CategoriaContratos
    {
        public CategoriaContratos()
        {
            Areas = new HashSet<Areas>();
            Proyectos = new HashSet<Proyectos>();
        }

        public decimal CcoIdCategoriaContrato { get; set; }
        public string CcoDescripcion { get; set; }

        public ICollection<Areas> Areas { get; set; }
        public ICollection<Proyectos> Proyectos { get; set; }
    }
}
