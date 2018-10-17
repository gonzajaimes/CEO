using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class ContactosEme
    {
        public ContactosEme()
        {
            CategoriaDocumento = new HashSet<CategoriaDocumento>();
            VehAbastecimiento = new HashSet<VehAbastecimiento>();
            VehDesplazamiento = new HashSet<VehDesplazamiento>();
            VehDocumentos = new HashSet<VehDocumentos>();
            VehMantenimientos = new HashSet<VehMantenimientos>();
        }

        public decimal CeeIdContactoEme { get; set; }
        public string CeeCedula { get; set; }
        public string CeeNombres { get; set; }
        public string CeeApellidos { get; set; }
        public string CeeIdUsuario { get; set; }
        public string CeeCargoActual { get; set; }
        public DateTime CeeFechaNacimiento { get; set; }
        public DateTime CeeFechaIngreso { get; set; }
        public decimal CeeSalarioActual { get; set; }
        public string CeeDireccionResidencia { get; set; }
        public string CeeTelefonoResidencia { get; set; }
        public string CeeCelular { get; set; }
        public string CeeAvantel { get; set; }
        public string CeeEmail { get; set; }
        public string CeeNombreConyuge { get; set; }
        public decimal? CeeNumeroHijos { get; set; }
        public string CeePassword { get; set; }
        public string CeePerfil { get; set; }
        public decimal CeeIdGrupo { get; set; }
        public string CeeDigitalizado { get; set; }
        public decimal? CeeNroDocumentos { get; set; }
        public string CeeActivo { get; set; }
        public string CeeAcceso { get; set; }
        public string CeeNrocont { get; set; }
        public DateTime? CeeFecret { get; set; }
        public string CeeTipcont { get; set; }

        public Grupos CeeIdGrupoNavigation { get; set; }
        public ICollection<CategoriaDocumento> CategoriaDocumento { get; set; }
        public ICollection<VehAbastecimiento> VehAbastecimiento { get; set; }
        public ICollection<VehDesplazamiento> VehDesplazamiento { get; set; }
        public ICollection<VehDocumentos> VehDocumentos { get; set; }
        public ICollection<VehMantenimientos> VehMantenimientos { get; set; }
    }
}
