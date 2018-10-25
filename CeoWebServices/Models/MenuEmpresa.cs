using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CeoWebServices.Models
{
    public class MenuEmpresa
    {
        public decimal IdEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public DateTime? FechaUltimoContrato { get; set; }
        public int NumeroContratos { get; set; }

    }
}
