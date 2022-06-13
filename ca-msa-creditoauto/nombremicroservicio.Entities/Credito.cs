using System;
using System.Collections.Generic;

#nullable disable

namespace nombremicroservicio.Entities
{
    public partial class Credito
    {
        public int CreIdCredito { get; set; }
        public int CliIdCliente { get; set; }
        public int EjeIdEjecutivo { get; set; }
        public int VehIdVehiculo { get; set; }
        public int PatIdPatio { get; set; }
        public DateTime CreFechaElaboracion { get; set; }
        public int CreMesesPlazo { get; set; }
        public decimal CreCuotas { get; set; }
        public decimal CreEntrada { get; set; }
        public string CreEstado { get; set; }
        public string CreObservacion { get; set; }

        public virtual Cliente CliIdClienteNavigation { get; set; }
        public virtual Ejecutivo EjeIdEjecutivoNavigation { get; set; }
        public virtual Patio PatIdPatioNavigation { get; set; }
        public virtual Vehiculo VehIdVehiculoNavigation { get; set; }
    }
}
