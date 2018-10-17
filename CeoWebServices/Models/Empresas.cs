using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Empresas
    {
        public Empresas()
        {
            Consorcio = new HashSet<Consorcio>();
            Contactos = new HashSet<Contactos>();
            Direcciones = new HashSet<Direcciones>();
            EmpProductoServicio = new HashSet<EmpProductoServicio>();
            Facturas = new HashSet<Facturas>();
            Proyectos = new HashSet<Proyectos>();
            Rup = new HashSet<Rup>();
            VehAbastecimiento = new HashSet<VehAbastecimiento>();
            VehDocumentos = new HashSet<VehDocumentos>();
            VehMantenimientos = new HashSet<VehMantenimientos>();
        }

        public decimal EmpIdEmpresa { get; set; }
        public decimal EmpIdCategoriaEmpresa { get; set; }
        public string EmpRazonSocial { get; set; }
        public string EmpSitioWeb { get; set; }
        public string EmpNit { get; set; }
        public string EmpRegimenTributario { get; set; }
        public string EmpEsProveedor { get; set; }
        public string EmpEsCliente { get; set; }
        public string EmpEsAutoretenedor { get; set; }
        public DateTime? EmpFechaInactiva { get; set; }
        public string EmpInactiva { get; set; }
        public string EmpInactivaObservacion { get; set; }
        public string CieCodigo { get; set; }
        public string EmpTipoPersona { get; set; }
        public string EmpTipoIden { get; set; }
        public string EmpCorreo { get; set; }

        public CategoriaEmpresas EmpIdCategoriaEmpresaNavigation { get; set; }
        public ICollection<Consorcio> Consorcio { get; set; }
        public ICollection<Contactos> Contactos { get; set; }
        public ICollection<Direcciones> Direcciones { get; set; }
        public ICollection<EmpProductoServicio> EmpProductoServicio { get; set; }
        public ICollection<Facturas> Facturas { get; set; }
        public ICollection<Proyectos> Proyectos { get; set; }
        public ICollection<Rup> Rup { get; set; }
        public ICollection<VehAbastecimiento> VehAbastecimiento { get; set; }
        public ICollection<VehDocumentos> VehDocumentos { get; set; }
        public ICollection<VehMantenimientos> VehMantenimientos { get; set; }
    }
}
