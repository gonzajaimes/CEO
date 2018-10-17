using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class ContratosDetalle
    {
        public decimal CpdIdCpd { get; set; }
        public decimal CpdIdCpv { get; set; }
        public string CpdTipo { get; set; }
        public string CpdArchivo { get; set; }

        public ContratosProveedor CpdIdCpvNavigation { get; set; }
    }
}
