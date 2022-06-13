using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Respuesta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface IMarca
    {
        Task<Response<List<Marca>>> CargaInicial();
        Task<Response<List<Marca>>> Consultar();
    }
}
