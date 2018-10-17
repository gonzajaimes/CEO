using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class ProductoServicio
    {
        public ProductoServicio()
        {
            EmpProductoServicio = new HashSet<EmpProductoServicio>();
        }

        public decimal PsIdProductoServicio { get; set; }
        public string PsDescripcion { get; set; }

        public ICollection<EmpProductoServicio> EmpProductoServicio { get; set; }
    }
}
