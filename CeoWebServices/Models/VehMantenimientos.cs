using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class VehMantenimientos
    {
        public VehMantenimientos()
        {
            VehmantVehtpm = new HashSet<VehmantVehtpm>();
        }

        public decimal MtsId { get; set; }
        public string MtsPlaca { get; set; }
        public decimal MtsResponsable { get; set; }
        public decimal MtsTaller { get; set; }
        public DateTime MtsFecha { get; set; }
        public decimal MtsValor { get; set; }
        public decimal MtsKilometraje { get; set; }
        public string MtsObservaciones { get; set; }
        public string MtsFactura { get; set; }
        public string MtsDigi { get; set; }

        public Vehiculos MtsPlacaNavigation { get; set; }
        public ContactosEme MtsResponsableNavigation { get; set; }
        public Empresas MtsTallerNavigation { get; set; }
        public ICollection<VehmantVehtpm> VehmantVehtpm { get; set; }
    }
}
