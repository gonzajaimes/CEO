using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class CategoriaEmpresas
    {
        public CategoriaEmpresas()
        {
            Empresas = new HashSet<Empresas>();
        }

        public decimal CaeIdCategoria { get; set; }
        public string CaeDescripcion { get; set; }

        public ICollection<Empresas> Empresas { get; set; }
    }
}
