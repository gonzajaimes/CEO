using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class EmpProductoServicio
    {
        public decimal EpsIdProductoServicio { get; set; }
        public decimal EpsIdEmpresa { get; set; }

        public Empresas EpsIdEmpresaNavigation { get; set; }
        public ProductoServicio EpsIdProductoServicioNavigation { get; set; }
    }
}
