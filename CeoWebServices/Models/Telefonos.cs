using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Telefonos
    {
        public decimal TeoIdTelefono { get; set; }
        public string TeoTelefono { get; set; }
        public decimal TeoIdDireccion { get; set; }
        public string TeoFax { get; set; }

        public Direcciones TeoIdDireccionNavigation { get; set; }
    }
}
