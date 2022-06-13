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
    public class AutoController : Controller
    {
        private readonly IAuto _auto;
        public AutoController(IAuto auto)
        {
            _auto = auto;
        }

        // GET: AutoController/Find
        [HttpGet("")]
        public async Task<IActionResult> Find() => Ok(await _auto.Consultar());

        // POST: AutoController/Create
        [HttpPost]
        public async Task<IActionResult> Create(DtoVehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _auto.Agregar(vehiculo.Adapt<Vehiculo>()));
            }
            return BadRequest(ModelState.ValidationState);
        }

        // PUT: AutoController/edit/5
        [HttpPut]
        public async Task<IActionResult> Edit(DtoVehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                var result = await _auto.Actualizar(vehiculo);
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
            var result = await _auto.Eliminar(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
