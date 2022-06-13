using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Dto;
using System.Threading.Tasks;

namespace nombremicroservicio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : Controller
    {
        private readonly ISolicitud _solicitud;
        public SolicitudController(ISolicitud solicitud)
        {
            _solicitud = solicitud;
        }

        // POST: SolicitudController/Create
        [HttpPost]
        [Route("POST")]
        public async Task<IActionResult> Create(DtoCredito credito)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _solicitud.Agregar(credito.Adapt<Credito>()));
            }
            return BadRequest(ModelState.ValidationState);
        }

        // GET: EjecutivoController
        [HttpGet("{id}")]
        public async Task<IActionResult> Consultar(int id)
        {
            return Ok(await _solicitud.Consultar(id));
        }

        // POST: SolicitudController/Edit
        [HttpPut]
        [Route("PUT")]
        public async Task<IActionResult> Edit(DtoCreditoProcesa credito)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _solicitud.Actualizar(credito.Adapt<Credito>()));
            }
            return BadRequest(ModelState.ValidationState);
        }
    }
}
