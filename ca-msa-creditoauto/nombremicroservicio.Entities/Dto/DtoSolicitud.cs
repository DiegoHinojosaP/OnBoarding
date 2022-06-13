using System;

namespace nombremicroservicio.Entities.Dto
{
    public class DtoSolicitud
    {
        public DtoSolicitud()
        {
            Vehiculo = new DtoVehiculo();
        }

        public DateTime FechaCrecion { get; set; }
        public string Ejecutivo { get; set; }
        public string Patio { get; set; }
        public string Identificacion { get; set; }
        public string Cliente { get; set; }
        public int MesesPlazo { get; set; }
        public decimal ValorCuota { get; set; }
        public decimal Entrada { get; set; }
        public string Estado { get; set; }
        public DtoVehiculo Vehiculo  { get; set; }

    }
}
