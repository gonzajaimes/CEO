using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class VehDesplazamiento
    {
        public decimal DesId { get; set; }
        public string DesPlaca { get; set; }
        public decimal DesResponsable { get; set; }
        public string DesDestino { get; set; }
        public DateTime DesSalida { get; set; }
        public DateTime? DesRegreso { get; set; }
        public decimal? DesProyecto { get; set; }
        public decimal? DesKmsalida { get; set; }
        public decimal? DesKmregreso { get; set; }
        public string DesObservacion { get; set; }

        public Vehiculos DesPlacaNavigation { get; set; }
        public Proyectos DesProyectoNavigation { get; set; }
        public ContactosEme DesResponsableNavigation { get; set; }
    }
}
