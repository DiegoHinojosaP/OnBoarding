using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Domain.Interfaces;
using System.Threading.Tasks;

namespace nombremicroservicio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjecutivoController : Controller
    {
        private readonly IEjecutivo _ejecutivo;


        public EjecutivoController(IEjecutivo ejecutivo)
        {
            _ejecutivo = ejecutivo;
        }

        // GET: EjecutivoController
        [HttpGet]
        public async Task<IActionResult> Consultar() => Ok(await _ejecutivo.Consultar());

        // GET: EjecutivoController
        [HttpGet("{patio}")]
        public async Task<IActionResult> Consultar(int patio)
        {
            return Ok(await _ejecutivo.Consultar(patio));
        }

        // POST: EjecutivoController
        [HttpPost]
        public async Task<IActionResult> Find()
        {
            return Ok(await _ejecutivo.CargaInicial());
        }
    }
}
