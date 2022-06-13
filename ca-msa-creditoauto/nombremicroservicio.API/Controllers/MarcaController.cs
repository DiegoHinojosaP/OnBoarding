using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Domain.Interfaces;
using System.Threading.Tasks;

namespace nombremicroservicio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : Controller
    {
        private readonly IMarca _marca;

        public MarcaController(IMarca marca)
        {
            _marca = marca;
        }

        [HttpGet]
        public async Task<IActionResult> Consultar() => Ok(await _marca.Consultar());

        [HttpPost]
        public async Task<IActionResult> CargaInicial() => Ok(await _marca.CargaInicial());
    }
}
