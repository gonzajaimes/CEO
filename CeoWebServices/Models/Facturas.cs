using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Facturas
    {
        public Facturas()
        {
            Abonos = new HashSet<Abonos>();
        }

        public decimal FacIdFact { get; set; }
        public decimal FacNumFact { get; set; }
        public decimal FacIdEmpresa { get; set; }
        public decimal? FacIdProyecto { get; set; }
        public DateTime FacFechaFact { get; set; }
        public DateTime? FacFechaVenc { get; set; }
        public decimal FacValorAntesiva { get; set; }
        public decimal FacValorIva { get; set; }
        public decimal FacValorTotal { get; set; }
        public decimal? FacAnticipo { get; set; }
        public decimal? FacRetegarantia { get; set; }
        public decimal? FacValorNeto { get; set; }
        public decimal? FacRetefuent { get; set; }
        public DateTime? FacFechaPago { get; set; }
        public string FacCancelo { get; set; }
        public decimal? FacValorCancelado { get; set; }
        public string FacObs { get; set; }
        public decimal? FacIdActa { get; set; }
        public decimal? FacReteIva { get; set; }
        public decimal? FacReteIca { get; set; }
        public decimal? FacReteOtros { get; set; }
        public string FacDigi { get; set; }
        public DateTime? FacFechaRadic { get; set; }
        public string FacTipoDoc { get; set; }
        public decimal? FacCree { get; set; }

        public Empresas FacIdEmpresaNavigation { get; set; }
        public Proyectos FacIdProyectoNavigation { get; set; }
        public ICollection<Abonos> Abonos { get; set; }
    }
}
