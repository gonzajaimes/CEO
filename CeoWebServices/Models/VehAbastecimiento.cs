using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class VehAbastecimiento
    {
        public decimal AbtId { get; set; }
        public string AbtPlaca { get; set; }
        public decimal AbtResponsable { get; set; }
        public decimal? AbtEstacion { get; set; }
        public string AbtTipocombust { get; set; }
        public DateTime AbtFecha { get; set; }
        public decimal AbtValor { get; set; }
        public decimal? AbtKilometraje { get; set; }
        public decimal? AbtGalones { get; set; }

        public Empresas AbtEstacionNavigation { get; set; }
        public Vehiculos AbtPlacaNavigation { get; set; }
        public ContactosEme AbtResponsableNavigation { get; set; }
    }
}
