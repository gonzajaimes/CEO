using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class CategoriaContratistas
    {
        public CategoriaContratistas()
        {
            SubcategoriaContratistas = new HashSet<SubcategoriaContratistas>();
        }

        public decimal CacId { get; set; }
        public string CacCategoria { get; set; }

        public ICollection<SubcategoriaContratistas> SubcategoriaContratistas { get; set; }
    }
}
