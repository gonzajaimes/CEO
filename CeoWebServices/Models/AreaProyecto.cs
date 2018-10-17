using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class AreaProyecto
    {
        public decimal ApyIdProyecto { get; set; }
        public decimal ApyIdArea { get; set; }
        public decimal ApyPorcentaje { get; set; }

        public Areas ApyIdAreaNavigation { get; set; }
        public Proyectos ApyIdProyectoNavigation { get; set; }
    }
}
