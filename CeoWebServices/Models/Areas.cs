using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Areas
    {
        public Areas()
        {
            AreaProyecto = new HashSet<AreaProyecto>();
        }

        public decimal AreIdArea { get; set; }
        public string AreDescripcionArea { get; set; }
        public decimal AreIdCategoriaContrato { get; set; }

        public CategoriaContratos AreIdCategoriaContratoNavigation { get; set; }
        public ICollection<AreaProyecto> AreaProyecto { get; set; }
    }
}
