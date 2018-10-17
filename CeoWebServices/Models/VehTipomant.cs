using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class VehTipomant
    {
        public VehTipomant()
        {
            VehmantVehtpm = new HashSet<VehmantVehtpm>();
        }

        public decimal VmtTipomant { get; set; }
        public string VmtDescripcion { get; set; }

        public ICollection<VehmantVehtpm> VehmantVehtpm { get; set; }
    }
}
