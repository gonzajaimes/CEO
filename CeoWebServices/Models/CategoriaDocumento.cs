using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class CategoriaDocumento
    {
        public CategoriaDocumento()
        {
            Archivos = new HashSet<Archivos>();
        }

        public decimal CdoIdCategoria { get; set; }
        public string CdoDescripcion { get; set; }
        public string CdoRuta { get; set; }
        public decimal CdoIdAdministrador { get; set; }

        public ContactosEme CdoIdAdministradorNavigation { get; set; }
        public ICollection<Archivos> Archivos { get; set; }
    }
}
