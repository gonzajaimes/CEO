using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class VehDocumentos
    {
        public decimal VdtIddocumento { get; set; }
        public string VdtIddocExterno { get; set; }
        public string VdtPlaca { get; set; }
        public string VdtTipodoc { get; set; }
        public decimal? VdtResponsable { get; set; }
        public decimal? VdtValor { get; set; }
        public DateTime VdtFechaExpedicion { get; set; }
        public DateTime? VdtFechaVencimiento { get; set; }
        public decimal? VdtExpedidoPor { get; set; }
        public string VdtObservaciones { get; set; }

        public Empresas VdtExpedidoPorNavigation { get; set; }
        public Vehiculos VdtPlacaNavigation { get; set; }
        public ContactosEme VdtResponsableNavigation { get; set; }
    }
}
