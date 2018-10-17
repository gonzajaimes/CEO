using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Vehiculos
    {
        public Vehiculos()
        {
            VehAbastecimiento = new HashSet<VehAbastecimiento>();
            VehDesplazamiento = new HashSet<VehDesplazamiento>();
            VehDocumentos = new HashSet<VehDocumentos>();
            VehMantenimientos = new HashSet<VehMantenimientos>();
        }

        public string VehPlaca { get; set; }
        public string VehMarca { get; set; }
        public string VehModelo { get; set; }
        public decimal VehAnno { get; set; }
        public string VehCilindraje { get; set; }
        public string VehColor { get; set; }
        public string VehNrochasis { get; set; }
        public string VehNroserie { get; set; }
        public DateTime VehFechacompra { get; set; }
        public string VehPropietario { get; set; }
        public decimal VehIdCiudad { get; set; }
        public decimal VehIdDepartamento { get; set; }
        public string VehActivo { get; set; }
        public decimal? VehCmt { get; set; }
        public string VehCambioAceite { get; set; }

        public Ciudades Veh { get; set; }
        public ICollection<VehAbastecimiento> VehAbastecimiento { get; set; }
        public ICollection<VehDesplazamiento> VehDesplazamiento { get; set; }
        public ICollection<VehDocumentos> VehDocumentos { get; set; }
        public ICollection<VehMantenimientos> VehMantenimientos { get; set; }
    }
}
