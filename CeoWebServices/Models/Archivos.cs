using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Archivos
    {
        public decimal AcvIdArchivo { get; set; }
        public decimal AcvIdCategoria { get; set; }
        public decimal AcvNroPaginas { get; set; }
        public decimal AcvIdDocumento { get; set; }

        public CategoriaDocumento AcvIdCategoriaNavigation { get; set; }
    }
}
