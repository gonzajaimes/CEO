using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Direcciones
    {
        public Direcciones()
        {
            Contactos = new HashSet<Contactos>();
            Telefonos = new HashSet<Telefonos>();
        }

        public decimal DirIdDireccion { get; set; }
        public string DirDireccion { get; set; }
        public decimal DirIdCiudad { get; set; }
        public decimal DirIdEmpresa { get; set; }
        public decimal DirIdDepartamento { get; set; }

        public Ciudades Dir { get; set; }
        public Empresas DirIdEmpresaNavigation { get; set; }
        public ICollection<Contactos> Contactos { get; set; }
        public ICollection<Telefonos> Telefonos { get; set; }
    }
}
