using System;

namespace nombremicroservicio.Entities.Dto
{
    public class DtoCreditoProcesa
    {
        public int CreIdCredito { get; set; }
        public int CliIdCliente { get; set; }
        public int EjeIdEjecutivo { get; set; }
        public int VehIdVehiculo { get; set; }
        public int PatIdPatio { get; set; }
        public int CreMesesPlazo { get; set; }
        public int CreCuotas { get; set; }
        public decimal CreEntrada { get; set; }
        public string CreEstado { get; set; }
        public string CreObservacion { get; set; }
    }
}
