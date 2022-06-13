using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Dto;
using nombremicroservicio.Entities.Respuesta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface ICliente
    {
        Task<Response<List<Cliente>>> CargaInicial();
        Task<Response<DtoCliente>> Consultar(int id);
        Task<Response<string>> Agregar(Cliente dto);
        Task<Response<string>> Actualizar(DtoCliente dto);
        Task<Response<string>> Eliminar(int id);
    }
}
