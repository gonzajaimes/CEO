using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Rup
    {
        public decimal RupIdRup { get; set; }
        public decimal RupIdEmpresa { get; set; }
        public decimal RupIdProyecto { get; set; }
        public string RupSegmento { get; set; }
        public string RupFamilia { get; set; }
        public string RupClase { get; set; }

        public Empresas RupIdEmpresaNavigation { get; set; }
        public Proyectos RupIdProyectoNavigation { get; set; }
    }
}
