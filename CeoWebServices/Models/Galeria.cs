using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Galeria
    {
        public Galeria()
        {
            Foto = new HashSet<Foto>();
        }

        public int GalIdGaleria { get; set; }
        public decimal GalIdProyecto { get; set; }
        public string GalTitulo { get; set; }
        public string GalDescripcion { get; set; }
        public DateTime GalFecha { get; set; }
        public int? GalEstado { get; set; }

        public ICollection<Foto> Foto { get; set; }
    }
}
