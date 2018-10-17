using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Contactos
    {
        public Contactos()
        {
            TelfCont = new HashSet<TelfCont>();
        }

        public decimal CooIdContacto { get; set; }
        public decimal CooIdEmpresa { get; set; }
        public decimal CooIdDireccion { get; set; }
        public string CooNombres { get; set; }
        public string CooApellidos { get; set; }
        public string CooCargo { get; set; }
        public string CooEmail { get; set; }
        public string CooCelular { get; set; }
        public string CooCedula { get; set; }
        public string CooExtension { get; set; }
        public decimal? CooTelDirecto { get; set; }
        public decimal? CooTelResid { get; set; }

        public Direcciones CooIdDireccionNavigation { get; set; }
        public Empresas CooIdEmpresaNavigation { get; set; }
        public ICollection<TelfCont> TelfCont { get; set; }
    }
}
