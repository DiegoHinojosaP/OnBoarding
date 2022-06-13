using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Dto;
using nombremicroservicio.Entities.Respuesta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface IPatio
    {
        Task<Response<List<Patio>>> Consultar();
        Task<Response<string>> Agregar(Patio dto);
        Task<Response<string>> Actualizar(DtoPatio dto);
        Task<Response<string>> Eliminar(int id);

    }
}
