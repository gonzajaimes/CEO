
namespace CeoWebServices.Models
{
    using System;
    using System.Collections.Generic;

    public class Project
    {
        public decimal PryIdProyecto { get; set; }
        public decimal PryIdCategoriaContrato { get; set; }
        public decimal? PryIdSubcategoriaContrato { get; set; }
        public decimal PryIdCiudad { get; set; }
        public decimal PryIdDepartamento { get; set; }
        public string PryNombreDelProyecto { get; set; }
        public string PryUbicacion { get; set; }
        public decimal PryIdEmpresa { get; set; }
        public string PryNumeroContrato { get; set; }
        public DateTime? PryFechaInicio { get; set; }
        public DateTime? PryFechaTerminacion { get; set; }
        public decimal? PryValorInicial { get; set; }
        public decimal? PryAdicionesNumero { get; set; }
        public decimal? PryAdicionesValor { get; set; }
        public decimal? PryValorFinal { get; set; }
        public string PryFormalidad { get; set; }
        public decimal? PryValorOfertado { get; set; }
        public decimal? PryReajustesNumero { get; set; }
        public decimal? PryReajustesValor { get; set; }
        public decimal? PryValorAnticipo { get; set; }
        public string PryAlertaActiva { get; set; }
        public string PryEjecutado { get; set; }
        public DateTime? PryFechaContrato { get; set; }
        public decimal? PryValorFinalConIva { get; set; }
        public decimal? PryPlazoFinal { get; set; }
        public string PrySatisfaccion { get; set; }
        public string PryDigitalizado { get; set; }
        public string PryCertObra { get; set; }
        public string PryCertTimbre { get; set; }
        public decimal? PryCostoteje { get; set; }
        public decimal? PryIvaporc { get; set; }
        public decimal? PryFgporc { get; set; }
        public decimal? PryAntiporc { get; set; }
        public string PryTipoanti { get; set; }
        public string PryCodConta { get; set; }
        public decimal? PryIdProyPadre { get; set; }
        public decimal? PryDiasTerminacion { get; set; }
        public decimal? PryCodRup { get; set; }
        public string PryActCon { get; set; }

        //custom properties to read on the app
        public string PryCompanyName { get; set; }
        public string PryCityName { get; set; }
        public string PryStateName { get; set; }
        public string PryCategory { get; set; }
        public string PrySubCategory { get; set; }

    }
}
