using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Dto;
using nombremicroservicio.Entities.Respuesta;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface ISolicitud
    {
        Task<Response<string>> Agregar(Credito credito);

        Task<Response<DtoSolicitud>> Consultar(int id);

        Task<Response<string>> Actualizar(Credito credito);
    }
}
