using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Polizas
    {
        public decimal PolIdProyecto { get; set; }
        public string PolNroPoliza { get; set; }
        public DateTime PolFechaexp { get; set; }
        public DateTime PolVigenciaini { get; set; }
        public DateTime PolVigenciafin { get; set; }
        public string PolEsmodificacion { get; set; }
        public decimal PolRiesgoamp { get; set; }
        public decimal PolValorcob { get; set; }
        public decimal? PolIdAseguradora { get; set; }
        public string PolAlertaActiva { get; set; }
        public decimal PolIdPoliza { get; set; }
        public decimal PolId { get; set; }
        public string PolDigitalizado { get; set; }
        public decimal? PolAnexo { get; set; }

        public Proyectos PolIdProyectoNavigation { get; set; }
        public TipoPoliza PolRiesgoampNavigation { get; set; }
    }
}
