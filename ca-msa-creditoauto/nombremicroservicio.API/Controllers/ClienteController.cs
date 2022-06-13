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
    public class ClienteController : Controller
    {
        private readonly ICliente _cliente;


        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;
        }

        [HttpPost]
        [Route("CargaInicial")]
        public async Task<IActionResult> CargaInicial() => Ok(await _cliente.CargaInicial());

        // GET: EjecutivoController
        [HttpGet("{id}")]
        public async Task<IActionResult> Consultar(int id)
        {
            return Ok(await _cliente.Consultar(id));
        }

        // POST: ClienteController/Create
        [HttpPost]
        [Route("POST")]
        public async Task<IActionResult> Create(DtoCliente cliente)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _cliente.Agregar(cliente.Adapt<Cliente>()));
            }
            return BadRequest(ModelState.ValidationState);
        }

        // PUT: clientecontroller/edit/5
        [HttpPut]
        public async Task<IActionResult> Edit(DtoCliente cliente)
        {
            if (ModelState.IsValid)
            {
                var result = await _cliente.Actualizar(cliente);
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
            var result = await _cliente.Eliminar(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
