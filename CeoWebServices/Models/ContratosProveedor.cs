using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class ContratosProveedor
    {
        public ContratosProveedor()
        {
            ContratosDetalle = new HashSet<ContratosDetalle>();
        }

        public decimal CpvIdCpv { get; set; }
        public string CpvNumContrato { get; set; }
        public string CpvCodPrv { get; set; }
        public string CpvEmpVen { get; set; }
        public string CpvNitVen { get; set; }
        public string CpvCiuVen { get; set; }
        public string CpvNomRepLegal { get; set; }
        public string CpvCedRepLegal { get; set; }
        public string CpvPaisVen { get; set; }
        public DateTime? CpvFecOferta { get; set; }
        public string CpvInsumoVen { get; set; }
        public string CpvFechaEnt { get; set; }
        public string CpvValorCont { get; set; }
        public string CpvTrm { get; set; }
        public string CpvFormaPago { get; set; }
        public string CpvFormaEnt { get; set; }
        public string CpvCiudadEnt { get; set; }
        public string CpvPolizaCum { get; set; }
        public string CpvPolizaGar { get; set; }
        public string CpvAnexos { get; set; }
        public string CpvNotiVen { get; set; }
        public string CpvClausulaPenal { get; set; }
        public string CpvFechaContrato { get; set; }

        public ICollection<ContratosDetalle> ContratosDetalle { get; set; }
    }
}
