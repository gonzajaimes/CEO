using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Contratistas
    {
        public int CttIdContratista { get; set; }
        public long CttCedula { get; set; }
        public string CttNombre { get; set; }
        public string CttApellido { get; set; }
        public string CttRut { get; set; }
        public decimal? CttTelefono { get; set; }
        public decimal? CttMovil { get; set; }
        public string CttDireccion { get; set; }
        public string CttBarrio { get; set; }
        public decimal CttIdCiudad { get; set; }
        public decimal CttIdDepartamento { get; set; }
        public int CttEstado { get; set; }
        public string CttRegimen { get; set; }
        public string CttRazonsocial { get; set; }

        public Ciudades Ctt { get; set; }
    }
}
