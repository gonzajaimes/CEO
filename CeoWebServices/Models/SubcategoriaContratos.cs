using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class SubcategoriaContratos
    {
        public SubcategoriaContratos()
        {
            Proyectos = new HashSet<Proyectos>();
        }

        public decimal ScoIdSubcategoriaContrato { get; set; }
        public string ScoDescripcionSubcategoria { get; set; }

        public ICollection<Proyectos> Proyectos { get; set; }
    }
}
