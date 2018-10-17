using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            Ciudades = new HashSet<Ciudades>();
        }

        public decimal DepIdDepartamento { get; set; }
        public string DepNombre { get; set; }

        public ICollection<Ciudades> Ciudades { get; set; }
    }
}
