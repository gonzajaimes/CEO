using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class TipoPoliza
    {
        public TipoPoliza()
        {
            Polizas = new HashSet<Polizas>();
        }

        public decimal TpaId { get; set; }
        public string TpaDescripcion { get; set; }

        public ICollection<Polizas> Polizas { get; set; }
    }
}
