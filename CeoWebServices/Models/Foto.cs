using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Foto
    {
        public int FotIdFoto { get; set; }
        public int FotIdGaleria { get; set; }
        public string FotNombre { get; set; }
        public DateTime FotFecha { get; set; }
        public int? FotEstado { get; set; }
        public string FotDescripcion { get; set; }

        public Galeria FotIdGaleriaNavigation { get; set; }
    }
}
