using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class SubcategoriaContratistas
    {
        public decimal SucId { get; set; }
        public decimal SucIdCategoria { get; set; }
        public string SucSubcategoria { get; set; }

        public CategoriaContratistas SucIdCategoriaNavigation { get; set; }
    }
}
