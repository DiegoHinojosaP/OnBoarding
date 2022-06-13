using System;
using System.Collections.Generic;

#nullable disable

namespace nombremicroservicio.Entities
{
    public partial class Asignacion
    {
        public int AsiIdAsigancion { get; set; }
        public int CliIdCliente { get; set; }
        public int PatIdPatio { get; set; }
        public DateTime AsiFechaAsignacion { get; set; }

        public virtual Cliente CliIdClienteNavigation { get; set; }
        public virtual Patio PatIdPatioNavigation { get; set; }
    }
}
