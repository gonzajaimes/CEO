using System;
using System.Collections.Generic;

namespace CeoWebServices.Models
{
    public partial class Actas
    {
        public decimal ActIdProyecto { get; set; }
        public string ActConcepto { get; set; }
        public DateTime ActFechaActa { get; set; }
        public DateTime? ActFechaInicio { get; set; }
        public decimal? ActPlazo { get; set; }
        public DateTime? ActFechaTermina { get; set; }
        public DateTime? ActFechaSuspension { get; set; }
        public decimal? ActDiasSuspension { get; set; }
        public string ActSusDependeReinicio { get; set; }
        public DateTime? ActFechaReinicio { get; set; }
        public DateTime? ActNuevaFinalizacion { get; set; }
        public decimal? ActValorAdicion { get; set; }
        public decimal? ActNuevoValorContrato { get; set; }
        public decimal? ActDiasAmpliacion { get; set; }
        public decimal? ActValorReajuste { get; set; }
        public decimal ActIdActa { get; set; }
        public decimal? ActValorAnticipo { get; set; }
        public decimal? ActValorAntesiva { get; set; }
        public decimal? ActValorIva { get; set; }
        public decimal? ActValorAmortizaAnticipo { get; set; }
        public decimal? ActValorEjecutado { get; set; }
        public string ActTipoValorNeto { get; set; }
        public DateTime? ActFecTerminaContraactual { get; set; }
        public decimal? ActValorNetoEjecutado { get; set; }
        public string ActFactura { get; set; }
        public DateTime? ActFechaFactura { get; set; }
        public decimal? ActValorAdicionAe { get; set; }
        public decimal? ActValorExtraAe { get; set; }
        public string ActIdActaEme { get; set; }
        public decimal ActId { get; set; }
        public string ActDigitalizado { get; set; }
        public string ActTipofg { get; set; }
        public decimal? ActValorfg { get; set; }

        public Proyectos ActIdProyectoNavigation { get; set; }
    }
}
