

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
                PryAdicionesNumero = p.Actas.Where(a=> a.ActConcepto == "AMPL. PLAZO Y OBRA ADICIONAL" ||
                                                       a.ActConcepto == "OBRA EXTRA" ||
                                                       a.ActConcepto == "OBRA ADICIONAL" ||
                                                       a.ActConcepto == "OBRA ADICIONAL Y EXTRA").Count(),
                PryAdicionesValor = p.Actas.Where(a => a.ActConcepto == "AMPL. PLAZO Y OBRA ADICIONAL" ||
                                                       a.ActConcepto == "OBRA EXTRA" ||
                                                       a.ActConcepto == "OBRA ADICIONAL" ||
                                                       a.ActConcepto == "OBRA ADICIONAL Y EXTRA").Sum(a=> a.ActValorAdicion),
                PryValorFinal = p.PryValorFinal,
                PryFormalidad = p.PryFormalidad,
                PryValorOfertado = p.PryValorOfertado,
                PryReajustesNumero = p.Actas.Where(a => a.ActConcepto == "REAJUSTE").Count(),
                PryReajustesValor = p.Actas.Where(a => a.ActConcepto == "REAJUSTE").Sum(a=> a.ActValorReajuste),
                PryValorAnticipo = p.Actas.Sum(a => a.ActValorAnticipo),
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
                AreaProject = p.AreaProyecto,
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


        // GET: api/Proyectos/Last
        [HttpGet("Last")]
        public async Task<IActionResult> GetLastProject()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proyectos = await _context.Proyectos.OrderByDescending(p=>p.PryIdProyecto).FirstOrDefaultAsync();

            if (proyectos == null)
            {
                return NotFound();
            }

            return Ok(proyectos);
        }

        // GET: api/Proyectos/areaproyectos/id

        [HttpGet("areaproyectos/{idProject}")]
        public async Task<IActionResult> GetAreaProyectos([FromRoute] decimal idProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<AreaProyecto> areaProyectos = await _context.AreaProyecto.Include(
                                                     a=> a.ApyIdAreaNavigation).Where
                                                     (a => a.ApyIdProyecto.Equals(idProject)).ToListAsync();


            if (areaProyectos == null)
            {
                return NotFound();
            }

            return Ok(areaProyectos);
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

        [HttpGet("Countries")]
        public async Task<IActionResult> GetCountries()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Countries> countries = await _context.Countries.Where(c=> c.Cities.Count() > 0).ToListAsync();

            if (countries == null)
            {
                return NotFound();
            }

            return Ok(countries);
        }



        //// PUT: api/Proyectos/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProyectos([FromRoute] decimal id, [FromBody] Proyectos proyectos)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != proyectos.PryIdProyecto)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(proyectos).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProyectosExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Proyectos
        //[HttpPost]
        //public async Task<IActionResult> PostProyectos([FromBody] Proyectos proyectos)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Proyectos.Add(proyectos);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProyectos", new { id = proyectos.PryIdProyecto }, proyectos);
        //}

        //// DELETE: api/Proyectos/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProyectos([FromRoute] decimal id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var proyectos = await _context.Proyectos.FindAsync(id);
        //    if (proyectos == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Proyectos.Remove(proyectos);
        //    await _context.SaveChangesAsync();

        //    return Ok(proyectos);
        //}

        private bool ProyectosExists(decimal id)
        {
            return _context.Proyectos.Any(e => e.PryIdProyecto == id);
        }
    }
}