using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Consorcio
    {
        public decimal ConIdConsorcio { get; set; }
        public decimal ConIdEmpresa { get; set; }
        public decimal ConIdProyecto { get; set; }
        public decimal ConPorcentaje { get; set; }
        public string ConTipcon { get; set; }
        public string ConNomcon { get; set; }

        public Empresas ConIdEmpresaNavigation { get; set; }
        public Proyectos ConIdProyectoNavigation { get; set; }
    }
}
