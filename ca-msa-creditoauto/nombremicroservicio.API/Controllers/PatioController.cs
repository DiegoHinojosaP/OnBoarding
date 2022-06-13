using Mapster;
using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Dto;
using System.Threading.Tasks;

namespace nombremicroservicio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatioController : Controller
    {
        private readonly IPatio _patio;

        public PatioController(IPatio patio)
        {
            _patio = patio;
        }

        [HttpGet]
        public async Task<IActionResult> Consultar() => Ok(await _patio.Consultar());

        // POST: ClienteController/Create
        [HttpPost]
        [Route("POST")]
        public async Task<IActionResult> Create(DtoPatio patio)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _patio.Agregar(patio.Adapt<Patio>()));
            }
            return BadRequest(ModelState.ValidationState);
        }

        // PUT: clientecontroller/edit/5
        [HttpPut]
        public async Task<IActionResult> Edit(DtoPatio patio)
        {
            if (ModelState.IsValid)
            {
                var result = await _patio.Actualizar(patio);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(ModelState.ValidationState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _patio.Eliminar(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
