using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class VehmantVehtpm
    {
        public decimal VvmIdMant { get; set; }
        public decimal VvmIdTipoMant { get; set; }

        public VehMantenimientos VvmIdMantNavigation { get; set; }
        public VehTipomant VvmIdTipoMantNavigation { get; set; }
    }
}
