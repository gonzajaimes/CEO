

namespace CeoWebServices.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CeoWebServices.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    

    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly CeoContext _context;

        public ProyectosController(CeoContext context)
        {
            _context = context;
        }

        // GET: api/Proyectos
        [HttpGet]
        public IEnumerable<Project> GetProyectos()
        {
            
            return _context.Proyectos.Select(p => new Project
            {
                PryIdProyecto = p.PryIdProyecto,
                PryIdCategoriaContrato = p.PryIdCategoriaContrato,
                PryIdSubcategoriaContrato = p.PryIdSubcategoriaContrato,
                PryIdCiudad = p.PryIdCiudad,
                PryIdDepartamento = p.PryIdDepartamento,
                PryNombreDelProyecto = p.PryNombreDelProyecto,
                PryUbicacion = p.PryUbicacion,
                PryIdEmpresa = p.PryIdEmpresa,
                PryNumeroContrato = p.PryNumeroContrato,
                PryFechaInicio = p.PryFechaInicio,
                PryFechaTerminacion = p.PryFechaTerminacion,
                PryValorInicial = p.PryValorInicial,
                PryAdicionesNumero = p.PryAdicionesNumero,
                PryAdicionesValor = p.PryAdicionesValor,
                PryValorFinal = p.PryValorFinal,
                PryFormalidad = p.PryFormalidad,
                PryValorOfertado = p.PryValorOfertado,
                PryReajustesNumero = p.PryReajustesNumero,
                PryReajustesValor = p.PryReajustesValor,
                PryValorAnticipo = p.PryValorAnticipo,
                PryAlertaActiva = p.PryAlertaActiva,
                PryEjecutado = p.PryEjecutado,
                PryFechaContrato = p.PryFechaContrato,
                PryValorFinalConIva = p.PryValorFinalConIva,
                PryPlazoFinal = p.PryPlazoFinal,
                PrySatisfaccion = p.PrySatisfaccion,
                PryDigitalizado = p.PryDigitalizado,
                PryCertObra = p.PryCertObra,
                PryCertTimbre = p.PryCertTimbre,
                PryCostoteje = p.PryCostoteje,
                PryIvaporc = p.PryIvaporc,
                PryFgporc = p.PryFgporc,
                PryAntiporc = p.PryAntiporc,
                PryTipoanti = p.PryTipoanti,
                PryCodConta = p.PryCodConta,
                PryIdProyPadre = p.PryIdProyPadre,
                PryDiasTerminacion = p.PryDiasTerminacion,
                PryCodRup = p.PryCodRup,
                PryActCon = p.PryActCon,
                PryCompanyName = p.PryIdEmpresaNavigation.EmpRazonSocial,
                PryCityName = p.Pry.CieNombre,
                PryStateName = p.Pry.CieIdDepartamentoNavigation.DepNombre,
                PryCategory = p.PryIdCategoriaContratoNavigation.CcoDescripcion,
                PrySubCategory = p.PryIdSubcategoriaContratoNavigation.ScoDescripcionSubcategoria,
                PryEndDateReal = p.Actas.Where(a => a.ActConcepto == "TERMINACION").Select(a => a.ActFecTerminaContraactual).FirstOrDefault(),
                PryAmortForwardPayment = p.Actas.Sum(a => a.ActValorAmortizaAnticipo),
                PryBalanceForwardPayment = p.Actas.Sum(a => a.ActValorAnticipo) - p.Actas.Sum(a => a.ActValorAmortizaAnticipo),
                PryWarrantyFund = p.Actas.Sum(a => a.ActValorfg),
                PryExecValue = p.Actas.Sum(a => a.ActValorEjecutado),
                PryExecValueBefVat = p.Actas.Sum(a => a.ActValorAntesiva),
                PryVatValue = p.Actas.Sum(a => a.ActValorIva),
                PrySMLV = p.PryEjecutado == "N"? null : 
                          p.Actas.Sum(a => a.ActValorEjecutado) /
                           _context.Smmlv.Where(s => s.SmmYear == p.Actas.Where(
                                      a => a.ActConcepto == "TERMINACION").Select(
                                      a => a.ActFecTerminaContraactual.Value.Year).FirstOrDefault())
                                     .Select(s=>s.SmmValue).FirstOrDefault(),
            }).OrderByDescending(p => p.PryFechaContrato);
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProyectos([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proyectos = await _context.Proyectos.FindAsync(id);

            if (proyectos == null)
            {
                return NotFound();
            }

            return Ok(proyectos);
        }

        // GET: api/Proyectos/actas/id

        [HttpGet("actas/{idProject}")]
        public async Task<IActionResult> GetActas([FromRoute] decimal idProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Actas> actas = await _context.Actas.Where(a=> a.ActIdProyecto.Equals(idProject)).ToListAsync();
            //var additionalValues = await _context.Proyectos.
            //    Where(p => p.PryIdProyecto.Equals(idProject)).
            //    Select(p => new AdditionalValues
            //    {
            //        IdProject = idProject,
            //        Income = p.Actas.Sum(a => a.ActValorAntesiva),
            //        ExecutedCost = p.PryCostoteje,
            //        PercCostEffectiveness = p.PryCostoteje == 0 ? 0 :
            //                                        (p.Actas.Sum(a => a.ActValorAntesiva) - p.PryCostoteje) /
            //                                         p.Actas.Sum(a => a.ActValorAntesiva),
            //        ContractExecTime =  p.Actas.Where(a =>
            //                            a.ActConcepto == "INICIO" ||
            //                            a.ActConcepto == "AMPLIACION PLAZO" ||
            //                            a.ActConcepto == "REINICIO" ||
            //                            a.ActConcepto == "AMPL. PLAZO Y OBRA").
            //                                    Max(a => a.ActFechaTermina) - p.PryFechaInicio,

            //    }).FirstOrDefaultAsync();    


            if (actas == null)
            {
                return NotFound();
            }

            return Ok(actas);
        }

        // GET: api/Proyectos/search/keyword

        [HttpGet("searchid/{idClient}")]
        public async Task<IActionResult> GetProyectosByClient([FromRoute] int idClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Proyectos> proyectos = await _context.Proyectos.Where(m => m.PryIdEmpresa.Equals(idClient))
                .OrderByDescending(p=> p.PryFechaContrato).ToListAsync();

            if (proyectos == null)
            {
                return NotFound();
            }

            return Ok(proyectos);
        }
        // GET: api/Proyectos/clientes

        [HttpGet("clientes")]
        public async Task<IActionResult> GetClientes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Empresas> empresas = await _context.Empresas.ToListAsync();
          
            //List<MenuEmpresa> proyectos = await _context.Proyectos
            //   .GroupBy(p => p.PryIdEmpresaNavigation)
            //   .Select(g => new MenuEmpresa
            //   {
            //       IdEmpresa = g.Key.EmpIdEmpresa,
            //       RazonSocial= g.Key.EmpRazonSocial,
            //       FechaUltimoContrato = g.Max(p => p.PryFechaContrato),
            //       NumeroContratos = g.Count()
            //   })
            //   .OrderByDescending(g => g.FechaUltimoContrato)
            //   .ToListAsync();

         if (empresas == null)
            {
                return NotFound();
            }

            return Ok(empresas);
        }

        // PUT: api/Proyectos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyectos([FromRoute] decimal id, [FromBody] Proyectos proyectos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proyectos.PryIdProyecto)
            {
                return BadRequest();
            }

            _context.Entry(proyectos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Proyectos
        [HttpPost]
        public async Task<IActionResult> PostProyectos([FromBody] Proyectos proyectos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Proyectos.Add(proyectos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyectos", new { id = proyectos.PryIdProyecto }, proyectos);
        }

        // DELETE: api/Proyectos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyectos([FromRoute] decimal id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proyectos = await _context.Proyectos.FindAsync(id);
            if (proyectos == null)
            {
                return NotFound();
            }

            _context.Proyectos.Remove(proyectos);
            await _context.SaveChangesAsync();

            return Ok(proyectos);
        }

        private bool ProyectosExists(decimal id)
        {
            return _context.Proyectos.Any(e => e.PryIdProyecto == id);
        }
    }
}