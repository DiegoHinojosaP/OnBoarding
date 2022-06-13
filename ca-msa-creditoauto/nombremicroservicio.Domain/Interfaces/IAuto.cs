using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Dto;
using nombremicroservicio.Entities.Respuesta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface IAuto
    {
        Task<Response<List<Vehiculo>>> Consultar();
        Task<Response<string>> Agregar(Vehiculo vehiculo);
        Task<Response<string>> Actualizar(DtoVehiculo vehiculo);
        Task<Response<string>> Eliminar(int id);

    }
}
