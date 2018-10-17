using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Ciudades
    {
        public Ciudades()
        {
            Contratistas = new HashSet<Contratistas>();
            Direcciones = new HashSet<Direcciones>();
            Proyectos = new HashSet<Proyectos>();
            Vehiculos = new HashSet<Vehiculos>();
        }

        public decimal CieIdCiudad { get; set; }
        public decimal CieIdDepartamento { get; set; }
        public string CieNombre { get; set; }
        public decimal? CieIndicativo { get; set; }
        public string CieCodigo { get; set; }

        public Departamentos CieIdDepartamentoNavigation { get; set; }
        public ICollection<Contratistas> Contratistas { get; set; }
        public ICollection<Direcciones> Direcciones { get; set; }
        public ICollection<Proyectos> Proyectos { get; set; }
        public ICollection<Vehiculos> Vehiculos { get; set; }
    }
}
