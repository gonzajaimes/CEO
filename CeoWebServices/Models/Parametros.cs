using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Parametros
    {
        public decimal PmtIdParametro { get; set; }
        public decimal? PmtValorNum { get; set; }
        public string PmtValorChar { get; set; }
        public string PmtDescripcion { get; set; }
    }
}
