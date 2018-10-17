using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Abonos
    {
        public decimal AboIdAbono { get; set; }
        public decimal AboIdFact { get; set; }
        public DateTime AboFecha { get; set; }
        public decimal AboValor { get; set; }
        public string AboObs { get; set; }

        public Facturas AboIdFactNavigation { get; set; }
    }
}
