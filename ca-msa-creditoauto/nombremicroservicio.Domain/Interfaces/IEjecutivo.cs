using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Respuesta;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface IEjecutivo
    {
        Task<Response<List<Ejecutivo>>> CargaInicial();
        Task<Response<List<Ejecutivo>>> Consultar();
        Task<Response<List<Ejecutivo>>> Consultar(int patio);
    }
}
