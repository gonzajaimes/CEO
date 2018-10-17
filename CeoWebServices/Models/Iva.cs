using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Iva
    {
        public int IvaIdIva { get; set; }
        public DateTime IvaFechaDesde { get; set; }
        public decimal? IvaPorcentaje { get; set; }
    }
}
