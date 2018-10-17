using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class TelfCont
    {
        public decimal TctIdCoo { get; set; }
        public decimal TctTelefono { get; set; }
        public decimal? TctExtension { get; set; }
        public string TctTipo { get; set; }
        public int TctIdTelefono { get; set; }

        public Contactos TctIdCooNavigation { get; set; }
    }
}
